using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorrentExtractor
{
    class Program
    {
        private static readonly string[] videoFiles = new[]
        {
            "mkv",
            "avi",
            "mp4"
        };

        static void Main(string[] args)
        {
            new FileNotifier(@"C:\Test\", new ExtractionOnChanged(),null, "rar");
            new FileNotifier(@"C:\Test\", new CopierOnChanged(false),System.IO.NotifyFilters.LastWrite, videoFiles);
            new FileNotifier(@"C:\Test2\", new CopierOnChanged(true), System.IO.NotifyFilters.LastWrite, videoFiles);
            new System.Threading.AutoResetEvent(false).WaitOne();
        }
    }
}
