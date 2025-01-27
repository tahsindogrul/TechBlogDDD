using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogDDD.Core.Common;
using TechBlogDDD.Domain.Repository;
using TechBlogDDD.Core.Helpers;
using TechBlogDDD.Application.Contract.Register.Commands;



namespace TechBlogDDD.Application.Register
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, GeneralResponse<CreateUserCommandResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepositoryAsync _userRoleRepository;
        private readonly IRoleRepositoryAsync _roleRepository;

        public CreateUserCommandHandler(IUserRepository userRepository, IRoleRepositoryAsync roleRepository, IUserRoleRepositoryAsync userRoleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
        }

        public async Task<GeneralResponse<CreateUserCommandResponse>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<CreateUserCommandResponse>();
            response.Value = new CreateUserCommandResponse();

            if (string.IsNullOrEmpty(request.FullName) || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                response.Success = false;
                response.ErrorMessage = "Please check input for not null!";
                return await Task.FromResult(response);
            }

            if (!request.Email.CheckEmail())
            {
                response.Success = false;
                response.ErrorMessage = "Please check email format!";
                return await Task.FromResult(response);
            }

            var user = await _userRepository.AddAsync(new Domain.Entity.User
            {
                FullName = request.FullName,
                Password = request.Password,
                Email = request.Email,
                IsActive = true,
            });

            if (!user.Success)
            {
                response.Success=user.Success;
                response.ErrorMessage =user.ErrorMessage;
                return await Task.FromResult(response);
            }

            var userRole = await _userRoleRepository.AddAsync(new Domain.Entity.UserRole
            {
                UserId = user.Value.Id,
                RoleId = 2,           
                IsActive = true
            });

            if (!userRole.Success)
            {
                response.Success = userRole.Success;
                response.ErrorMessage = userRole.ErrorMessage;
                return await Task.FromResult(response);
            }


            var roles = await _roleRepository.GetAllByIdAsync(user.Value.Id);

            if (!roles.Success)
            {
                response.Success = roles.Success;
                response.ErrorMessage = roles.ErrorMessage;
                return await Task.FromResult(response);
            }

            response.Success = true;
            response.InfoMessage = "Başarılı";
            response.Value.UserId = user.Value.Id;
            response.Value.RoleList = new List<string>();
            foreach (var role in roles.Value)
            {
                response.Value.RoleList.Add(role.RoleName);
            }
            response.Value.FullName = user?.Value?.FullName ?? string.Empty;

            return await Task.FromResult(response);
        }
    }
}
