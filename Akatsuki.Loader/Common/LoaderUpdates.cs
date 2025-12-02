using System.Collections.Generic;

namespace PatcherPlus.Loader.Common
{
    public class LoaderUpdates
    {
        public LoaderVersionInfo Loader { get; set; }

        public IEnumerable<BranchVersionInfo> Branches { get; set; }
    }

}
