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
            UjBajnoksag.IsEnabled = false;
            

            futam = new Futam();
            versenyzo1 = new Versenyzo("versenyzo1", Rect1, futam,sav1,kiiras1);
            versenyzo2 = new Versenyzo("versenyzo2", Rect2, futam,sav2,kiiras2);
            versenyzo3 = new Versenyzo("versenyzo3", Rect3, futam,sav3,kiiras3);
            futam.versenyzok.Add(versenyzo1);
            futam.versenyzok.Add(versenyzo2);
            futam.versenyzok.Add(versenyzo3);
            bajnoksag.pontozasiSorrend.Add(versenyzo1);
            bajnoksag.pontozasiSorrend.Add(versenyzo2);
            bajnoksag.pontozasiSorrend.Add(versenyzo3);
            foreach (var item in futam.versenyzok)
            {
                item.label.Visibility = Visibility.Hidden;
            }

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


                eredmenytabla.Content = $"Hely      Név        1.    2.    3.          Pont"+"\n"+
                    $"1.    {bajnoksag.pontozasiSorrend[0].name}   {bajnoksag.pontozasiSorrend[0].elsoHelyekSzama}    {bajnoksag.pontozasiSorrend[0].masodikHelyezesekSzama}     {bajnoksag.pontozasiSorrend[0].harmadikHelyezesekSzama}            {bajnoksag.pontozasiSorrend[0].pontSzam}" +"\n"+
                    $"2.    {bajnoksag.pontozasiSorrend[1].name}   {bajnoksag.pontozasiSorrend[1].elsoHelyekSzama}    {bajnoksag.pontozasiSorrend[1].masodikHelyezesekSzama}     {bajnoksag.pontozasiSorrend[1].harmadikHelyezesekSzama}            {bajnoksag.pontozasiSorrend[1].pontSzam}"+"\n"+
                    $"3.    {bajnoksag.pontozasiSorrend[2].name}   {bajnoksag.pontozasiSorrend[2].elsoHelyekSzama}    {bajnoksag.pontozasiSorrend[2].masodikHelyezesekSzama}     {bajnoksag.pontozasiSorrend[2].harmadikHelyezesekSzama}            {bajnoksag.pontozasiSorrend[2].pontSzam}";



                //elsosor.Content = $"{bajnoksag.pontozasiSorrend[0].name}   {bajnoksag.pontozasiSorrend[0].elsoHelyekSzama}    {bajnoksag.pontozasiSorrend[0].masodikHelyezesekSzama}     {bajnoksag.pontozasiSorrend[0].harmadikHelyezesekSzama}            {bajnoksag.pontozasiSorrend[0].pontSzam}";
                //masodikSor.Content = $"{bajnoksag.pontozasiSorrend[1].name}   {bajnoksag.pontozasiSorrend[1].elsoHelyekSzama}    {bajnoksag.pontozasiSorrend[1].masodikHelyezesekSzama}     {bajnoksag.pontozasiSorrend[1].harmadikHelyezesekSzama}            {bajnoksag.pontozasiSorrend[1].pontSzam}";
                //harmadikSor.Content = $"{bajnoksag.pontozasiSorrend[2].name}   {bajnoksag.pontozasiSorrend[2].elsoHelyekSzama}    {bajnoksag.pontozasiSorrend[2].masodikHelyezesekSzama}     {bajnoksag.pontozasiSorrend[2].harmadikHelyezesekSzama}            {bajnoksag.pontozasiSorrend[2].pontSzam}";


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
                Color color = Color.FromRgb(107, 203, 70);
                SolidColorBrush brush = new SolidColorBrush(color);
                v.sav.Fill = brush;
                v.label.Visibility = Visibility.Hidden;
            }

        }

        private void UjBajnoksag_Click(object sender, RoutedEventArgs e)
        {
            string eredmeny ="         A bajnokság eredményei"+"\n"+"\n"+eredmenytabla.Content.ToString();
            MessageBox.Show(eredmeny);
            foreach(Versenyzo v in bajnoksag.pontozasiSorrend)
            {
                v.elsoHelyekSzama = 0;
                v.masodikHelyezesekSzama = 0;
                v.harmadikHelyezesekSzama = 0;
                v.pontSzam = 0;
                eredmenytabla.Content = " ";

                indulhat = false;
                UjFutam.IsEnabled = false;
                Start.IsEnabled = true;

                futam.sorrend.Clear();
                foreach (Versenyzo d in futam.versenyzok)
                {
                    d.rect.Margin = d.start;
                    d.value = 5f;
                    Color color = Color.FromRgb(107, 203, 70);
                    SolidColorBrush brush = new SolidColorBrush(color);
                    v.sav.Fill = brush;
                    v.label.Visibility = Visibility.Hidden;
                }
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
        public Rectangle sav;
        public float speed;
        public Label label;

        public float value = 5f;

        
        public Versenyzo(string name,Rectangle rect,Futam futam, Rectangle sav,Label label)
        {
            this.futam = futam;
            Random random = new Random();
            this.rect = rect;
            this.name = name;
            speed = random.Next(1,10);
            start = rect.Margin;
            this.sav = sav;
            this.label = label;
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
                        label.Content = "1";
                        pontSzam += 3;
                        Color color = Color.FromRgb(255, 215, 0);
                        SolidColorBrush brush = new SolidColorBrush(color);
                        sav.Fill = brush;
                    }
                   else if(futam.sorrend[1] == this)
                    {
                        masodikHelyezesekSzama++;
                        label.Content = "2";
                        pontSzam += 2;
                        Color color = Color.FromRgb(192 , 192, 192);
                        SolidColorBrush brush = new SolidColorBrush(color);
                        sav.Fill = brush;
                    }
                    else if(futam.sorrend[2] == this)
                    {
                        harmadikHelyezesekSzama++;
                        label.Content = "3";
                        pontSzam += 1;
                        Color color = Color.FromRgb(255, 248, 220);
                        SolidColorBrush brush = new SolidColorBrush(color);
                        sav.Fill = brush;
                    }
                    label.Visibility = Visibility.Visible;
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
