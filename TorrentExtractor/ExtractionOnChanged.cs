using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorrentExtractor
{
    public class ExtractionOnChanged : IOnChanged
    {
        public void OnChanged(string path)
        {
            Extractor.Extract(path);
        }
    }
}
