using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ForSureLife.repo.Carrier_Access
{
    public class AmAmFTPClient : IAmAmFTPClient
    {
        public IConfiguration Configuration { get; }

        public AmAmFTPClient(IConfiguration _Configuration)
        {
            Configuration = _Configuration;
        }
        public static bool SkipUpload = false;
        public string ConfigFtpFolder { get { return this.Configuration.GetValue<string>("FTPSettings:Folder"); } }
        public string ConfigFtpHost { get { return this.Configuration.GetValue<string>("FTPSettings:Host"); } }
        public string ConfigFtpUser { get { return this.Configuration.GetValue<string>("FTPSettings:User"); } }
        public string ConfigFtpPassword { get { return this.Configuration.GetValue<string>("FTPSettings:Password"); } }
        public string[] ListDirectory()
        {
            var list = new List<string>();

            var request = createRequest("ftp://" + ConfigFtpHost + "/", WebRequestMethods.Ftp.ListDirectory);

            using (var response = (FtpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream, true))
                    {
                        while (!reader.EndOfStream)
                        {
                            list.Add(reader.ReadLine());
                        }
                    }
                }
            }

            return list.ToArray();
        }
        private FtpWebRequest createRequest(string uri, string method)
        {
            var r = (FtpWebRequest)WebRequest.Create(uri);

            r.Credentials = new NetworkCredential(ConfigFtpUser, ConfigFtpPassword);
            r.Method = method;
            r.EnableSsl = true;

            return r;
        }

        public async Task UploadApplicationFile(string path)
        {
            if (SkipUpload) return;

            // todo: check permission fot this ftp user
            var all = ListDirectory();

            var ftpDistintion = "ftp://" + ConfigFtpHost + "/" + ConfigFtpFolder + "/" + Path.GetFileName(path);
            FtpWebRequest request =
                (FtpWebRequest)WebRequest.Create(ftpDistintion);
            request.Credentials = new NetworkCredential(ConfigFtpUser, ConfigFtpPassword);
            request.EnableSsl = true;
            request.Method = WebRequestMethods.Ftp.UploadFile;

            request.UseBinary = true;
            request.UsePassive = true;

            using Stream fileStream = File.OpenRead(path);
            request.ContentLength = fileStream.Length;
            using Stream ftpStream = await request.GetRequestStreamAsync();

            {
                await fileStream.CopyToAsync(ftpStream);
            }
        }
    }
}