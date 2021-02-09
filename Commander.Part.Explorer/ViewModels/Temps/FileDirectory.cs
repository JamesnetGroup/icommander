using Commander.Data.File;
using Commander.OperationSystem.Windows;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Commander.Part.Explorer.ViewModels.Temps
{

    public class FileDirectory
    {
        private static readonly SystemIcon sysIcons = new SystemIcon();

        public static bool IsError = false;

        static string _ErrorMessage;
        public static string ErrorMessage
        {
            get { IsError = false; return _ErrorMessage; }
            set { _ErrorMessage = value; }
        }

        public static List<FileData> GetCurrentData(string path, bool isParent = false)
        {
            try
            {
                var source = new List<FileData>();
                DirectoryInfo dInfo = new DirectoryInfo(path);
                DirectoryInfo[] subdirs = dInfo.GetDirectories();

                if (isParent == true)
                {
                    var dir = Directory.GetParent(path);

                    if (dir != null)
                        source.Add(FileData.ParentDir(dir));
                }

                foreach (var dir in subdirs)
                {
                    var newDir = new FileData();

                    if (dir.Attributes.HasFlag(FileAttributes.Hidden))
                        newDir.FileType = FileTypes.HiddenDirectory;
                    else
                        newDir.FileType = FileTypes.Directory;

                    newDir.FullName = dir.FullName;
                    newDir.FileName = Path.GetFileName(dir.FullName);
                    newDir.Extension = dir.Extension;
                    newDir.FileSize = null;
                    newDir.LastAccessTime = dir.LastAccessTime.ToString("yyyy-MM-dd HH:mm:ss");
                    newDir.LastWriteTime = dir.LastWriteTime.ToString();

                    var icon = sysIcons.GetIconIndex(dir.FullName);
                    ImageList smi = sysIcons.SmallIconsImageList;
                    var a = Icon.FromHandle(((Bitmap)smi.Images[icon]).GetHicon());
                    newDir.IconSource = ImageGenerator.ToImageSource(a);
                    source.Add(newDir);
                }

                FileInfo[] subFiles = dInfo.GetFiles();

                foreach (var file in subFiles)
                {
                    var newFile = new FileData();

                    if (file.Attributes.HasFlag(FileAttributes.Hidden))
                        newFile.FileType = FileTypes.Hidden;
                    else
                        newFile.FileType = FileTypes.File;

                    newFile.FullName = file.FullName;
                    newFile.FileName = Path.GetFileName(file.FullName);
                    newFile.Extension = file.Extension;
                    newFile.FileSize = file.Length;
                    newFile.LastAccessTime = file.LastAccessTime.ToString("yyyy-MM-dd HH:mm:ss");
                    newFile.LastWriteTime = file.LastWriteTime.ToString();

                    var icon = sysIcons.GetIconIndex(file.FullName);
                    ImageList smi = sysIcons.SmallIconsImageList;
                    var a = Icon.FromHandle(((Bitmap)smi.Images[icon]).GetHicon());
                    newFile.IconSource = ImageGenerator.ToImageSource(a);
                    source.Add(newFile);
                }

                return source;
            }
            catch (UnauthorizedAccessException)
            {
                FileDirectory.IsError = true;
                FileDirectory.ErrorMessage = string.Format("Unable to access directory {0}", path);
                //Handle any desired logging here
            }
            return new List<FileData>();
        }
    }
}
