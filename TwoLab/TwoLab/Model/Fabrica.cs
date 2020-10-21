using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwoLab.Model.NewMethod;

namespace TwoLab.Model
{
   public class Fabrica:IFactory,IComparable<Fabrica>
    {
        public string Name { get; set; }
        public uint CountWorking { get; set; }
        public uint CountWorkShop { get; set; }
        public int CountMaster { get; set; }
        public decimal WagesWorking { get; set; }
        public decimal WagesMaster { get; set; }
        public decimal WagesOfMounthW { get; set; }
        public decimal WagesOfMounthM { get; set; }
        public decimal TotalSum { get; set; }
        public decimal ContributionOnWorking { get; set; }
        public Fabrica(string Name,uint CountWorking, uint CountWorkShop, int CountMaster, decimal WagesWorking, decimal WagesMaster)
        {
            this.Name = Name;
            this.CountWorking = CountWorking;
            this.CountWorkShop = CountWorkShop;
            this.CountMaster = CountMaster;
            this.WagesWorking = WagesWorking;
            this.WagesMaster = WagesMaster;
        }
        //копирующий конструктор
        public Fabrica(Fabrica fabrica)
        {
            Name = fabrica.Name;
            CountWorking = fabrica.CountWorking;
            CountWorkShop = fabrica.CountWorkShop;
            CountMaster = fabrica.CountMaster;
            WagesWorking = fabrica.WagesWorking;
            WagesMaster = fabrica.WagesMaster;

        }
        public uint CountMasterMethod()
        {
           return (uint)(CountMaster = (int)(CountWorking / 10));
        }
        //Найм работников
        public void AddWorking(int CountWorking)
        {
            int temp=CountWorking / 10;
            this.CountWorking += (uint)CountWorking;
            CountMaster += temp;
           
        }
        //Увольнение работников
        public void RemoveWorking(int CountWorking)
        {
            if (this.CountWorking > CountWorking)
            {
                this.CountWorking -= (uint)CountWorking;
                int temp = CountWorking / 10;
                CountMaster -= temp;
               
            }
            else
            {
                MessageBox.Show("Не хватает рабочих");
            }
        }
        //Общая зарплата всех работников и мастеров
        public void TotalSumSet()
        {
            TotalSum = ((CountWorking * WagesWorking) + (CountMaster * WagesMaster));
        }

        public void SetWageOfMouthW()
        {
            WagesOfMounthW = TotalSum / WagesWorking / 10;
        }
        public void SetWageOfMouthM()
        {
            WagesOfMounthM = TotalSum / WagesMaster / 10;
        }

        public void SetContribution(decimal sum)
        {
           
            ContributionOnWorking=this.Add(sum);
        }
        //реализация интерфейс IComparable
        public int CompareTo(Fabrica other)
        {
            Fabrica temp = other as Fabrica;
            if (temp != null)
            {
                if (this.WagesWorking > temp.WagesWorking)
                    return 1;
                if (this.WagesWorking < temp.WagesWorking)
                    return -1;
                else
                    return 0;
            }
            else
            {
                throw new ArgumentException("Параметр не являеться обьектом Fabrica");
            }
        }

        //Перегрузка +(Слияние двух заводов)
        public static Fabrica operator+(Fabrica fabrica1, Fabrica fabrica2)
        {
            return new Fabrica(fabrica1.Name + fabrica2.Name, fabrica1.CountWorking + fabrica2.CountWorking, fabrica1.CountWorkShop + fabrica2.CountWorkShop, fabrica1.CountMaster + fabrica2.CountMaster, fabrica1.WagesWorking + fabrica2.WagesWorking, fabrica1.WagesMaster + fabrica2.WagesMaster);
        }
        public Fabrica()
        {

        }
        public Fabrica SetNameCompany(string NameCoompany)
        {
            Name = NameCoompany;
            return this;
        }
        public Fabrica SetCountWorking(uint CountW)
        {
            CountWorking = CountW;
            return this;
        }
        public Fabrica SetCountWorkShop(uint CountWS)
        {
            CountWorkShop = CountWS;
            return this;
        }
        public Fabrica SetCountWagesWorking(decimal _WagesWorking)
        {
            WagesWorking = _WagesWorking;
            return this;
        }
        public Fabrica SetCountWagesMaster(decimal _WagesMaster)
        {
            WagesMaster = _WagesMaster;
            return this;
        }
    }
    //Разширяющий метод
    namespace NewMethod
    {
       public static class Contribution
        {
            public static decimal Add(this Fabrica fabrica,decimal sum)
            {
                return sum * (fabrica.CountWorking / fabrica.WagesWorking);
            }
        }
    }
}
