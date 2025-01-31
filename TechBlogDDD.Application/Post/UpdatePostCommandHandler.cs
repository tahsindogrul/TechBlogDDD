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
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommandRequest, GeneralResponse<UpdatePostCommandResponse>>
    {
        private readonly IPostRepository _postRepository;

        public UpdatePostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<GeneralResponse<UpdatePostCommandResponse>> Handle(UpdatePostCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<UpdatePostCommandResponse>();
            response.Value = new UpdatePostCommandResponse();

            var post = await _postRepository.UpdateAsync(new Domain.Entity.Post
            {
                Title = request.Title,
                Content = request.Content,
                CategoryId = request.CategoryId,
                PhotoUrl = request.PhotoUrl,

            });
            if (!post.Success)
            {
                response.Success = post.Success;
                response.ErrorMessage = post.ErrorMessage;
                return await Task.FromResult(response);
            }

            response.Success = true;
            response.InfoMessage = "Post successfully updated";
            return await Task.FromResult(response);
        }
    }
}
