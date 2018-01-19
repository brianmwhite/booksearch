using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using bs.EpubSharp.Format.Readers;

namespace bs
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var targetFiles = Directory.GetFiles(args[0], "metadata.opf", SearchOption.AllDirectories);
            foreach (var file in targetFiles)
            {
                using (var stream = File.OpenRead(file))
                {
                    var xd = XDocument.Load(stream);
                    var opf = OpfReader.Read(xd);
                    var title = opf.Metadata.Titles.FirstOrDefault();
                    var author = opf.Metadata.Creators.FirstOrDefault()?.Text;
                    
                    Console.WriteLine($"{title}\t{author}");
                }
            }
        }
    }
}
