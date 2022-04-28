using MediatR.Pipeline;
using SpotCli.Application.Search.SearchForItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Search.SearchForItem;

public class PostProcessSearchForItemBeforeStartOrResumePlayback : IRequestPostProcessor<SearchForItemBeforeStartOrResumePlaybackRequest, SearchForItemResponse>
{
    public Task Process(SearchForItemBeforeStartOrResumePlaybackRequest request, SearchForItemResponse response, CancellationToken cancellationToken)
    {
        Console.WriteLine("Postprocessor reached.");
        return Task.CompletedTask;
    }
}
