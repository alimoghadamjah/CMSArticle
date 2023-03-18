using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;


namespace CMSArticle.App_Start
{
    public class AutoMapperConfig
    {
        public static IMapper mapper;
        public static void ConfigureMapping()
        {
            MapperConfiguration config = new MapperConfiguration(t => {
            });
            mapper = config.CreateMapper();
        }

    }
}