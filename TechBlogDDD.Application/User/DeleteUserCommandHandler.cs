using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogDDD.Application.Contract.User.Command;
using TechBlogDDD.Core.Common;
using TechBlogDDD.Domain.Repository;

namespace TechBlogDDD.Application.User
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, GeneralResponse<DeleteUserCommandResponse>>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GeneralResponse<DeleteUserCommandResponse>> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response= new GeneralResponse<DeleteUserCommandResponse>();
           response.Value= new DeleteUserCommandResponse();

            var result = await _userRepository.DeleteAsync(new Domain.Entity.User
            {
                Id = request.UserId,
            });
            if(!result.Success)
            {
                response.Success = result.Success;
                response.ErrorMessage = result.ErrorMessage;
                return await Task.FromResult(response);
            }
            response.Success = true;
            response.InfoMessage = "User successfully deleted";
            return await Task.FromResult(response);
        }
    }
}
