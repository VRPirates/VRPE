using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
namespace VRPE_Installer
{
    internal class Downloader
    {
        public class HttpClientDownloadWithProgress : IDisposable
        {
            private readonly string _downloadUrl;
            private readonly string _destinationFilePath;
            public static string rookieDL = string.Empty;

            private HttpClient _httpClient;

            public HttpClientDownloadWithProgress(string downloadUrl, string destinationFilePath)
            {
                _downloadUrl = downloadUrl;
                _destinationFilePath = destinationFilePath;
            }

            public async Task StartDownload()
            {
                _httpClient = new HttpClient { Timeout = TimeSpan.FromDays(1) };

                using (var response = await _httpClient.GetAsync(_downloadUrl, HttpCompletionOption.ResponseHeadersRead))
                    await DownloadFileFromHttpResponseMessage(response);
            }

            private async Task DownloadFileFromHttpResponseMessage(HttpResponseMessage response)
            {
                response.EnsureSuccessStatusCode();

                var totalBytes = response.Content.Headers.ContentLength;

                using (var contentStream = await response.Content.ReadAsStreamAsync())
                    await ProcessContentStream(totalBytes, contentStream);
            }

            private async Task ProcessContentStream(long? totalDownloadSize, Stream contentStream)
            {
                var totalBytesRead = 0L;
                var readCount = 0L;
                var buffer = new byte[8192];
                var isMoreToRead = true;

                using (var fileStream = new FileStream(_destinationFilePath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                {
                    do
                    {
                        var bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length);
                        if (bytesRead == 0)
                        {
                            isMoreToRead = false;
                            continue;
                        }

                        await fileStream.WriteAsync(buffer, 0, bytesRead);

                        totalBytesRead += bytesRead;
                        readCount += 1;
                    }
                    while (isMoreToRead);
                }
            }

            public void Dispose()
            {
                _httpClient?.Dispose();
            }
        }

        // Downloads Rookie from a link that is defined in the github repo file (HTTP Client fetches the string)
        public static async Task<bool> GetRookie(string selectedPath, string fixPath)
        {
            string rookieLink = "https://raw.githubusercontent.com/VRPirates/VRPE-Links/main/Rookie";
            string rookieDL = Program.HttpClient.GetStringAsync($"{rookieLink}").Result;
            var downloadFileUrl = $"{rookieDL}";
            var destinationFilePath = Path.GetFullPath($"{selectedPath}{fixPath}RSL.zip");
            try
            {
                using (var client = new HttpClientDownloadWithProgress(downloadFileUrl, destinationFilePath))
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    await client.StartDownload();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBoxes.exceptionMessage = ex.Message;
                MessageBoxes.DownloadError();
                return false;
            }
        }

        public static async Task<bool> GetIcons(string RSLPATH, string iconName, string neededIcon)
        {
            var iconPath = Path.GetFullPath($"{RSLPATH}{iconName}");
            try
            {
                using (var client = new HttpClientDownloadWithProgress(neededIcon, iconPath))
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    await client.StartDownload();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBoxes.exceptionMessage = ex.Message;
                MessageBoxes.DownloadError();
                return false;
            }
        }


        // Downloads the VRP GUI from a link that is defined in the github repo file (HTTP Client fetches the string)
        public static async Task<bool> GetVRPGUI(string selectedPathVRPGUI, string fixPath)
        {
            string VRPGUILink = "https://raw.githubusercontent.com/VRPirates/VRPE-Links/main/VRP-GUI";
            string VRPGUIDL = Program.HttpClient.GetStringAsync($"{VRPGUILink}").Result;
            var downloadFileUrl = $"{VRPGUIDL}";
            var destinationFilePathVRPGUI = Path.GetFullPath($"{selectedPathVRPGUI}{fixPath}VRPGUI.zip");
            try
            {
                using (var client = new HttpClientDownloadWithProgress(downloadFileUrl, destinationFilePathVRPGUI))
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    await client.StartDownload();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBoxes.exceptionMessage = ex.Message;
                MessageBoxes.DownloadError();
                return false;
            }
        }

        public static async Task<bool> GetShortcutMaker(string selectedPathShortcutMaker, string fixPath)
        {
            var downloadFileUrl = "https://vrpirates.wiki/downloads/shortcut_maker.zip";
            var destinationFilePathShortcutMaker = Path.GetFullPath($"{selectedPathShortcutMaker}{fixPath}ShortcutMaker.zip");
            try
            {
                using (var client = new HttpClientDownloadWithProgress(downloadFileUrl, destinationFilePathShortcutMaker))
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    await client.StartDownload();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBoxes.exceptionMessage = ex.Message;
                MessageBoxes.DownloadError();
                return false;
            }
        }
    }
}