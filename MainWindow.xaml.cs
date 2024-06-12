using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cash_Machine
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            listBox_beginShift.ItemsSource = beginShift;
            listBox_Basket.ItemsSource = basket;            
        }

        List<CashMachine> beginShift = new List<CashMachine>();  //кассовая смена
        List<Product> basket = new List<Product>(); //корзина продуктов

        double depozit = 0; //внесенная покупателем наличная сумма        
        double totalCost = 0; //общая сумма за товары в корзине
        double change = 0;  // сдача
        double cardMoney = 0; //деньги на банковской карте                           

        //Операция "Начать смену"
        private void button_Open_Shift_Click(object sender, RoutedEventArgs e)
        {       
            if (textBox_cashier_ID.Text == "" )
            {
                MessageBox.Show("Введите ID кассира");
            }
            else if (textBox_CashMachine_number.Text == "")
            {
                MessageBox.Show("Введите номер к/а");                
            }
            else if (textBox_cash.Text == "")
            {
                MessageBox.Show("Введите сумму в кассе");
            }
            else if (textBox_day.Text == "" || textBox_month.Text == "" || textBox_year.Text == "")
            {
                beginShift.Add(new CashMachine(textBox_cashier_ID.Text, textBox_CashMachine_number.Text, double.Parse(textBox_cash.Text)));
            }
            else if (textBox_day.Text != "" && textBox_month.Text != "" && textBox_year.Text != "")
            {
                beginShift.Add(new CashMachine(textBox_cashier_ID.Text, textBox_CashMachine_number.Text, double.Parse(textBox_cash.Text), Convert.ToInt32(textBox_day.Text),
                    Convert.ToInt32(textBox_month.Text), Convert.ToInt32(textBox_year.Text)));
            }
            listBox_beginShift.Items.Refresh(); 
        }

        //Операция "Пробить товар"
        private void button_Add_Product_Click(object sender, RoutedEventArgs e)
        {
            TextBox[] textBoxes = {
                textBox_type_product,
                textBox_quantity_product,
                textBox_price_product};

            void clearTextBoxes()
            {
                foreach (var textBox in textBoxes)
                {
                    textBox.Text = "";
                }
            }
            if (textBox_type_product.Text == "")
            {
                MessageBox.Show("Введите тип товара");
                textBox_type_product.Text = "";
            }
            else if (textBox_quantity_product.Text == "")
            {
                MessageBox.Show("Введите количество товара");
                textBox_quantity_product.Text = "";
            }
            else if (textBox_price_product.Text == "")
            {
                MessageBox.Show("Введите цену товара");
                textBox_price_product.Text = "";
            }

            basket.Add(new Product(textBox_type_product.Text, double.Parse(textBox_quantity_product.Text),
                double.Parse(textBox_price_product.Text)));
            listBox_Basket.Items.Refresh();
            clearTextBoxes();            
        }
        
        //Операция "Внесение данных банковской карты"
        BankCard[] card = new BankCard[1]; //массив для хранения данных банковской карты
        private void button_Add_BankCard_Click(object sender, RoutedEventArgs e)
        {   
            if (textBox_cardNumber.Text.Length != 16)
            {
                MessageBox.Show("Введите 16 цифр!");
                textBox_cardNumber.Text = "";             
            }
           else  if (textBox_PIN.Text.Length != 4)
            {
                MessageBox.Show("Введите 4 цифры!");
                textBox_PIN.Text = "";
            }
           else if (textBox_money.Text.Length < 1)
            {
                textBox_money.Text = "0";
            }            
            else
            {
                card[0] = new BankCard(textBox_cardNumber.Text, textBox_PIN.Text, double.Parse(textBox_money.Text));                
            }            
        }

        //Операция "Проверка PIN-кода"
        private void button_Check_PIN_Click(object sender, RoutedEventArgs e)
        {            
            if (textBox_enterPIN.Text == textBox_PIN.Text)
            {
                MessageBox.Show("Карта верна");
                textBox_enterPIN.Text = "";              
            }
            else
            {
                MessageBox.Show("Неверный PIN!");
                textBox_enterPIN.Text = "";
            }           
        }

        //Операция "Остаток наличных денег в кассе"        
        private void button_Cash_Balance_Click(object sender, RoutedEventArgs e)
        {
            textBox_endShift.Text = "в кассе: " + Convert.ToString(double.Parse(textBox_cash.Text) - change + depozit) +" у.е.";
        }

        //Операция "Печать чека при оплате налом"
        private void button_Print_Check_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show( "К/а N" + textBox_CashMachine_number.Text + "\n" +
                "Кассир " + textBox_cashier_ID.Text + "\n" +
                DateTime.Now.ToString() + "\n" +
                "Общая сумма: " + totalCost + " у.е. " + "\n"+
                "Получено: " + depozit + " у.е. " + "\n" +
                "Сдача: " + change + " у.е." + "\n" +
                "Спасибо за покупку!");
        }

         //Операция "Оплата наличкой"        
        private void button_Pay_Click(object sender, RoutedEventArgs e)
        {
            depozit = double.Parse(textBox_depozit_money.Text);
            if (depozit < totalCost)
            {
                MessageBox.Show("Маловато будет!");
                textBox_depozit_money.Text = "0";
            }
            else 
            { 
                MessageBox.Show("Принято к оплате: " + Convert.ToString(depozit) + " у.е.");
            }
        }
        
        //Операция "Пересчет стоимости из цены и количества товара"        
        private void button_Get_Cost_Click(object sender, RoutedEventArgs e)
        {
             foreach (Product lot in basket)
             {
                 lot.updatePrice();
             }
             listBox_Basket.Items.Refresh();
        }

        //Операция "Получение общей суммы коррзины товаров"    
        private void button_Total_Cost_Click(object sender, RoutedEventArgs e)
        {            
            foreach (Product lot in basket)
            {
                totalCost += lot.price; 
            }
            textBox_total_cost.Text = totalCost.ToString();
        }

        // Операция "Выдача сдачи"
        private void button_Give_Change_Click(object sender, RoutedEventArgs e)
        {
            change = depozit - totalCost;
            textBox_change.Text = change.ToString();
            if (depozit < 0)
            {
                MessageBox.Show("Посмотрите без сдачи!");
            }
        }

        //Операция "Оплата банковской картой"
        private void button_PayByCard_Click(object sender, RoutedEventArgs e)
        {
            foreach (BankCard bk in card)
            {
                cardMoney = bk.money;                
            }
            if (cardMoney < totalCost)
            {
                MessageBox.Show("Недостаточно средств, попробуйте другую карту!");
            }
            else
            {
                cardMoney -= totalCost;
                MessageBox.Show("На карте осталось: " + cardMoney + " у.е.");
            }
        }
        //Операция "Печать чека при оплате банковской картой"
        private void button_CheckByBanKCard_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("К/а N" + textBox_CashMachine_number.Text + "\n" +
                "Кассир: " + textBox_cashier_ID.Text + "\n" +
                DateTime.Now.ToString() + "\n" +
                "Общая сумма: " + totalCost + " у.е. " + "\n" +
                "Получено: " + totalCost + " у.е. " + "\n" +
                "Карта N: ************" + textBox_cardNumber.Text.Substring(12)  + "\n" +
                "Спасибо за покупку!");
        }
    }
}
