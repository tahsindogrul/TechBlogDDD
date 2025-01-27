using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogDDD.Application.Contract.Category.Queries;
using TechBlogDDD.Core.Common;
using TechBlogDDD.Domain.Repository;

namespace TechBlogDDD.Application.Category
{
    public class GetCategoryQueryHandler: IRequestHandler<GetCategoryQueryRequest,GeneralResponse<GetCategoryQueryResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<GeneralResponse<GetCategoryQueryResponse>> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse<GetCategoryQueryResponse>();
            response.Value = new GetCategoryQueryResponse();

            var categories = await _categoryRepository.GetAllAsync();

            if (!categories.Success)
            {
                response.Success = categories.Success;
                response.ErrorMessage = categories.ErrorMessage;
                return await Task.FromResult(response);
            }
            response.Success = true;
            response.InfoMessage = "Success";
            return await Task.FromResult(response);
        }
    }
}
