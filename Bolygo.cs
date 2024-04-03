using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolygok
{
    internal class Bolygo : IBolygo
    {

        double x, y, z, e;
        public Bolygo(string CSVsor)
        {
            string[] gyongyok = CSVsor.Split(';');
            this.X = Convert.ToInt32(gyongyok[0]);
            this.Y = Convert.ToInt32(gyongyok[1]);
            this.Z = Convert.ToInt32(gyongyok[2]);
            this.E = Convert.ToInt32(gyongyok[3]);
        }

        public double Tavolsag(IBolygo egyik, IBolygo masik)
        {
            return Math.Sqrt(Math.Pow(masik.X - egyik.X, 2) + Math.Pow(masik.Y - egyik.Y, 2) + Math.Pow(masik.Z - egyik.Z, 2)); // |ABZ|
        }


        public bool Szabad { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public double Z { get => z; set => z = value; }
        public double E { get => e; set => e = value; }
    }
}

