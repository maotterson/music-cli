public class ParsedTrack
{
    public string? Artist { get; set; }
    public string? Name { get; set; }

    public string ToSearchQuery()
    {
        return $"{Artist} - {Name}";
    }
}