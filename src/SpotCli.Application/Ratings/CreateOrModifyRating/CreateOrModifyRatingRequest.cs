using MediatR;
using SpotCli.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Application.Ratings.CreateOrModifyRating;
public class CreateOrModifyRatingRequest : IRequest<CreateOrModifyRatingResponse>, IValidRequest
{
    public GetCurrentlyPlayingRequest(CreateOrModifyRatingRequestBody body)
    {
        Body = body;
    }
    public CreateOrModifyRatingRequestBody Body { get; init; }

    public string Description => "Create or modify rating.";
}
