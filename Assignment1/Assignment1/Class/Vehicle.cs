using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Assignment1.Class
{
    public abstract class Vehicle
    {
        public string? Make { get; set; }
        public string? Model { get; set; }
        public abstract void Start();
        public abstract void Stop();
    }
}
