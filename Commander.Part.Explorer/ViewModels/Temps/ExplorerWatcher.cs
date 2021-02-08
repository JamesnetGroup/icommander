using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Commander.Part.Explorer.ViewModels.Temps
{
    public class ExplorerWatcher
    {
        private ExplorerViewModel explorer;
        private FileSystemWatcher watcher;

        public ExplorerWatcher(ExplorerViewModel _vm)
        {
            this.explorer = _vm;
        }

        internal void ChangeWatchPath(string path)
        {
            watcher.Path = path;
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        internal void Run()
        {
            // Create a new FileSystemWatcher and set its properties.
            watcher = new FileSystemWatcher();
            watcher.Path = explorer.CurrentFile.FullName;
            /* Watch for changes in LastAccess and LastWrite times, and
               the renaming of files or directories. */
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // Only watch text files.
            //watcher.Filter = "*.txt";

            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            // Begin watching.
            watcher.EnableRaisingEvents = true;

            //// Wait for the user to quit the program.
            //Console.WriteLine("Press \'q\' to quit the sample.");
            //while (Console.Read() != 'q') ;
        }

        internal void RequestStop()
        {
            watcher.Dispose();
        }

        // Define the event handlers.
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);

            explorer.IsExplorerUpdated = true;
            Thread.Sleep(200);
        }

        private void OnRenamed(object source, RenamedEventArgs e)
        {
            // Specify what is done when a file is renamed.
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);

            explorer.IsExplorerUpdated = true;
            Thread.Sleep(200);
        }
    }
}