using System.ComponentModel.DataAnnotations;

namespace MyBlog.Model
{
    public class BaseId
    {
        [Key]
        public int Id { get; set; }
    }
}