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
using System.Windows.Threading;

namespace Verseny
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
       
        int t = 100;
        double celvonalErtek;
        public MainWindow()
        {
            InitializeComponent();
            celvonalErtek = celvonal.Margin.Left;
            DispatcherTimer timer = new DispatcherTimer();
           
            timer.Interval = TimeSpan.FromMilliseconds(10); 
            timer.Start(); 
            timer.Tick += Tick; 

        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Versenyzo versenyzo = new Versenyzo("asd");
           
        }
        private void Tick(object sender, EventArgs e)
        {

            if (Versenyzo1.Margin.Left >= celvonalErtek) return;

            Thickness th = new Thickness(t, Versenyzo1.Margin.Top, 0, 0);
            Versenyzo1.Margin = th;

            t += 5;

        }
    }

    
    public class Versenyzo
    {
        public string name;
        public int pontSzam;

        public int elsoHelyekSzama;
        public int masodikHelyezesekSzama;
        public int harmadikHelyezesekSzama;

        public float speed;
        Random random = new Random();
        public Versenyzo(string name)
        {
            this.name = name;
            speed = random.Next(1,3);
        }
        
        
    }
    public class Futam
    {
        public List<Versenyzo> versenyzok = new List<Versenyzo>();
        public List<Versenyzo> sorrend = new List<Versenyzo>();
    }


    
}
