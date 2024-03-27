using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHelixToolkit
{
    internal class Gyongy
    {

        int x, y, z, e;
        public Gyongy(string CSVsor)
        {
            string[] gyongyok = CSVsor.Split(';');
            this.X = Convert.ToInt32(gyongyok[0]);
            this.Y = Convert.ToInt32(gyongyok[1]);
            this.Z = Convert.ToInt32(gyongyok[2]);
            this.E = Convert.ToInt32(gyongyok[3]);
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Z { get => z; set => z = value; }
        public int E { get => e; set => e = value; }
    }
}
