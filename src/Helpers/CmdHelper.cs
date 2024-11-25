using System.Diagnostics;

namespace ConsoleAppDevTools.Helpers
{
    public class CmdHelper
    {
        public CmdHelper(string defaultDirectory)
        {
            DefaultDirectory = defaultDirectory;
        }

        private string DefaultDirectory { get; set; }

        /// <summary>
        /// 執行 CMD ，可多組
        /// </summary>
        public void RunCmd(params string[] arguments)
        {
            string newarguments = string.Join(" & ", arguments);

            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c \"" + newarguments + "\"",
                WorkingDirectory = DefaultDirectory,
            };

            var process = Process.Start(startInfo)!;

            process.WaitForExit();

            if (process.ExitCode != 0)
            {
                throw new Exception("執行發生錯誤，語法:" + newarguments);
            }
        }
    }
}
