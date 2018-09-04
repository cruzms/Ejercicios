using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ModelContext : DbContext
    {
        public ModelContext() : base("name=Default")
        {
        }

        public System.Data.Entity.DbSet<Web.Models.Contacto> Contactoes { get; set; }
        public System.Data.Entity.DbSet<Problema2.Models.Market> Markets{ get; set; }
    }
}