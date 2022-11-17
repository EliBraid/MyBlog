using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogWebAPI
{
    public class Redis
    {
        public string IP { get; set; }

        public string Password { get; set; }

        public string DefaultDatabase { get; set; }

        public override string ToString()
        {
            return $"{IP},password={Password},DefaultDatabase={DefaultDatabase}";
        }
    }
}
