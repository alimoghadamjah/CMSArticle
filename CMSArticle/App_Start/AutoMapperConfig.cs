using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using CMSArticle.Models.Models;
using CMSArticle.Models.ViewModels;

namespace CMSArticle.App_Start
{
    public class AutoMapperConfig
    {
        public static IMapper mapper;
        public static void ConfigureMapping()
        {
            MapperConfiguration config = new MapperConfiguration(t => {
                t.CreateMap<Category, CategoriesViewModels>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            mapper = config.CreateMapper();
        }

    }
}