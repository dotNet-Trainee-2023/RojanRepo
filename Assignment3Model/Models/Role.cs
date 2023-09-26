using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3Model.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public virtual ICollection<User>? Users { get; set; }
    }
}
