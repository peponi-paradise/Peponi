using System.Threading;

namespace Peponi.Core.Helpers
{
    public static class DirectoryHelper
    {
        public static void CreateDirectory(string path)
        {
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);

                // 바로 만들어지지 않더라..
                Thread.Sleep(100);
            }
        }
    }
}