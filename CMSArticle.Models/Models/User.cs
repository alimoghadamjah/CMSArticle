using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSArticle.Models.Models
{
    [Table("T_Users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)] 
        public string Family { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        public IEnumerable<Post> posts { get; set; }
    }
}
