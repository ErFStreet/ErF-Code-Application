namespace Service.Contracts;

public interface IMusicService
{
    Task CreateAsync(CreateMusicViewModel viewModel);

    Task<EditMusicViewModel?> GetMusicForEditById(int id);

    Task EditAsync(EditMusicViewModel viewModel);

    Task DeleteAsync(int id);

    Task<List<ListMusicViewModel>> GetAll();
}
