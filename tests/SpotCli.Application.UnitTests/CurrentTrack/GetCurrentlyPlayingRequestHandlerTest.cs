using FluentAssertions;
using NSubstitute;
using Refit;
using SpotCli.Application.Apis;
using SpotCli.Application.CurrentTrack.GetCurrentlyPlaying;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using static SpotCli.Application.CurrentTrack.GetCurrentlyPlaying.GetCurrentlyPlayingResponse;

namespace SpotCli.Application.UnitTests.CurrentTrack;

public class GetCurrentlyPlayingRequestHandlerTest
{
    private readonly ISpotifyWebApi _spotifyWebApi;
    private readonly GetCurrentlyPlayingRequestHandler _sut;
    private readonly GetCurrentlyPlayingResponse _mockResponse;

    public GetCurrentlyPlayingRequestHandlerTest()
    {
        _spotifyWebApi = Substitute.For<ISpotifyWebApi>();
        _sut = new GetCurrentlyPlayingRequestHandler(_spotifyWebApi);
        _mockResponse = new()
        {
            Item = new()
            {
                Album = new Album { Name = "Once Twice Melody" },
                Artists = new[] { new Artist() { Name = "Beach House" } },
                Name = "Masquerade",
                TrackNumber = 11
            }
        };
    }

    [Fact]
    public async Task Handle_ShouldReturnSpecifiedCurrentlyPlayingResponse_WhenAValidResponseIsReturned()
    {
        // Arrange
        var request = new GetCurrentlyPlayingRequest(new GetCurrentlyPlayingRequestQuery());
        var httpResponseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        var refitSettings = new RefitSettings();

        var decoratedResponse = new ApiResponse<GetCurrentlyPlayingResponse>(httpResponseMessage, _mockResponse, refitSettings);
        _spotifyWebApi.GetCurrentlyPlaying(request.Query).Returns(decoratedResponse);

        // Act
        var actualDecoratedResponse = await _sut.Handle(request, new System.Threading.CancellationToken());

        // Assert
        actualDecoratedResponse.Should().BeEquivalentTo(decoratedResponse.Content);
    }
}
