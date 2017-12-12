using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppProj.Models
{
    public class Contacts
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
