using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using HelixToolkit.Wpf;

namespace WpfHelixToolkit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Gyongy> gyongyok = File.ReadAllLines("gyongyok.txt").Skip(1).Select(x => new Gyongy(x)).ToList();
  
        public MainWindow()
        {
            InitializeComponent();
      
            Random rnd = new Random();
            int randomSzam;
            foreach (var item in gyongyok)
            {

                     randomSzam = rnd.Next(-10, 15);

                
                EllipsoidVisual3D ellipsoidVisual3D = new EllipsoidVisual3D();

                ellipsoidVisual3D.RadiusX =3;
                ellipsoidVisual3D.RadiusY =3;
                ellipsoidVisual3D.RadiusZ = 3;
                ellipsoidVisual3D.Center = new Point3D(item.X * 2, item.Y * 2, (item.Z + randomSzam)*2);
                ellipsoidVisual3D.Fill = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(0,255), (byte)rnd.Next(0, 255),(byte)rnd.Next(0, 255)));
                ter.Children.Add(ellipsoidVisual3D);
            }




        }
    }
}