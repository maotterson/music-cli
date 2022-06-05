using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsumeLambdaWithIAMAuth.Apis;
public interface ILambdaApi
{
    [Get("/")]
    Task<IApiResponse<ICollection<RatingDto>>> GetRatings();
}

public class RatingDto
{
    [JsonPropertyName("artist")]
    public string Artist { get; set; }
}