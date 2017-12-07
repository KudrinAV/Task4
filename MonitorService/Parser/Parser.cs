using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorService.Parser
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
                    resultList.Add(line);
                }
            }
            return resultList;
        }
    }
}
