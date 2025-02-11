using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechBlogDDD.Application.Contract.Category.Commands;
using TechBlogDDD.Application.Contract.Category.Queries;
using TechBlogDDD.Core.Common;

namespace TechBlogDDD.ApiHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [Authorize(Roles ="Admin")]
        [HttpPost("addCategory")]
        public async Task<GeneralResponse<CreateCategoryCommandResponse>> AddCategory([FromBody]  CreateCategoryCommandRequest request)
        {
            GeneralResponse<CreateCategoryCommandResponse> response=await _mediator.Send(request);
            return response;
        }

        [AllowAnonymous]
        [HttpPost("getCategory")]
        public async Task<GeneralResponse<GetCategoryQueryResponse>> GetCategory([FromBody] GetCategoryQueryRequest request)
        {
            GeneralResponse<GetCategoryQueryResponse> response=await _mediator.Send(request);
            return response;
        }

    }
}
