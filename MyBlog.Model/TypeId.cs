using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
    public class TypeId:BaseId
    {
        [Column(TypeName = "nvarchar(12)")]
        public string TypeName { get; set; }
    }
}
