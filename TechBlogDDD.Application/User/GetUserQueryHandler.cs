using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechBlogDDD.Application.Contract.User.Queries;
using TechBlogDDD.Core.Common;
using TechBlogDDD.Domain.Repository;

namespace TechBlogDDD.Application.User
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQueryRequest, GeneralResponse<GetUserQueryResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        

        public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GeneralResponse<GetUserQueryResponse>> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
        {
            var response= new GeneralResponse<GetUserQueryResponse>();
            response.Value= new GetUserQueryResponse();

            var user = await _userRepository.GetByIdAsync(request.UserId);

            if (!user.Success)
            {
                response.Success = false;
                response.ErrorMessage = user.ErrorMessage;
                return response;
            }

            if (user.Value == null)
            {
                response.Success = false;
                response.ErrorMessage = "Not found any User!";
                return response;
            }

            response.Value = _mapper.Map<GetUserQueryResponse>(user.Value);
            response.Success = true;
            response.InfoMessage = "Process finished successfully!";

            return response;
        }
    }
}
