using System;
using System.IO;
using CommandLine;
using Core;

namespace Client.Options
{
    [Verb("download", HelpText = "Downloads a file provided the correct password is given")]
    public class DownloadOptions
    {
        [Option('f',"filename", HelpText = "Unique name of file to be downloaded", Required = true)]
        public string FileName { get; set; }
        
        [Option('p',"password", HelpText = "Password used to access file", Required = true)]
        public string Password { get; set; }

        public static int ExecuteDownloadAndReturnExitCode(DownloadOptions options)
        {
            try
            {
                // This creates client request to be sent
                var request = new FileRequest
                {
                    Action = Core.Action.download,
                    Filename = options.FileName,
                    Password = options.Password,
                };

                Console.WriteLine($"Attempting to download file: {options.FileName} with Password: {options.Password}");
                Api.Download(request);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            return 0;
        }
    }
}