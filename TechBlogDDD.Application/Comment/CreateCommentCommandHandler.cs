using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogDDD.Application.Contract.Comment.Commands;
using TechBlogDDD.Core.Common;
using TechBlogDDD.Domain.Repository;

namespace TechBlogDDD.Application.Comment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommandRequest, GeneralResponse<CreateCommentCommandResponse>>
    {
        private readonly ICommentRepository _commentRepository;

        public CreateCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<GeneralResponse<CreateCommentCommandResponse>> Handle(CreateCommentCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<CreateCommentCommandResponse>();
            response.Value = new CreateCommentCommandResponse();

            var comment = await _commentRepository.AddAsync(new Domain.Entity.Comment
            {
                Content = request.Content,
                PostId = request.PostId,
                UserId = request.UserId,
                DateCreated = DateTime.Now,
                IsActive = false,

            });

            if (!comment.Success)
            {
                response.Success = comment.Success;
                response.ErrorMessage = comment.ErrorMessage;
                return await Task.FromResult(response);
            }
            response.Success = true;
            response.InfoMessage = "Comment successfully added !";
            return await Task.FromResult(response);
        }
    }
}
