using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorrentExtractor
{
    public interface IOnChanged
    {
        void OnChanged(string path);
    }
}
