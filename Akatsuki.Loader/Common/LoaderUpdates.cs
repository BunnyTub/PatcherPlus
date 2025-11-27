using System.Collections.Generic;

namespace Akatsuki.Loader.Common
{
    public class LoaderUpdates
    {
        public LoaderVersionInfo Loader { get; set; }

        public IEnumerable<BranchVersionInfo> Branches { get; set; }
    }

}
