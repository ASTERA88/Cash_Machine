using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Cash_Machine
{
    public class Product // товар
    {
        public String type; // тип товара
        public double price; // цена
        public double quantity; // количество товара (штука/килограмм/литр)
        public double cost; // стоимость
        
        public Product(string type,double quantity, double price)
        {
            this.type = type;
            this.price = price;
            this.quantity = quantity;
            
        }
        public Product(string type)
        {
            this.type = type;
            this.price = 0;
            this.quantity = 0;
        }
        public Product (string type, double price)
        {
            this.type = type;
            this.price = price;
            this.quantity = 0;
        }
        
        public Product (double price, double quantity)
        {
            this.type = "unknown";
            this.price = price;
            this.quantity = quantity;
        }
        public string getType()
        {
            return type;
        }
        public String Type
        {
            set => this.type = value;
            get => this.type;
        }
        public double getPrice()
        {
            return price;
        }
        public double Price
        {
            set => this.price = value;
            get => this.price;
        }
        public double getQuantity()
        {
            return quantity;
        }
        public double Quantity
        {
            set => this.quantity = value;
            get => this.quantity;
        }

        public double getCost()
        {
            return cost;
        }
        public double Cost
        {
            set => this.cost = this.quantity * this.price;
            get => this.cost;
        }               
       
        public void updatePrice()
        {
            this.price *= this.quantity;
            this.cost += this.price;
        }

        public override string ToString()
        {
            return this.type + ":  " + this.quantity + " ед., " + this.price + " руб.";
            
        } 
    }
}
