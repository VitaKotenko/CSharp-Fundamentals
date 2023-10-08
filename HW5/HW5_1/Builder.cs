using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_1
{
    internal class Builder: IDeveloper
    {
        private string tool;

        public string Tool
        {
            get { return tool; }
            set { tool = value; }
        }


        public Builder(string tool)
        {
            this.tool = tool;
        }



        public void Create()
        {
            Console.WriteLine($"Builder constructed using {tool}.");
        }

        public void Destroy()
        {
            Console.WriteLine($"Builder destroyed using {tool}.");
        }

    }
}
