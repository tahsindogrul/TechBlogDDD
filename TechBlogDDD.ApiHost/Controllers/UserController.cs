using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechBlogDDD.ApiHost.Helpers;
using TechBlogDDD.Application.Contract.User.Command;
using TechBlogDDD.Application.Contract.User.Queries;
using TechBlogDDD.Core.Common;

namespace TechBlogDDD.ApiHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [JwtTokenFilter]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [Authorize(Roles = "Admin,Member")]
        [HttpPost("getUser")]
        public async Task<GeneralResponse<GetUserQueryResponse>> GetUser([FromBody] GetUserQueryRequest request)
        {
            GeneralResponse<GetUserQueryResponse> response = await _mediator.Send(request);
            return response;
        }

        [Authorize(Roles ="Admin")]
        [HttpPost("deleteUser")]
        public async Task<GeneralResponse<DeleteUserCommandResponse>> DeleteUser([FromBody] DeleteUserCommandRequest request)
        {
            GeneralResponse<DeleteUserCommandResponse> response= await _mediator.Send(request);
            return response;
        }

        [Authorize(Roles ="Admin,Member")]
        [HttpPost("updateUser")]
        public async Task<GeneralResponse<UpdateUserCommandResponse>> UpdateUser([FromBody]  UpdateUserCommandRequest request)
        {
            GeneralResponse<UpdateUserCommandResponse> response = await _mediator.Send(request);
            return response;
        }




    }
}
