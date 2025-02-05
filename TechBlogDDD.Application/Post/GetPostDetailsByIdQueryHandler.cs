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
    public class GetPostDetailsByIdQueryHandler : IRequestHandler<GetPostDetailsByIdQueryRequest, GeneralResponse<GetPostDetailsByIdQueryResponse>>
    {
       private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostDetailsByIdQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<GeneralResponse<GetPostDetailsByIdQueryResponse>> Handle(GetPostDetailsByIdQueryRequest request, CancellationToken cancellationToken)
        {
           var response= new GeneralResponse<GetPostDetailsByIdQueryResponse>();
            response.Value = new GetPostDetailsByIdQueryResponse();

            if(request.Id != null)
            {
                var post= await _postRepository.GetPostDetails(request.Id);
                if (!post.Success)
                {
                    response.Success = post.Success;
                    response.ErrorMessage= post.ErrorMessage;
                    return await Task.FromResult(response);
                }
                if (post.Value == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Post not found!";
                    return await Task.FromResult(response);
                }

                var item = _mapper.Map<GetPostDetailsByIdQueryResponse>(post.Value);
                response.Value = item;
                response.Success = true;
                response.InfoMessage=post.InfoMessage;
            }
            return await Task.FromResult(response);
        }
    }
}
