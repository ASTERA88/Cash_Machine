using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cash_Machine
{
    public class BankCard //банковская карта
    {
        public string cardNumber; // номер карты
        public string pinCode; // PIN-код
        public double money; // средства на карте
        public BankCard(string cardNumber, string pinCode, double money)
        {
            this.cardNumber = cardNumber;
            this.pinCode = pinCode;
            this.money = money;
        }

        public String getCardNumber()
        {
            return cardNumber;
        }
        public String CardNumber
        {
            set => this.cardNumber = value;
            get => this.cardNumber;
        }

        public String getPinCode()
        {
            return pinCode;
        }
        public String PinCode
        {
            set => this.pinCode = value;
            get => this.pinCode;
        }

        
        public double getMoney()
        {
            return money;
        }
        public double Money
        {
            set => this.money = value;
            get => this.money;
        }   
    }
}
