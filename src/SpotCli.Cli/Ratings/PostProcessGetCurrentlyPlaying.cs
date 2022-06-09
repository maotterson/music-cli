using MediatR.Pipeline;
using SpotCli.Application.CurrentTrack.GetCurrentlyPlaying;
using SpotCli.Application.Ratings.CreateOrModifyRating;
using SpotCli.Cli.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Ratings;
public class PostProcessGetCurrentlyPlaying : IRequestPostProcessor<GetCurrentlyPlayingRequest, GetCurrentlyPlayingResponse>
{
    private readonly IRatingCurrentTrackState _ratingCurrentTrackState;
    private readonly IRequestQueue _requestQueue;

    public PostProcessGetCurrentlyPlaying(IRatingCurrentTrackState ratingCurrentTrackState, IRequestQueue requestQueue)
    {
        _ratingCurrentTrackState = ratingCurrentTrackState;
        _requestQueue = requestQueue;
    }

    public Task Process(GetCurrentlyPlayingRequest request, GetCurrentlyPlayingResponse response, CancellationToken cancellationToken)
    {
        if (_ratingCurrentTrackState.IsGettingCurrentTrackForRating())
        {
            var createOrModifyRatingRequestBody = new CreateOrModifyRatingRequestBody
            {
                SpotifyId = response.Item.Id,
                Artist = response.Item.Artists.FirstOrDefault()!.Name,
                Album = response.Item.Album.Name,
                Track = response.Item.Name,
                Rating = _ratingCurrentTrackState.GetRating()
                
            };
            var createOrModifyRatingRequest = new CreateOrModifyRatingRequest(createOrModifyRatingRequestBody);

            _requestQueue.Enqueue(createOrModifyRatingRequest);
        }

        return Task.CompletedTask;
    }
}
