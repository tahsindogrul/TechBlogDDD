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
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommandRequest, GeneralResponse<DeleteCommentCommandResponse>>
    {
        private readonly ICommentRepository _commentRepository;

        public DeleteCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<GeneralResponse<DeleteCommentCommandResponse>> Handle(DeleteCommentCommandRequest request, CancellationToken cancellationToken)
        {
            var response= new GeneralResponse<DeleteCommentCommandResponse>();
            response.Value = new DeleteCommentCommandResponse();

            var comment = await _commentRepository.DeleteAsync(new Domain.Entity.Comment
            {
                Id = request.CommentId,
                IsActive = false

            });

            if (!comment.Success)
            {
                response.Success = comment.Success;
                response.ErrorMessage=comment.ErrorMessage;
                return await Task.FromResult(response);
            }
            response.Success = true;
            response.InfoMessage = "Comment successfully deleted";
            return await Task.FromResult(response);
        }
    }
}
