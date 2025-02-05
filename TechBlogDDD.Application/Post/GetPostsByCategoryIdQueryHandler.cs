using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogDDD.Application.Contract.Post.Queries;
using TechBlogDDD.Core.Common;
using TechBlogDDD.Domain.Repository;

namespace TechBlogDDD.Application.Post
{
    public class GetPostsByCategoryIdQueryHandler : IRequestHandler<GetPostsByCategoryIdQueryRequest, GeneralResponse<List<GetPostsByCategoryIdQueryResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        public GetPostsByCategoryIdQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<GeneralResponse<List<GetPostsByCategoryIdQueryResponse>>> Handle(GetPostsByCategoryIdQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<List<GetPostsByCategoryIdQueryResponse>>();
            response.Value = new List<GetPostsByCategoryIdQueryResponse>();

            if (request.CategoryId != null)
            {
                var post = await _postRepository.GetPostsByCategoryIdAsync(request.CategoryId);

                if (!post.Success)
                {
                    response.Success = post.Success;
                    response.ErrorMessage = post.ErrorMessage;
                    return await Task.FromResult(response);

                }
                if (post.Value == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Posts not found";
                    return await Task.FromResult(response);
                }
                response.Value= _mapper.Map<List<GetPostsByCategoryIdQueryResponse>>(post.Value);
                response.Success = true;
                response.InfoMessage=post.InfoMessage;

            }
            return await Task.FromResult(response);





        }
    }
}
