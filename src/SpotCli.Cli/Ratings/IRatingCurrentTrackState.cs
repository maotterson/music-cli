using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Ratings;
public interface IRatingCurrentTrackState
{
    bool IsGettingCurrentTrackForRating();
    void RateCurrentTrack(int rating);
    int GetRating();
}
