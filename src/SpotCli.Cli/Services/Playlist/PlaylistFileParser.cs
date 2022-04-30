using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Services.Playlist;

public class PlaylistFileParser : IPlaylistFileParser
{
    public void ParseFile(string filePath)
    {
        using (StreamReader sr = new StreamReader(File.OpenRead(filePath)))
        {
            string file = sr.ReadToEnd();
            Console.WriteLine(file);
        }
    }
}
