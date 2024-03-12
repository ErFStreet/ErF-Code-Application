namespace Domain.ViewModels.Music;

public class CreateMusicViewModel
{
    public CreateMusicViewModel()
    {
    }

    public required string Title { get; set; }

    public required string SignerName { get; set; }

    public required string MusicUrl { get; set; }
}
