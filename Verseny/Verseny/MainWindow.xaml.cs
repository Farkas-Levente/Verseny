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
        Versenyzo versenyzo1;


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

            versenyzo1 = new Versenyzo("asd", Rect1);
            
        }
        private void Tick(object sender, EventArgs e)
        {

            if (versenyzo1 == null) return;
            if (versenyzo1.rect.Margin.Left >= celvonalErtek) return;

            Thickness th = new Thickness(t * versenyzo1.speed, versenyzo1.rect.Margin.Top, 0, 0);
            versenyzo1.rect.Margin = th;

            t += 5;

        }
    }

    
    public class Versenyzo
    {
        public string name;
        public int pontSzam;
        public Rectangle rect;
        public int elsoHelyekSzama;
        public int masodikHelyezesekSzama;
        public int harmadikHelyezesekSzama;

        public float speed;

        Random random = new Random();
        public Versenyzo(string name,Rectangle rect)
        {
            this.rect = rect;
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
