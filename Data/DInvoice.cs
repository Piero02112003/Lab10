using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entity;

namespace Data
{
    public class DInvoice
    {
        public static string ConnectionString { get; set; } = "Data Source=LAB1504-29\\SQLEXPRESS;Initial Catalog=Lab09;User ID=Tecsup00;Password=123456";

        public List<Invoice> Get()
        {
            List<Invoice> detalles = new List<Invoice>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "usp_ListarInvoice";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Invoice detalle = new Invoice
                                {
                                    invoice_id = reader.GetInt32(reader.GetOrdinal("invoice_id")),
                                    customer_id = reader.GetInt32(reader.GetOrdinal("customer_id")),
                                    date = reader.GetDateTime(reader.GetOrdinal("date")),
                                    total = reader.GetDecimal(reader.GetOrdinal("total")),
                                    active = true
                                };
                                detalles.Add(detalle);
                            }
                        }
                    }
                }
            }

            return detalles;
        }


        public bool insert(Invoice invoice)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("InsertInvoice", connection))
                {   
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@customer_id", invoice.customer_id);
                    command.Parameters.AddWithValue("@date", invoice.date);
                    command.Parameters.AddWithValue("@total", invoice.total);
                    command.Parameters.AddWithValue("@active", invoice.active);

                    command.ExecuteNonQuery();
                }
            }
            return true;
        }
        public bool eliminar(int invoiceID)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UpdateActiveStatus", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RecordID", invoiceID);

                    int rowsAffected = command.ExecuteNonQuery();


                }
            }
            return true;
        }

    }
}
