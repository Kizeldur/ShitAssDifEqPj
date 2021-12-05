using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ScottPlot;
using ShitAssDirectionFieldDrawingNamespace;
using static ShitAssDirectionFieldDrawingNamespace.ShitAssDirectionFieldDrawingClass;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Numerics;


namespace ShitAssDirectionFieldPj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DrawShitBtn(object sender, RoutedEventArgs e)
        {
            double[] dataX = new double[] { 0, 1, 2, 3, 4, 5 };
            var dataY = ShitAssDirectionFieldDrawingClass.GiveMeSolution(Equation, Answer, dataX.Length);
           
            /*WpfPlot1.Plot.AddScatter(dataX, dataY);*/

            var plt = new ScottPlot.Plot(600, 400);

            // create an interesting plot
            double[] xs = DataGen.Range(-5, 5, .5);
            
            var xf = DataGen.Range(-5, 5, .5);
            double[] ys = DataGen.Range(-5, 5, .5);
            var vectors = new ScottPlot.Statistics.Vector2[xs.Length, ys.Length];
            for (int i = 0; i < xs.Length; i++)
                for (int j = 0; j < ys.Length; j++)
                    vectors[i, j] = new ScottPlot.Statistics.Vector2((float)ys[j], (float)(-15 * Math.Sin(xs[i])));
            plt.AddVectorField(vectors, xs, ys, colormap: ScottPlot.Drawing.Colormap.Turbo);

            plt.XLabel("x");
            plt.YLabel("y");
           

            plt.SaveFig("asis_image.png");
            
            WpfPlot1.Refresh();

            







        }

        static public double Equation(int x, Solution solution)
        {
            var result = (4 * x) / solution(x);
            return solution(x);
        }

        static public double Answer(int x)
        {
            return 2 * x;
        }

        static public void awd(PaintEventArgs e)
        {
           //(double[] xs, double[] ys) = ScottPlot.Tools.ConvertPolarCoordinates()
        }

    }
}
