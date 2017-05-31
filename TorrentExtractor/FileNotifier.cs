using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorrentExtractor
{
    public class FileNotifier
    {
        private readonly IOnChanged _callback;
        private readonly FileSystemWatcher _watcher;
        private readonly string[] _types;

        public FileNotifier(string path, IOnChanged callBack, NotifyFilters? filters, params string[] fileTypes)
        {
            _callback = callBack;
            _types = fileTypes;
            _watcher = new FileSystemWatcher();
            _watcher.Path = path;
            if (filters.HasValue)
            {
                _watcher.NotifyFilter = filters.Value;
                _watcher.Changed += new FileSystemEventHandler(OnChanged);
            }
            else
            {
                _watcher.Created += new FileSystemEventHandler(OnChanged);
            }
            _watcher.Filter = "*";
            _watcher.IncludeSubdirectories = true;
            _watcher.EnableRaisingEvents = true;
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            var folder = e.FullPath;
            foreach (var fType in _types)
            {
                if (Directory.Exists(e.FullPath))
                {
                    var files = Directory.GetFiles(e.FullPath, $"*.{fType}");
                    foreach (var file in files)
                    {
                        if (File.Exists(file))
                        {
                            _callback.OnChanged(file);
                        }
                    }
                }
                else if (e.FullPath.EndsWith($".{fType}"))
                {
                    if (File.Exists(e.FullPath))
                    {
                        _callback.OnChanged(e.FullPath);
                    }
                }
            }
        }
    }
}
