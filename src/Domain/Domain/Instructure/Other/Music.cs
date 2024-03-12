namespace Domain.Instructure.Other;

public class Music : BaseEntity<int>, IEntityHasIsDeleted
{
    public Music(string title)
    {
        Title = title;
    }

    public string Title { get; set; }

    public required string SingerName { get; set; }

    public required string MusicUrl { get; set; }

    public bool IsDeleted { get; set; }
}
