using SpotCli.Application.CurrentTrack.GetCurrentlyPlaying;
using SpotCli.Cli.Options.CurrentTrack.GetCurrentlyPlaying;
using SpotCli.Cli.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Options.Ratings;
public class RatingOptionsMapper
{
    private readonly IRequestQueue _commandQueue;
    public RatingOptionsMapper(IRequestQueue commandQueue)
    {
        _commandQueue = commandQueue;
    }
    public void Map(RatingOptions options)
    {
        if(options.NewRating is not null)
        {
            var query = new CreateNewRatingQuery
            {
            };
        }
        var query = new GetCurrentlyPlayingRequestQuery
        {
        };
        var request = new GetCurrentlyPlayingRequest(query);
        _commandQueue.Enqueue(request);
    }
}
