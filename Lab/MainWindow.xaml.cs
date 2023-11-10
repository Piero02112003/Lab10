    using Business;
    using System;
    using System.Windows;
    using System.Windows.Controls;

    namespace Lab
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();



            }

            private void btnFilter(object sender, RoutedEventArgs e)
            {

                BInvoice bInvoice = new BInvoice();
                McDataGrid.ItemsSource = bInvoice.GetInvoicesByDate();
            }

            private void btnInsertar(object sender, RoutedEventArgs e) 
            { 
                Insertar insertar = new Insertar();
                insertar.Show();
                
            
            }

            private void btnEliminar(object sender, RoutedEventArgs e)
            {
            Eliminar eliminar = new Eliminar();
            eliminar.Show();


            }

    }
    }
