using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.ParserObj
{
    public class Parser
    {
        public IList<string> ParserCSV(string path)
        {
            IList<string> resultList = new List<string>();
            string line;
            using (System.IO.StreamReader sr = new System.IO.StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    string str = null;
                    foreach (var item in line.Split(';'))
                    {
                        str += item + " " ;
                    }
                    resultList.Add(str);
                }
            }

            return resultList;
        }
    }
}
