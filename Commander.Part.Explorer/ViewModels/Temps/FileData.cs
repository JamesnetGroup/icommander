
using System.IO;

namespace Commander.Part.Explorer.ViewModels.Temps
{
    public class FileData
    {
        public string Extension { get; set; }
        public string FileName { get; set; }
        public long? FileSize { get; set; }
        public FileTypes FileType { get; set; }
        public string FullName { get; set; }
        public System.Windows.Media.ImageSource IconSource { get; set; }
        public bool IsEditMode { get; set; }
        public bool IsReadOnly { get { return IsEditMode == true ? false : true; } }
        public string LastAccessTime { get; set; }
        public string LastWriteTime { get; set; }

        public static FileData ParentDir(DirectoryInfo dir)
        {
            var parent = new FileData();
            parent.FileType = FileTypes.Parent;
            parent.FileName = "..";
            parent.FullName = dir.FullName;
            parent.FileSize = null;
            return parent;
        }
    }
}
