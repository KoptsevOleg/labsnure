using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoLab.Model
{
    public static class StorageFabrica
    {
        public static Fabrica[] fabricas { get; private set; }
        static  StorageFabrica()
        {
            fabricas = new Fabrica[0];
        }
        public static void AddNewObjectStorage(Fabrica NewFabrica)
        {
            var AdditionallyFabrica = new Fabrica[fabricas.Length + 1];
            Array.Copy(fabricas, AdditionallyFabrica, fabricas.Length);
            AdditionallyFabrica[AdditionallyFabrica.Length - 1] = NewFabrica;
            fabricas = AdditionallyFabrica;
        }
    }
}
