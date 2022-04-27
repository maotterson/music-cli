namespace SpotCli.Application.Utils;

public static class SpotifyContextUriBuilder
{
    public static string GetTrackContextUriFromId(string id)
    {
        return $"spotify:track:{id}";
    }
}
