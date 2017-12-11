﻿using BLL.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ParserObj
{
    public class Parser
    {
        private SaleDTO ParseLine(string line, int id)
        {
            var temp = line.Split(';');
            return new SaleDTO(DateTime.Parse(temp[0]), temp[1], temp[2], Double.Parse(temp[3]), id);
        }

        public IList<SaleDTO> ParserCSV(string path, int id)
        {
            Console.WriteLine("Parsing...");
            IList<SaleDTO> resultList = new List<SaleDTO>();
            string line;
            Console.WriteLine(Path.GetFileNameWithoutExtension(path));
            using (StreamReader sr = new StreamReader(path))
            {
                try
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        resultList.Add(ParseLine(line, id));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.Write("Sending data");
            return resultList;
        }
    }
}