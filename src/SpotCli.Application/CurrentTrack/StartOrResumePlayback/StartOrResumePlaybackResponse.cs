namespace SpotCli.Application.CurrentTrack.StartOrResumePlayback;

public class StartOrResumePlaybackResponse
{
    private readonly static string RESPONSE_MESSAGE = "Playback started.";
    public override string ToString()
    {
        return RESPONSE_MESSAGE;
    }
}