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
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommandRequest, GeneralResponse<UpdateCommentCommandResponse>>
    {
        private readonly ICommentRepository _commentRepository;

        public UpdateCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<GeneralResponse<UpdateCommentCommandResponse>> Handle(UpdateCommentCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<UpdateCommentCommandResponse>();
            response.Value = new UpdateCommentCommandResponse();

            var comment = await _commentRepository.UpdateAsync(new Domain.Entity.Comment
            {
                Content = request.Content,

            });

            if (!comment.Success)
            {
                response.Success = comment.Success;
                response.ErrorMessage= comment.ErrorMessage;
                return await Task.FromResult(response);
            }
            response.Success = true;
            response.InfoMessage = "Comment successfully updated";
            return await Task.FromResult(response);

        }
    }
}
