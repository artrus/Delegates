using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public static class Converters
    {
        public static long ConvertToPersonAge(Person person) => person.Age;
        public static long ConvertToFileSize(FileInfo fileInfo) => fileInfo.Length;

    }
}
