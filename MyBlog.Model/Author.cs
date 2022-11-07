using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyBlog.Model
{
    public class Author:BaseId
    {
        [Column(TypeName = "nvarchar(12)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(16)")]
        public string Account { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string Password { get; set; }
    }
}
