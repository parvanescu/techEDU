using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_2018
{
    public class VariabilaGlobala
    {
        private static string var1 = "";
        public static string constring
        {
            get { return var1; }
            set { var1 = value; }
        }
        private static string var2 = "";
        public static string resurse
        {
            get { return var2; }
            set { var2 = value; }
        }

        public static bool var3;
        public static bool reg
        {
            get { return var3;}
            set {var3 = value;}
        }
    }
}
