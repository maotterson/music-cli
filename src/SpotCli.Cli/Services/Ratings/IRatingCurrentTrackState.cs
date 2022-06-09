using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Services.Ratings;
public interface IRatingCurrentTrackState
{
    public bool IsGettingCurrentTrackForRating();
    public void RateCurrentTrack();
}
