using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorrentExtractor
{
    public class CopierOnChanged : IOnChanged
    {
        private readonly bool _move;

        public CopierOnChanged(bool move)
        {
            _move = move;
        }

        public void OnChanged(string path)
        {
            Copier.Copy(path, _move);
        }
    }
}
