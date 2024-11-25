using System.IO.Compression;

namespace ConsoleAppDevTools.Helpers
{
    public class FileHelper
    {
        /// <summary>
        /// 複製檔案
        /// </summary>
        public void CopyFiles(string sourceDir = "", string destinationDir = "")
        {
            string[] files = Directory.GetFiles(sourceDir);
            string[] dirs = Directory.GetDirectories(sourceDir);

            if (!Directory.Exists(destinationDir))
            {
                Directory.CreateDirectory(destinationDir);
            }

            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(destinationDir, fileName);
                File.Copy(file, destFile, true);
            }

            foreach (string subdir in dirs)
            {
                string dirName = Path.GetFileName(subdir);
                string destDir = Path.Combine(destinationDir, dirName);
                CopyFiles(subdir, destDir);
            }
        }

        /// <summary>
        /// 刪除資料夾和檔案
        /// </summary>
        public void DelDirectoryAndFiles(string sourceDir, string[] directoriesToDelete, string[] filesToDelete)
        {
            foreach (var directory in directoriesToDelete)
            {
                string directoryPath = Path.Combine(sourceDir, directory);
                if (Directory.Exists(directoryPath))
                {
                    Directory.Delete(directoryPath, true);
                }
            }

            foreach (var file in filesToDelete)
            {
                string filePath = Path.Combine(sourceDir, file);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
        }

        /// <summary>
        /// 壓縮檔案
        /// </summary>
        public void FileToZip(string sourceDir, string descFile)
        {
            ZipFile.CreateFromDirectory(sourceDir, descFile, CompressionLevel.Optimal, true);
        }

        /// <summary>
        /// 移動檔案
        /// </summary>
        public void MoveFile(string sourceFileName, string destFileName)
        {
            if (File.Exists(destFileName))
            {
                File.Delete(destFileName);
            }

            File.Move(sourceFileName, destFileName);
        }

        /// <summary>
        /// 新增資料夾
        /// </summary>
        public void CreateDirectory(string dirName)
        {
            if (Directory.Exists(dirName))
            {
                Directory.Delete(dirName, true);
            }

            Directory.CreateDirectory(dirName);
        }

        /// <summary>
        /// 移動資料夾
        /// </summary>
        public void MoveDirectory(string sourceDirName, string destDirName)
        {
            if (Directory.Exists(destDirName))
            {
                Directory.Delete(destDirName, true);
            }

            Directory.Move(sourceDirName, destDirName);
        }

        /// <summary>
        /// 刪除資料夾
        /// </summary>
        public void DelDirectory(string sourceDir, string[] directoriesToDelete)
        {
            foreach (var directory in directoriesToDelete)
            {
                string directoryPath = Path.Combine(sourceDir, directory);
                if (Directory.Exists(directoryPath))
                {
                    Directory.Delete(directoryPath, true);
                }
            }
        }

    }
}
