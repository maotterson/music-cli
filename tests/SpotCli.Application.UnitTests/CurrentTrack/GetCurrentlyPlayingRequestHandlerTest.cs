using NSubstitute;
using SpotCli.Application.Apis;
using SpotCli.Application.CurrentTrack.GetCurrentlyPlaying;
using Xunit;

namespace SpotCli.Application.UnitTests.CurrentTrack;

public class GetCurrentlyPlayingRequestHandlerTest
{
    private readonly ISpotifyWebApi _spotifyWebApi;
    private readonly GetCurrentlyPlayingRequestHandler _sut;

    public GetCurrentlyPlayingRequestHandlerTest()
    {
        _spotifyWebApi = Substitute.For<ISpotifyWebApi>();
        _sut = new GetCurrentlyPlayingRequestHandler(_spotifyWebApi);
    }


    [Fact]
    public void Handle_ShouldX_WhenY()
    {
        // Arrange

        // Act

        // Assert

    }
}
