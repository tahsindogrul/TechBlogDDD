using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechBlogDDD.Application.Contract.Post.Commands;
using TechBlogDDD.Application.Contract.Post.Queries;
using TechBlogDDD.Core.Common;

namespace TechBlogDDD.ApiHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [Authorize(Roles ="Admin,Member")]
        [HttpPost("addPost")]
        public async Task<GeneralResponse<CreatePostCommandResponse>> AddPost([FromBody] CreatePostCommandRequest request)
        {
            GeneralResponse<CreatePostCommandResponse> response = await _mediator.Send(request);
            return response;
        }

        [Authorize(Roles ="Admin,Member")]
        [HttpPost("deletePost")]
        public async Task<GeneralResponse<DeletePostCommandResponse>> DeletePost([FromBody]DeletePostCommandRequest request)
        {
            GeneralResponse<DeletePostCommandResponse> response= await _mediator.Send(request);
            return response;
        }

        [Authorize(Roles ="Admin,Member")]
        [HttpPost("updatePost")]
        public async Task<GeneralResponse<UpdatePostCommandResponse>> UpdatePost([FromBody] UpdatePostCommandRequest request)
        {
            GeneralResponse<UpdatePostCommandResponse> response= await _mediator.Send(request);
            return response;
        }

        [AllowAnonymous]
        [HttpPost("getPostDetailsById")]
        public async Task<GeneralResponse<GetPostDetailsByIdQueryResponse>> GetPostDetailsById([FromBody] GetPostDetailsByIdQueryRequest request)
        {
            GeneralResponse<GetPostDetailsByIdQueryResponse> response= await _mediator.Send(request);
            return response;
        }

        [AllowAnonymous]
        [HttpPost("getPost")]
        public async Task<GeneralResponse<List<GetPostQueryResponse>>> GetPost([FromBody] GetPostQueryRequest request)
        {
            GeneralResponse<List<GetPostQueryResponse>> response = await _mediator.Send(request);
            return response;
        }

        [AllowAnonymous]
        [HttpPost("getPostsByCategoryId")]
        public async Task<GeneralResponse<List<GetPostsByCategoryIdQueryResponse>>> GetPostsByCategoryId([FromBody] GetPostsByCategoryIdQueryRequest request)
        {
            GeneralResponse<List<GetPostsByCategoryIdQueryResponse>> response = await _mediator.Send(request);
            return response;
        }


    }
}
