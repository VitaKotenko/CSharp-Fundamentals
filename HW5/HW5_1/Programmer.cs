using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_1
{
    internal class Programmer: IDeveloper
    {
        private string language;

        public string Tool
        {
            get { return language; }
            set { language = value; }
        }

        public Programmer(string language)
        {
            this.language = language;
        }



        public void Create()
        {
            Console.WriteLine($"Programmer wrote app in {language}.");

        }

        public void Destroy()
        {

            Console.WriteLine($"Programmer deleted app which was wote in {language}.");
        }
    }
}
