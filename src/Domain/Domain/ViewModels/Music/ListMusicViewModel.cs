namespace Domain.ViewModels.Music;

public class ListMusicViewModel
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public required string SignerName { get; set; }

    public required string MusicUrl { get; set; }
}
