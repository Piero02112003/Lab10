using Business;
using Entity;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Lab
{
    
    public partial class Insertar : Window
    {
        public Insertar()
        {
            InitializeComponent();
        }

        public void btnInsertar(object sender, RoutedEventArgs e)
        {
            bool active = true;
            int customer_id = int.Parse(txtCustomerID.Text);
            DateTime date =  DateTime.Parse(dpDate.Text);
            decimal total = decimal.Parse(txtTotal.Text);

            BInvoice bInvoice = new BInvoice();
            

            Invoice invoice = new Invoice()
            {
                active = active,
                customer_id = customer_id,
                date = date,
                total = total,
            };

            var result = bInvoice.insert(invoice);
        }
    }
}
