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
        private SaleViewModel parseLine(string line , int id)
        {
            var temp = line.Split(';');
            return new SaleViewModel(DateTime.Parse(temp[0]), temp[1], temp[2], Double.Parse(temp[3]), id);
        }


        public IList<SaleViewModel> ParserCSV(string path, int id)
        {
            IList<SaleViewModel> resultList = new List<SaleViewModel>();
            string line;
            Console.WriteLine(Path.GetFileNameWithoutExtension(path))   ;
            using (StreamReader sr = new StreamReader(path))
            {
                
                try
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        resultList.Add(parseLine(line, id));
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("sending result");
            return resultList;
        }
    }
}
