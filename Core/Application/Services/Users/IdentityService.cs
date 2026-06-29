using Application.DTO;
using Application.Interfaces;

namespace Application.Services.Users
{
    public class IdentityService : IIdentityService
    {
        private readonly IIdentity _identityRepository;

        public IdentityService(IIdentity identityRepository)
        {
            _identityRepository = identityRepository;
        }

        public async Task<bool> LoginAsync(LoginDTO dto)
        {
            return await _identityRepository.LoginAsync(dto);
        }

        public async Task RegisterUser(RegisterUserDTO dto)
        {
            await _identityRepository.RegisterUser(dto);
        }

        public async Task<List<UserDetailDTO>> GetAllUsers()
        {
            return await _identityRepository.GetAllUsers();
        }

        public async Task<UserDetailDTO> GetUserById(int id)
        {
            return await _identityRepository.GetUserById(id);
        }

        public async Task UpdateUser(int id, UserDetailDTO dto)
        {
            await _identityRepository.UpdateUser(id, dto);
        }
    }
}
