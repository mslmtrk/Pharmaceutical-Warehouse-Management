using EczaDepo.CreatedClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EczaDepo
{
    class Global
    {
        public static List<Item> itemList = new List<Item>();
        public static List<Ilac> ilacList = new List<Ilac>();
        
        public static HttpClient client = new HttpClient();
        public static string token;
        public static string path = @"C:/EczaDepo/customer.json";
        public static int index;
        public static string cariName;
        public static string cariTaxNumber;
        public static int flag = 0;
    }
    
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }
}
