using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolygok
{
    interface IBolygo
    {
        public double X { get;  }
        public double Y { get;  }
        public double Z { get;  }

         double Tavolsag(IBolygo egyik, IBolygo masik);
        public bool Szabad { get; set; }

    }
}
