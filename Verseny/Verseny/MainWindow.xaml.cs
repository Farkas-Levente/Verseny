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
        Bajnoksag bajnoksag;
        int t = 100;
        
        double celvonalErtek;
        public MainWindow()
        {
            InitializeComponent();
            celvonalErtek = celvonal.Margin.Left;
            bajnoksag = new Bajnoksag();
            
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10); 
            timer.Start(); 
            timer.Tick += Tick;
            UjFutam.IsEnabled = false;

            futam = new Futam();
            versenyzo1 = new Versenyzo("versenyzo1", Rect1, futam);
            versenyzo2 = new Versenyzo("versenyzo2", Rect2, futam);
            versenyzo3 = new Versenyzo("versenyzo3", Rect3, futam);
            futam.versenyzok.Add(versenyzo1);
            futam.versenyzok.Add(versenyzo2);
            futam.versenyzok.Add(versenyzo3);
            bajnoksag.pontozasiSorrend.Add(versenyzo1);
            bajnoksag.pontozasiSorrend.Add(versenyzo2);
            bajnoksag.pontozasiSorrend.Add(versenyzo3);

        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            
            indulhat = true;
            Start.IsEnabled = false;
            UjBajnoksag.IsEnabled = false;
            UjFutam.IsEnabled = false;

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
                foreach (Versenyzo item in futam.versenyzok)
                {
                    if(item.pontSzam == 0)
                    {
                        return;
                    }
                }
                bajnoksag.UjraRendez();

                elsosor.Content = $"{bajnoksag.pontozasiSorrend[0].name}   {bajnoksag.pontozasiSorrend[0].elsoHelyekSzama}    {bajnoksag.pontozasiSorrend[0].masodikHelyezesekSzama}     {bajnoksag.pontozasiSorrend[0].harmadikHelyezesekSzama}            {bajnoksag.pontozasiSorrend[0].pontSzam}";
                masodikSor.Content = $"{bajnoksag.pontozasiSorrend[1].name}   {bajnoksag.pontozasiSorrend[1].elsoHelyekSzama}    {bajnoksag.pontozasiSorrend[1].masodikHelyezesekSzama}     {bajnoksag.pontozasiSorrend[1].harmadikHelyezesekSzama}            {bajnoksag.pontozasiSorrend[1].pontSzam}";
                harmadikSor.Content = $"{bajnoksag.pontozasiSorrend[2].name}   {bajnoksag.pontozasiSorrend[2].elsoHelyekSzama}    {bajnoksag.pontozasiSorrend[2].masodikHelyezesekSzama}     {bajnoksag.pontozasiSorrend[2].harmadikHelyezesekSzama}            {bajnoksag.pontozasiSorrend[2].pontSzam}";


                UjFutam.IsEnabled = true;
                UjBajnoksag.IsEnabled = true;

            }
        }

        private void UjFutam_Click(object sender, RoutedEventArgs e)
        {
            indulhat = false;
            UjFutam.IsEnabled = false;
            Start.IsEnabled = true;
            
            futam.sorrend.Clear();
            foreach(Versenyzo v in futam.versenyzok)
            {
                v.rect.Margin = v.start;
                v.value = 5f;
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
        public Thickness start;

        public float speed;

        public float value = 5f;

        
        public Versenyzo(string name,Rectangle rect,Futam futam)
        {
            this.futam = futam;
            Random random = new Random();
            this.rect = rect;
            this.name = name;
            speed = random.Next(1,10);
            start = rect.Margin;
        }
        
        public void Move(double celvonalErtek,int randomszam)
        {
            if (rect.Margin.Left >= celvonalErtek)
            {
                rect.Margin = new Thickness(celvonalErtek, rect.Margin.Top, 0, 0);
                if(!futam.sorrend.Contains(this))
                {
                    futam.sorrend.Add(this);
                    
                    if (futam.sorrend[0] == this)
                    {
                        elsoHelyekSzama++;
                        pontSzam += 3;
                    }
                   else if(futam.sorrend[1] == this)
                    {
                        masodikHelyezesekSzama++;
                        pontSzam += 2;
                    }
                    else if(futam.sorrend[2] == this)
                    {
                        harmadikHelyezesekSzama++;
                        pontSzam += 1;
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

    public class Bajnoksag
    {
        public List<Versenyzo> pontozasiSorrend = new List<Versenyzo>();
        
        public void UjraRendez()
        {
            var itemMoved = false;
            do
            {
                itemMoved = false;
                for (int i = 0; i < pontozasiSorrend.Count() - 1; i++)
                {
                    if (pontozasiSorrend[i].pontSzam < pontozasiSorrend[i + 1].pontSzam)
                    {
                        var higherValue = pontozasiSorrend[i ];
                        pontozasiSorrend[i ] = pontozasiSorrend[i+1];
                        pontozasiSorrend[i+1 ] = higherValue;
                        itemMoved = true;
                    }
                }
            } while (itemMoved);
        }
    }

    
}
