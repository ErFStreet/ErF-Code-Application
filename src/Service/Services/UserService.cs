namespace Service.Services;

public class UserService : IUserService
{
    private readonly IRepository<User> repository;

    public UserService(IRepository<User> repository)
    {
        this.repository = repository;
    }

    public async Task RegisterAsync(RegisterUserViewModel viewModel)
    {
        if (viewModel is null)
        {
            throw new ArgumentNullException(nameof(viewModel));
        }

        var user = new User(fullName: viewModel.FullName)
        {
            Email = viewModel.Email,
            HashedPassword = viewModel.Password,
            RoleId = (int)RolesEnum.User,
            IsActived = true
        };

        await repository.CreateAsync(user);
    }

    public async Task<ResponseUserViewModel?> LoginAsync(LoginUserViewModel viewModel)
    {
        if (viewModel is null)
        {
            return null;
        }

        var result =
            await repository.GetQueryable()
            .Where(current => current.Email == viewModel.Email)
            .Where(current => current.HashedPassword == viewModel.Password)
            .Where(current => current.IsActived)
            .Select(current => new ResponseUserViewModel
            {
                Id = current.RoleId,
                FullName = current.FullName,
                Email = current.Email,
                RoleId = current.RoleId,
            })
            .FirstOrDefaultAsync();

        return result;
    }
}
