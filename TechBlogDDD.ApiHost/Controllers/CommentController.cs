using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechBlogDDD.Application.Contract.Comment.Commands;
using TechBlogDDD.Core.Common;

namespace TechBlogDDD.ApiHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Admin,Member")]
        [HttpPost("addComment")]
        public async Task<GeneralResponse<CreateCommentCommandResponse>> AddComment([FromBody] CreateCommentCommandRequest request)
        {
            GeneralResponse<CreateCommentCommandResponse> response = await _mediator.Send(request);
            return response;
        }


        [Authorize(Roles = "Admin,Member")]
        [HttpPost("deleteComment")]
        public async Task<GeneralResponse<DeleteCommentCommandResponse>> DeleteComment([FromBody] DeleteCommentCommandRequest request)
        {
            GeneralResponse<DeleteCommentCommandResponse> response = await _mediator.Send(request);
            return response;
        }

        [Authorize(Roles = "Admin,Member")]
        [HttpPost("updateComment")]
        public async Task<GeneralResponse<UpdateCommentCommandResponse>> UpdateComment([FromBody] UpdateCommentCommandRequest request)
        {
            GeneralResponse<UpdateCommentCommandResponse> response = await _mediator.Send(request);
            return response;
        }
    }
}
