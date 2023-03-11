using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMSArticle.Models.Context;
using CMSArticle.Models.Models;

namespace CMSArticle.Service.Service
{
    public class UserService : GenericService<User>, IUserService
    {
        public UserService(DbCMSArticleContext Context) : base(Context)
        {
        }
    }
}
