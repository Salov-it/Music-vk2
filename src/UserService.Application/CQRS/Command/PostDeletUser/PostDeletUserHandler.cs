using UserService.Application.Interface;
using MediatR;

namespace UserService.Application.CQRS.Command.PostDeletUser
{
    public class PostDeletUserHandler : IRequestHandler<PostDeletUserCommanda, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserContext _userContext;
        public string Status { get; set; }

        public PostDeletUserHandler(IUserRepository userRepository, IUserContext userContext)
        {
            _userRepository = userRepository;
            _userContext = userContext;
        }

        public async Task<string> Handle(PostDeletUserCommanda request, CancellationToken cancellationToken)
        {
            var users =  _userContext.user.FirstOrDefault();
            if (users != null)
            {
                 _userContext.user.Remove(users);
                _userRepository.SaveChangesAsync();
                return Status = "Выполнено";
            }
            else
            {
                return Status = "Ошибка:  Users = await _userRepository.GetAllAsync() ";
            }
            return Status;
        }

    }
}
