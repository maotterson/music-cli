using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Ratings;
public class RatingCurrentTrackState : IRatingCurrentTrackState
{
    private bool _isGettingCurrentTrack = false;
    private int _rating;
    public bool IsGettingCurrentTrackForRating()
    {
        return _isGettingCurrentTrack;
    }

    public void RateCurrentTrack(int rating)
    {
        _isGettingCurrentTrack = true;
        _rating = rating;
    }

    public int GetRating()
    {
        return _rating;
    }
}
