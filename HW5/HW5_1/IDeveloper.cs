using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_1
{
    internal interface IDeveloper: IComparable<IDeveloper>
    {
        string Tool { get; set; }
        void Create();
        void Destroy();

        int IComparable<IDeveloper>.CompareTo(IDeveloper other)
        {
            return String.Compare(this.Tool, other.Tool);
        }
    }
}
