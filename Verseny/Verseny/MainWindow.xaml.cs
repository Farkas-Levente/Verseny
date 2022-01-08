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

namespace Verseny
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        int l = 100;
        int t = 100;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            
            
            Thickness th = new Thickness(t, Versenyzo1.Margin.Top, 0, 0);
            Versenyzo1.Margin = th;
            l += 100;
            t += 100;
        }
    }


    public class Versenyzo
    {
        public string name;
        public int pontSzam;

        public int elsoHelyekSzama;
        public int masodikHelyezesekSzama;
        public int harmadikHelyezesekSzama;


        public Versenyzo(string name)
        {
            this.name = name;
        }
        
    }
    public class Futam
    {
        public List<Versenyzo> versenyzok = new List<Versenyzo>();
        public List<Versenyzo> sorrend = new List<Versenyzo>();
    }


    
}
