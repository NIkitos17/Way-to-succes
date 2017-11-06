using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LABA
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            DateTime startDate = new DateTime(1800, 1, 1);
            DateTime endDate = new DateTime(2100, 1, 1);
            
            Regex r = new Regex(@"^((0[1-9]|[12][0-9]|3[01])[/](0[1-9]|1[012])[/](18|20)\d\d)\b");

            StreamReader f = new StreamReader("dati.txt", Encoding.Default);
            string fData = f.ReadToEnd();
            var fileData = from w in fData.Split(new char[] { '\r', '\n' },StringSplitOptions.RemoveEmptyEntries) select w;

            foreach (var str in fileData)
            {
                if (r.IsMatch(str))
                {
                    DateTime dateToCheck;
                        DateTime.TryParse(r.Match(str).ToString(),out dateToCheck);
                    
                    if (dateToCheck >= startDate && dateToCheck <= endDate)
                    {
                        Console.WriteLine(str);
                        count++;
                    }
                }
            }
            Console.WriteLine("Кол-во дат в файле без текста = {0} ", count);
            Console.ReadKey();
        }
    }
}
