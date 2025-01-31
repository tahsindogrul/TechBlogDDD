using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogDDD.Application.Contract.Post.Queries;
using TechBlogDDD.Domain.Entity;

namespace TechBlogDDD.Application
{
    public class ApplicationAutoMapper:Profile
    {
        public ApplicationAutoMapper()
        {
            #region Post
            CreateMap<Domain.Entity.Post,GetPostQueryResponse>().ReverseMap();









            #endregion
        }
    }
}
