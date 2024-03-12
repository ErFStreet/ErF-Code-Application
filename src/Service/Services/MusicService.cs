namespace Service.Services;

public class MusicService : IMusicService
{
    private readonly IRepository<Music> repository;

    public MusicService(IRepository<Music> repository)
    {
        this.repository = repository;
    }

    public async Task CreateAsync(CreateMusicViewModel viewModel)
    {
        if (viewModel is null)
            throw new ArgumentNullException(nameof(viewModel));

        var music = new Music(title: viewModel.Title)
        {
            SingerName = viewModel.SignerName,
            MusicUrl = viewModel.MusicUrl,
        };

        await repository.CreateAsync(entity: music);
    }

    public async Task<EditMusicViewModel?> GetMusicForEditById(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        var result =
            await repository.GetQueryable()
            .Where(current => current.Id == id)
            .Select(current => new EditMusicViewModel
            {
                Id = current.Id,
                Title = current.Title,
                SignerName = current.SingerName,
                MusicUrl = current.MusicUrl,
            })
            .FirstOrDefaultAsync();

        return result;
    }

    public async Task EditAsync(EditMusicViewModel viewModel)
    {
        if (viewModel is null)
            throw new ArgumentNullException(nameof(viewModel));

        var music =
            await repository.GetByIdAsync(id: viewModel.Id);

        if (music is null)
            throw new ArgumentNullException(nameof(music));

        music.Title = viewModel.Title;

        music.SingerName = viewModel.SignerName;

        music.MusicUrl = viewModel.MusicUrl;

        repository.Update(entity: music);
    }

    public async Task DeleteAsync(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        var music =
            await repository.GetByIdAsync(id: id);

        if (music is null)
            throw new ArgumentNullException(nameof(music));

        repository.Remove(entity: music);
    }

    public async Task<List<ListMusicViewModel>> GetAll()
    {
        var result =
            await repository.GetQueryable()
            .Where(current => !current.IsDeleted)
            .Select(current => new ListMusicViewModel
            {
                Id = current.Id,
                Title = current.Title,
                SignerName = current.SingerName,
                MusicUrl = current.MusicUrl
            })
            .ToListAsync();

        return result;
    }
}
