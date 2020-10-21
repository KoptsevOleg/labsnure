using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoLab.Model
{
    interface IFactory
    {
        void AddWorking(int CountWorking);
        void RemoveWorking(int CountWorking);
    }
}
