using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyGame
{
    public static class ExtensionMethods
    {
        public static int ReadInteger(this StreamReader Reader)
        {
            return Convert.ToInt32(Reader.ReadLine());
        }
    }
}
