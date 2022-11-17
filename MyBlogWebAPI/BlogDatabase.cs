using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogWebAPI
{
    public record BlogDatabase
    {
        public string Server { get; set; }

        public string UID { get; set; }

        public string PassWord { get; set; }

        public string Database { get; set; }

        public bool TrustServerCertificate { get; set; }

        public override string ToString()
        {
            return $"server={Server};uid={UID};password={PassWord};database={Database};TrustServerCertificate={TrustServerCertificate}";
        }
    }
}
