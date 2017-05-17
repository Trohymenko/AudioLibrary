using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Identity.Entities
{ 

    public class ApplicationRole : IdentityRole
    {

        public virtual ClientProfile ClientProfile { get; set; }


    }
}
