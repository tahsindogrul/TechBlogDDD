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
    public class GetPostQueryHandler : IRequestHandler<GetPostQueryRequest, GeneralResponse<GetPostQueryResponse>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostQueryHandler(IMapper mapper, IPostRepository postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public async Task<GeneralResponse<GetPostQueryResponse>> Handle(GetPostQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<GetPostQueryResponse>();
            response.Value = new GetPostQueryResponse();

            if (request.PostId != null) 
            {
                var post = await _postRepository.GetAsync(new Domain.Entity.Post { Id = (int)request.PostId });

                if (!post.Success)
                {
                    response.Success = post.Success;
                    response.ErrorMessage = post.ErrorMessage;
                    return await Task.FromResult(response);
                }

                if (post.Value == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Post not found";
                    return await Task.FromResult(response);
                }

                var item = _mapper.Map<GetPostQueryResponse>(post.Value);
                response.Value = item;
                response.Success = true;
                response.InfoMessage = "Getting successfully";
            }
            return await Task.FromResult(response);
          

        }
    }
}
