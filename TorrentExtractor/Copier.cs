using SevenZip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TorrentExtractor
{
    public static class Copier
    {
        //private const string DestinationRoot = @"\\Raspberrypi\tv\";
        private const string DestinationRoot = @"\\Raspberrypi\Music\";
        private static readonly Regex SeriesRegex = new Regex(@"([\w\.]*)\.s(\d\d)e(\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Dictionary<string, string> FolderMappings = new Dictionary<string, string>
        {
            {  "marvels.agents.of.s.h.i.e.l.d", "Agents Of S.H.E.I.L.D" },
            {  "arrow", "Arrow" },
            {  "dcs.legends.of.tomorrow", "Legends Of Tomorrow" },
            {  "supergirl", "Supergirl" },
            {  "the.flash.2014", "The Flash" },
            {  "the.originals", "The Originals" }
        };

        public static void Copy(string fileName, bool move = true)
        {
            var destinationDescriptor = SplitFilename(fileName);
            var destPath = GenerateDestinationPath(destinationDescriptor);
            (new FileInfo(destPath)).Directory.Create();
            File.Copy(fileName, destPath);
            if (move)
            {
                File.Delete(fileName);
            }
        }

        private static TVDescriptor SplitFilename(string path)
        {
            var filename = path.Split('\\').Last();
            var results = SeriesRegex.Match(filename);
            return new TVDescriptor
            {
                Name = results.Groups[1].Value,
                Series = results.Groups[2].Value,
                Episode = results.Groups[3].Value,
                Extension = filename.Split('.').Last()
            };
        }

        private static string GenerateDestinationPath(TVDescriptor desc)
        {
            return $@"{DestinationRoot}\{FolderMappings[desc.Name.ToLower()]}\S{desc.Series}\{desc.FileName}";
        }
    }
}
