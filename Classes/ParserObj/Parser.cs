using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.ParserObj
{
    public class Parser
    {
        public IList<string> ParserCSV(string path)
        {
            string SName = Path.GetFileNameWithoutExtension(path);
            Console.WriteLine(SName);
            IList<string> resultList = new List<string>();
            string line;
            using (System.IO.StreamReader sr = new System.IO.StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    resultList.Add(line);
                }
            }
            return resultList;
        }
    }
}
