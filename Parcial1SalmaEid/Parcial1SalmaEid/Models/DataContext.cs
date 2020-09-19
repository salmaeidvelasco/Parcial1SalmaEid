using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Parcial1SalmaEid.Models
{
    public class DataContext:DbContext  
    {

        public DataContext():base("DefaultConnection")
        {

        }
    }
}