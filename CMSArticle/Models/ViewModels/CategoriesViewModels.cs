using CMSArticle.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSArticle.Models.ViewModels
{
    public class CategoriesViewModels
    {
        [Display(Name ="آیدی دسته بندی")]
        [Required(ErrorMessage = "فیلد {0} اجباری است!")]
        public int CategoryId { get; set; }

        [Display(Name = "نام دسته بندی")]
        [Required(ErrorMessage = "فیلد {0} اجباری است!")]
        [RegularExpression("^[آ-ی ]+$", ErrorMessage = "فقط کاراکترهای فارسی مورد تایید است!")]
        public string Title { get; set; }
        public IEnumerable<Post> posts { get; set; }
    }
}