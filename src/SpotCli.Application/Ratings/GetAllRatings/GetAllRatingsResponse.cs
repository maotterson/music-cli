using Newtonsoft.Json;
using SpotCli.Application.Dto;
using SpotCli.Application.Ratings.GetRating;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Application.Ratings.GetAllRatings;
public class GetAllRatingsResponse
{
    public IEnumerable<GetRatingResponse> Ratings { get; init; } = Enumerable.Empty<GetRatingResponse>();
}
