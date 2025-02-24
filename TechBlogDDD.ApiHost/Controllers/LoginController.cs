using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechBlogDDD.ApiHost.Helpers;
using TechBlogDDD.Application.Contract.Login.Queries;
using TechBlogDDD.Core.Common;

namespace TechBlogDDD.ApiHost.Controllers
{
    [Route("api([controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<GeneralResponse<GetLoginQueryResponse>> Login([FromBody] GetLoginQueryRequest request)
        {
            GeneralResponse<GetLoginQueryResponse> response= await _mediator.Send(request);
            if (response.Success)
            {
                request.UserId =response.Value.UserId;
                request.FullName = response.Value.FullName;
                string token = TechBlogHelper.GenerateToken(request,response.Value.RoleList);
                response.Value.Token = token;
            }
            return response;
        }
    }
}
