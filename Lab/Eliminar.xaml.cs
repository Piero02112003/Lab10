using Business;
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

    public partial class Eliminar : Window
    {
        public Eliminar()
        {
            InitializeComponent();
        }
        private void btnEliminar(object sender, RoutedEventArgs e)
        {

            int recordId = int.Parse(txtRecordID.Text);

            BInvoice bInvoice = new BInvoice();
            bool success = bInvoice.DeleteRecord(recordId);

            if (success)
            {
                MessageBox.Show("Registro eliminado exitosamente.");
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el registro. Verifica el ID proporcionado.");
            }
        }

    }
}
