
using System.Security.Permissions;
using System.Threading;

namespace Commander.Part.Explorer.ViewModels.Temps
{
    public class ExplorerRefreshWorker
    {
        private volatile bool _shouldStop;
        readonly ExplorerViewModel explorer;

        public ExplorerRefreshWorker(ExplorerViewModel _vm)
        {
            this.explorer = _vm;
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public void DoWork()
        {
            while (!_shouldStop)
            {
                if (explorer.IsExplorerUpdated)
                {
                    explorer.Refresh();
                    explorer.IsExplorerUpdated = false;
                }

                Thread.Sleep(50);
            }
        }

        public void RequestStop()
        {
            _shouldStop = true;
        }
    }
}