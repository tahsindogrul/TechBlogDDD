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
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommandRequest, GeneralResponse<CreatePostCommandResponse>>
    {
        private readonly IPostRepository _postRepository;

        public CreatePostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<GeneralResponse<CreatePostCommandResponse>> Handle(CreatePostCommandRequest request, CancellationToken cancellationToken)
        {
           var response = new GeneralResponse<CreatePostCommandResponse>();
            response.Value = new CreatePostCommandResponse();

            var post = await _postRepository.AddAsync(new Domain.Entity.Post
            {
                Title = request.Title,
                Content = request.Content,
                DateCreated = DateTime.Now,
                CategoryId = request.CategoryId,
                UserId = request.UserId,
                PhotoUrl = request.PhotoUrl,
                IsActive = true
            });

            if (!post.Success)
            {
                response.Success=post.Success;
                response.ErrorMessage=post.ErrorMessage;
                return await Task.FromResult(response);
            }

            response.Success = true;
            response.InfoMessage = "Post successfully created";
            return await Task.FromResult(response);
        }
    }
}
