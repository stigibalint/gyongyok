using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolygok
{
    public class Urhajo
    {
        double fogyasztas;
        double uzemanyag;

        public Urhajo(double fogyasztas, double uzemanyag)
        {
            this.Fogyasztas = fogyasztas;
            this.Uzemanyag = uzemanyag;
        }

        public double Fogyasztas { get => fogyasztas; set => fogyasztas = value; }
        public double Uzemanyag { get => uzemanyag; set => uzemanyag = value; }

        public void Tolt(double _uzemanyag)
        {
            this.uzemanyag += _uzemanyag;
        }
    }
}
