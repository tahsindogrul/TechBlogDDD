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
    public class GetPostQueryHandler : IRequestHandler<GetPostQueryRequest, GeneralResponse<List<GetPostQueryResponse>>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostQueryHandler(IMapper mapper, IPostRepository postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public async Task<GeneralResponse<List<GetPostQueryResponse>>> Handle(GetPostQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<List<GetPostQueryResponse>>();
            response.Value = new List<GetPostQueryResponse>();

            var post = await _postRepository.GetAllAsync();

            if (!post.Success)
            {
                response.Success = post.Success;
                response.ErrorMessage = post.ErrorMessage;
                return await Task.FromResult(response);
            }

            response.Value = _mapper.Map<List<GetPostQueryResponse>>(post.Value);
            response.Success = true;
            response.InfoMessage = "Getting successfully";
            return await Task.FromResult(response);


        }
    }
}
