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
        DispatcherTimer timer;
        bool indulhat = false;
        Random random = new Random();

        int t = 100;
        
        double celvonalErtek;
        public MainWindow()
        {
            InitializeComponent();
            celvonalErtek = celvonal.Margin.Left;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10); 
            timer.Start(); 
            timer.Tick += Tick; 

        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            futam = new Futam();
            versenyzo1 = new Versenyzo("versenyzo1", Rect1,futam);
            versenyzo2 = new Versenyzo("versenyzo2", Rect2,futam);
            versenyzo3 = new Versenyzo("versenyzo3", Rect3,futam);
            futam.versenyzok.Add(versenyzo1);
            futam.versenyzok.Add(versenyzo2);
            futam.versenyzok.Add(versenyzo3);
            indulhat = true;

        }
        private void Tick(object sender, EventArgs e)
        {
            if (!indulhat) return;
            int random1 = random.Next(1, 3);
            int random2 = random.Next(1, 3);
            int random3 = random.Next(1, 3);

            versenyzo1.Move(celvonalErtek,random1);
            versenyzo2.Move(celvonalErtek,random2);
            versenyzo3.Move(celvonalErtek,random3);

            if(futam.versenyzok.Count == futam.sorrend.Count)
            {
                
               // timer.Stop();

                elsosor.Content = $"{versenyzo1.name}   {versenyzo1.elsoHelyekSzama}    {versenyzo1.masodikHelyezesekSzama}     {versenyzo1.harmadikHelyezesekSzama}            {versenyzo1.pontSzam}";





            }
        }
    }

    
    public class Versenyzo
    {
        public string name;
        public int pontSzam = 0;
        public Rectangle rect;
        public int elsoHelyekSzama =0;
        public int masodikHelyezesekSzama = 0;
        public int harmadikHelyezesekSzama = 0;
        Futam futam;

        public float speed;

        float value = 5f;

        
        public Versenyzo(string name,Rectangle rect,Futam futam)
        {
            this.futam = futam;
            Random random = new Random();
            this.rect = rect;
            this.name = name;
            speed = random.Next(1,10);
        }
        
        public void Move(double celvonalErtek,int randomszam)
        {
            if (rect.Margin.Left >= celvonalErtek)
            {
                if(!futam.sorrend.Contains(this))
                {
                    futam.sorrend.Add(this);
                    
                    if (futam.sorrend[0] == this)
                    {
                        elsoHelyekSzama++;
                    }
                   else if(futam.sorrend[1] == this)
                    {
                        masodikHelyezesekSzama++;
                    }
                    else if(futam.sorrend[2] == this)
                    {
                        harmadikHelyezesekSzama++;
                    }
                }
                
                return;
            }
                

            Thickness th = new Thickness(value , rect.Margin.Top, 0, 0);
            rect.Margin = th;

            value += 5 * randomszam;
        }
        
    }
    public class Futam
    {
        public List<Versenyzo> versenyzok = new List<Versenyzo>();
        public List<Versenyzo> sorrend = new List<Versenyzo>();

       
    }


    
}
