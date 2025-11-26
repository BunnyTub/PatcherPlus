using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akatsuki.Loader
{
    public static class ReflectConvert
    {
        //line is nullable
        public static bool ReadLine(this StreamReader reader, out string line)
        {
            line = reader.ReadLine();
            return line != null;
        }

        //nullable
        public static object FromString(string value, Type targetType)
        {
            if (targetType == typeof(string))
            {
                return value;
            }
            if (targetType == typeof(bool))
            {
                return !string.IsNullOrEmpty(value) && (value[0] == 'T' || value[0] == 't');
            }
            return null;
        }
    }
}
