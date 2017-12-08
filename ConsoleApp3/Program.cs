using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Bridges;
using BLL.DTO;
using System.IO;

namespace ConsoleApp3
{
   
    class Program
    {

        public static IList<string> ParserCSV(string path)
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

        



        private static SaleDTO parseLine(string line, string name)
        {
            var temp = line.Split(';');
            return new SaleDTO(name, DateTime.Parse(temp[0]), temp[1], temp[2], Double.Parse(temp[3]));
        }

        static void Main(string[] args)
        {
            BridgeToModel test = new BridgeToModel();

            string SName = Path.GetFileNameWithoutExtension("D:\\Task4\\testHello.csv");
            foreach (var item in ParserCSV("D:\\Task4\\testHello.csv"))
            {
                test.AddSale(parseLine(item, SName));
            }
            foreach (var item in ParserCSV("D:\\Task4\\test.csv"))
            {
                test.AddSale(parseLine(item, SName));
            }



        }
    }
}
