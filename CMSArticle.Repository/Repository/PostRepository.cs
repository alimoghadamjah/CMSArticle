using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMSArticle.Models.Context;
using CMSArticle.Models.Models;

namespace CMSArticle.Repository.Repository
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(DbCMSArticleContext Context) : base(Context)
        {

        }
    }
}
