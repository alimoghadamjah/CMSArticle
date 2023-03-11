using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMSArticle.Models.Context;
using CMSArticle.Models.Models;

namespace CMSArticle.Repository.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DbCMSArticleContext Context) : base(Context)
        {

        }
    }
}
