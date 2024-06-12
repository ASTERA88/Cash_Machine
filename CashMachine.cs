using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Cash_Machine
{
    public class CashMachine //кассовый аппарат
    {
        public double cash; // деньги в кассе
        private DateTime dateTime; // дата смены
        public String number; // номер кассового аппарата
        public String id; // ID кассира
        public CashMachine(string id, string number,  double cash, int day, int month, int year) //все параметры
        {
            this.cash = cash;
            this.dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);    
            this.number = number;
            this.id = id;
        }
        public CashMachine(string id, string number,  int day, int month, int year) //номер к/а, id кассира и дата
        {
            this.cash = 0;
            this.dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);  
            this.number = number;
            this.id = id;
        }
        public CashMachine(string id, string number)  //номер к/а и id кассира
        {
            this.cash = 0;
            this.dateTime = DateTime.Now;//new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            this.number = number;
            this.id = id;
        }
        public CashMachine(string id, string number, double cash)  //номер к/а, id кассира и наличка
        {
            this.cash = cash;
            this.dateTime = DateTime.Now;//new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            this.number = number;
            this.id = id;
        }
        
        public String getID() //ID кассира
        {
            return id;
        }
        public String ID
        {
            set => this.id = value;
            get => this.id;
        }
        public String getNumber() //номер кассового аппарата
        {
            return number;
        }
        public String Number
        {
            set => this.number = value;
            get => this.number;
        }

        public double getCash() //наличка в кассе
        {
            return cash;
        }
        public double Cash
        {
            set => this.cash = value;
            get => this.cash;
        }

        public override string ToString()
        {
            return "id кассира: " + id + ", к/а N" + number + ", денег в кассе: " + cash + ", дата: " + this.dateTime;
        }
        
            
    }
}
