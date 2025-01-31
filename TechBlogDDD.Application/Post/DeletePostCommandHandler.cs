using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogDDD.Application.Contract.Post.Commands;
using TechBlogDDD.Core.Common;
using TechBlogDDD.Domain.Repository;

namespace TechBlogDDD.Application.Post
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommandRequest, GeneralResponse<DeletePostCommandResponse>>
    {
        private readonly IPostRepository _postRepository;

        public DeletePostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<GeneralResponse<DeletePostCommandResponse>> Handle(DeletePostCommandRequest request, CancellationToken cancellationToken)
        {
            var response= new GeneralResponse<DeletePostCommandResponse>();
            response.Value= new DeletePostCommandResponse();

            var post =await _postRepository.DeleteAsync(new Domain.Entity.Post
            {
                Id = request.PostId,
                IsActive = false
            });

            if (!post.Success)
            {
                response.Success=post.Success;
                response.ErrorMessage = post.ErrorMessage;
                return await Task.FromResult(response);
            }
            response.Success = true;
            response.InfoMessage = "Post successfully deleted";
            return await Task.FromResult(response);
        }
    }
}
