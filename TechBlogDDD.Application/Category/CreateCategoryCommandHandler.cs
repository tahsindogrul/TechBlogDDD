using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogDDD.Application.Contract.Category.Commands;
using TechBlogDDD.Core.Common;
using TechBlogDDD.Domain.Repository;

namespace TechBlogDDD.Application.Category
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, GeneralResponse<CreateCategoryCommandResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;

     

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<GeneralResponse<CreateCategoryCommandResponse>> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<CreateCategoryCommandResponse>();
            response.Value = new CreateCategoryCommandResponse();

            var category = await _categoryRepository.AddAsync(new Domain.Entity.Category
            {
                Name = request.Name,
                IsActive = true
            });

            if(!category.Success)
            {
                response.Success = category.Success;
                response.ErrorMessage = category.ErrorMessage;
                return await Task.FromResult(response); 
            }
            response.Success = true;
            response.InfoMessage = "Success";
            return await Task.FromResult(response);
        }
    }
}
