using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Services.Ratings;
public class RatingCurrentTrackState : IRatingCurrentTrackState
{
    private bool isGettingCurrentTrack = false;
    public bool IsGettingCurrentTrackForRating()
    {
        return isGettingCurrentTrack;
    }

    public void RateCurrentTrack()
    {
        isGettingCurrentTrack = true;
    }
}
