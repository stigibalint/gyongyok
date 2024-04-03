using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
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
namespace Bolygok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Bolygo> bolygok = File.ReadAllLines("3D-G200-P865-ÉlSűrű.txt").Skip(1).Select(x => new Bolygo(x)).ToList();

        public MainWindow()
        {
            InitializeComponent();

            Random rnd = new Random();
            int randomSzam;
            int randomMeret;
            foreach (var item in bolygok)
            {

                //  randomSzam = rnd.Next(-10, 15);
                randomMeret = rnd.Next(1, 4);

                EllipsoidVisual3D ellipsoidVisual3D = new EllipsoidVisual3D();

                ellipsoidVisual3D.RadiusX = item.E;
                ellipsoidVisual3D.RadiusY = item.E;
                ellipsoidVisual3D.RadiusZ = item.E;
                ellipsoidVisual3D.Center = new Point3D(item.X * 2, item.Y * 2, (item.Z * 2));
                ellipsoidVisual3D.Fill = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255)));
                ter.Children.Add(ellipsoidVisual3D);
            }


            ter.MouseDown += Ter_MouseDown;
        }
        List<EllipsoidVisual3D> OsszekotendoBolygok = new List<EllipsoidVisual3D>();

        private void Ter_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Point mousePosition = e.GetPosition(ter);
            HitTestResult hitTestResult = VisualTreeHelper.HitTest(ter, mousePosition);
            if (hitTestResult != null && hitTestResult.VisualHit is EllipsoidVisual3D) {
                EllipsoidVisual3D clickedBolygo = (EllipsoidVisual3D)hitTestResult.VisualHit;
                if (!(OsszekotendoBolygok.Contains(clickedBolygo)))
                {
                    clickedBolygo.RadiusX += 2;
                    clickedBolygo.RadiusY += 2;
                    clickedBolygo.RadiusZ += 2;
                    OsszekotendoBolygok.Add(clickedBolygo);
                }

            }

        }

        private List<Bolygo> ElerhetoBolygok(Urhajo urhajo)
        {
            List<Bolygo> elerhetoBolygok = new List<Bolygo>();

            foreach (var bolygo in bolygok)
            {
                double tavolsag = ((IBolygo)bolygo).Tavolsag(bolygo, bolygok.First());

                if (urhajo.Uzemanyag >= urhajo.Fogyasztas * tavolsag)
                {
                    elerhetoBolygok.Add(bolygo);
                }
            }

            return elerhetoBolygok;
        }


        private void btnUtvonal_Click(object sender, RoutedEventArgs e)
        {
            if (OsszekotendoBolygok.Count < 2)
                return;

            Urhajo urhajo = new Urhajo(1, 10);
            urhajo.Tolt(20); 

            List<Bolygo> elerhetoBolygok = ElerhetoBolygok(urhajo);

            if (elerhetoBolygok.Count == 0)
            {
                MessageBox.Show("Az űrhajó nem ér el egyetlen bolygót sem az aktuális fogyasztással és üzemanyaggal.", "Figyelem!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            LinesVisual3D linesVisual = new LinesVisual3D();
            linesVisual.Color = Colors.Yellow;

            for (int i = 0; i < OsszekotendoBolygok.Count - 1; i++)
            {
                Point3D startPoint = OsszekotendoBolygok[i].Center;
                Point3D endPoint = OsszekotendoBolygok[i + 1].Center;
                linesVisual.Points.Add(startPoint);
                linesVisual.Points.Add(endPoint);
            }

            ter.Children.Add(linesVisual);
        }

    }
}