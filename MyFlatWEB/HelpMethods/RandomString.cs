using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFlatWEB.HelpMethods
{
    public class RandomString
    {
        public string GetHeaderString()
        {
            string[] Titles = { "BUILD YOU FLAT!", 
                                "GOOD HOUSE!", 
                                "THE BEST SERVICE", 
                                "EXCELLENT QUALITY", 
                                "EXCELLENT JOB",
                                "LIVE COMFORTABLY",
                                "ECO-FRIENDLY HOUSES",
                                "SMART CONSTRUCTION"};

            return Titles[new Random().Next(0, Titles.Length)];
        }
    }
}
