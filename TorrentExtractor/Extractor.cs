using SevenZip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorrentExtractor
{
    public static class Extractor
    {
        private const string SEVENZIP_PATH = @"C:\Program Files\7-Zip\7z.dll";
        private const string EXTRACT_DIR = @"C:\Test2";

        public static void Extract(string fileName)
        {
            SevenZipBase.SetLibraryPath(SEVENZIP_PATH);
            SevenZipExtractor extractor = new SevenZipExtractor(fileName);
            extractor.ExtractArchive(EXTRACT_DIR);
        }
    }
}
