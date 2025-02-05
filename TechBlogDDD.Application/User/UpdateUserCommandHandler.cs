using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogDDD.Application.Contract.User.Command;
using TechBlogDDD.Core.Common;
using TechBlogDDD.Domain.Entity;
using TechBlogDDD.Domain.Repository;

namespace TechBlogDDD.Application.User
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, GeneralResponse<UpdateUserCommandResponse>>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GeneralResponse<UpdateUserCommandResponse>> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response= new GeneralResponse<UpdateUserCommandResponse>();
            response.Value= new UpdateUserCommandResponse();

            var result = await _userRepository.UpdateAsync(new Domain.Entity.User
            {
                Id = request.UserId,
                FullName = request.FullName,
                Password = request.Password,
                Email = request.Email,
                Gender = request.Gender,
                About = request.About
            });

            if (!result.Success)
            {
                response.Success = result.Success;
                response.ErrorMessage = result.ErrorMessage;
                return await Task.FromResult(response);
            }

            response.Success = true;
            response.InfoMessage = "User info successfully updated!";

            return await Task.FromResult(response);
        }
    }
}
