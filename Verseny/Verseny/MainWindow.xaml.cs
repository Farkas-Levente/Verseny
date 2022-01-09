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
        Versenyzo versenyzo2;
        Versenyzo versenyzo3;
        Futam futam;
        bool indulhat = false;

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
            Futam futam = new Futam();
            versenyzo1 = new Versenyzo("asd", Rect1);
            versenyzo2 = new Versenyzo("asd", Rect2);
            versenyzo3 = new Versenyzo("asd", Rect3);
            futam.versenyzok.Add(versenyzo1);
            futam.versenyzok.Add(versenyzo2);
            futam.versenyzok.Add(versenyzo3);
            indulhat = true;

        }
        private void Tick(object sender, EventArgs e)
        {
            if (!indulhat) return;
           

            versenyzo1.Move(celvonalErtek);
            versenyzo2.Move(celvonalErtek);
            versenyzo3.Move(celvonalErtek);


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

        float value = 5f;

        Random random = new Random();
        public Versenyzo(string name,Rectangle rect)
        {
            this.rect = rect;
            this.name = name;
            speed = random.Next(1,3);
        }
        
        public void Move(double celvonalErtek)
        {
            if (rect.Margin.Left >= celvonalErtek) return;

            Thickness th = new Thickness(value * speed, rect.Margin.Top, 0, 0);
            rect.Margin = th;

            value += 5;
        }
        
    }
    public class Futam
    {
        public List<Versenyzo> versenyzok = new List<Versenyzo>();
        public List<Versenyzo> sorrend = new List<Versenyzo>();
    }


    
}
