using SpotCli.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Core.Entities;
public class TrackRating
{
    public string Id { get; init; } = ""; // todo required keyword in c#11
    public RatingVO? Rating { get; init; }
    public SpotifyIdVO? SpotifyId { get; init; }
    public ArtistVO? Artist { get; init; }
    public TrackVO? Track { get; init; }
    public AlbumVO? Album { get; init; }
}
