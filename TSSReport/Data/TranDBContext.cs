using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TSSReport.Data
{
    public partial class TranDBContext : DbContext
    {
        public TranDBContext(string connectionString)
            : base(connectionString)
        { }
    }
}