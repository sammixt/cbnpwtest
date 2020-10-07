using ConsoleCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbnScrapper
{
    class InputParams : ParamsObject
    {
        public InputParams(string[] args)
          : base(args)
        {

        }

        [Switch("D")]
        public string DownloadPath { get; set; }
        [Switch("U")]
        public string URL { get; set; }
       
    }
}
