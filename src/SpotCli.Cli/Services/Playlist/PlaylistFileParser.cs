using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Services.Playlist;

public class PlaylistFileParser : IPlaylistFileParser
{
    private delegate string[] ParsingMethod(string raw);
    public IList<ParsedTrack> ParseFile(string filePath)
    {
        IList<ParsedTrack> tracklist = new List<ParsedTrack>();
        ParsingMethod parsingMethod = GetParsingMethod(filePath);

        using (StreamReader sr = new StreamReader(File.OpenRead(filePath)))
        {
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine()!;
                var track = ParseTrack(line, parsingMethod);
                tracklist.Add(track);
            }
        }

        return tracklist;
    }
    
    private ParsingMethod GetParsingMethod(string filePath)
    {
        var fileExtension = filePath.Split(".")[1];
        if(fileExtension is "csv")
        {
            return (raw) => raw.Split(",");
        }
        return (raw) => raw.Split(" - ");
    }


    private ParsedTrack ParseTrack(string raw, ParsingMethod method)
    {
        var split = method(raw);
        var track = new ParsedTrack()
        {
            Artist = split[0],
            Name = split[1],
        };
        return track;
    }

    
}
