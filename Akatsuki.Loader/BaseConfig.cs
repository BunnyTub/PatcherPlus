using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Akatsuki.Loader
{
    public abstract class BaseConfig
    {
        protected PropertyInfo[] GetFields()
        {
            return GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        }

        public void Save(StreamWriter writer)
        {
            PropertyInfo[] fields = GetFields();
            foreach (PropertyInfo propertyInfo in fields)
            {
                object value = propertyInfo.GetValue(this);
                if (value != null || value is string)
                {
                    if (value is string strvalue)
                    {
                        if (!string.IsNullOrEmpty(strvalue))
                        {
                            writer.WriteLine($"{propertyInfo.Name}={value}");
                        }
                    }
                    else
                    {
                        writer.WriteLine($"{propertyInfo.Name}={value}");
                    }
                }
            }
        }

        public void Load(StreamReader reader)
        {
            Dictionary<string, PropertyInfo> dictionary = GetFields().ToDictionary((PropertyInfo f) => f.Name, (PropertyInfo f) => f);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] array = line.Split(new[] { '=' }, 2, StringSplitOptions.None); 
                if (array.Length == 2 && dictionary.TryGetValue(array[0], out var value))
                {
                    object value2 = ReflectConvert.FromString(array[1], value.PropertyType);
                    value.SetValue(this, value2);
                }
            }
        }
    }

}
