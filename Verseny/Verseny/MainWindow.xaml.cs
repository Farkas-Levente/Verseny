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

        public MainWindow()
        {
            InitializeComponent();
            
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
    public class Bajnokság
    {
        public List<Versenyzo> versenyzok = new List<Versenyzo>();
        public List<Versenyzo> sorrend = new List<Versenyzo>();
    }


    
}
