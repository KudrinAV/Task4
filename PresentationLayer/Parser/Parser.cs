using PresentationLayer.ViewModels;
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
        private SaleViewModel parseLine(string line)
        {
            var temp = line.Split(';');
            return new SaleViewModel("test", DateTime.Parse(temp[0]), temp[1], temp[2], Double.Parse(temp[3]));
        }


        public IList<SaleViewModel> ParserCSV(string path)
        {
            IList<SaleViewModel> resultList = new List<SaleViewModel>();
            string line;
            using (System.IO.StreamReader sr = new System.IO.StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    resultList.Add(parseLine(line));
                }
            }
            return resultList;
        }
    }
}
