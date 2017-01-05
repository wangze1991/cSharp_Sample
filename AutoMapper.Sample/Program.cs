using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wz.AutoMapper.Sample.Domain;
using Wz.AutoMapper.Sample.Dto;
namespace AutoMapper.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var article = new Article()
            {
                Title = "漫谈实体、对象、DTO及AutoMapper的使用",
                Content = "实体（Entity）、对象（Object）、DTO（Data Transfer Object）数据传输对象，老生常谈话题，简单的概念，换个角度你会发现更多的东西。个人拙见，勿喜请喷。",
                Author = "xishuai",
                PostTime = DateTime.Now,
                Remark = "文章备注"
            };

            AutoMapper.Mapper.Initialize(cfg => {
                cfg.CreateMap<Article, ArticleDto>();//创建映射
                //.ForMember(dest => dest.ArticleId, source => source.MapFrom(src => src.Id))
                //.ForMember(dest => dest.Summary, source => source.MapFrom(src => src.Content.Substring(0,10)))
                //.ForMember(dest => dest.PostYear, source => source.MapFrom(src => src.PostTime.Year))
                //.ForMember(dest => dest.ArticleId, source => source.MapFrom(src => src.Id));
            });

            ArticleDto form = AutoMapper.Mapper.Map<Article, ArticleDto>(article);
        }
    }
}
