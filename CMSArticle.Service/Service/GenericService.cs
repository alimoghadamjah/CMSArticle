using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMSArticle.Repository.Repository;
using CMSArticle.Models.Models;
using CMSArticle.Models.Context;

namespace CMSArticle.Service.Service
{
    public class GenericService<T> : GenericRepository<T> where T:BaseEntity
    {
        public GenericService(DbCMSArticleContext Context) : base(Context)
        {

        }
    }
}
