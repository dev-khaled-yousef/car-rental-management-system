﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_DataAccess
{
    public class clsTransactionData
    {
        public static bool GetTransactionInfoByID(int TransactionID, ref int BookingID,
            ref int ReturnID, ref string PaymentDetails, ref float PaidInitialTotalDueAmount,
            ref float ActualTotalDueAmount, ref float TotalRemaining,
            ref float TotalRefundedAmount, ref DateTime TransactionDate,
            ref DateTime UpdatedTransactionDate)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select * from RentalTransaction where TransactionID = @TransactionID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionID", TransactionID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;

                                BookingID = (int)reader["BookingID"];
                                ReturnID = (reader["ReturnID"] != DBNull.Value) ? (int)reader["ReturnID"] : 0;
                                PaymentDetails = (string)reader["PaymentDetails"];
                                PaidInitialTotalDueAmount = Convert.ToSingle(reader["PaidInitialTotalDueAmount"]);
                                ActualTotalDueAmount = (reader["ActualTotalDueAmount"] != DBNull.Value) ? Convert.ToSingle(reader["ActualTotalDueAmount"]) : 0f;
                                TotalRemaining = (reader["TotalRemaining"] != DBNull.Value) ? Convert.ToSingle(reader["TotalRemaining"]) : 0f;
                                TotalRefundedAmount = (reader["TotalRefundedAmount"] != DBNull.Value) ? Convert.ToSingle(reader["TotalRefundedAmount"]) : 0f;
                                TransactionDate = (DateTime)reader["TransactionDate"];
                                UpdatedTransactionDate = (reader["UpdatedTransactionDate"] != DBNull.Value) ? (DateTime)reader["UpdatedTransactionDate"] : DateTime.Now;
                            }
                            else
                            {
                                // The record was not found
                                IsFound = false;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                IsFound = false;
            }

            return IsFound;
        }

        public static int AddNewTransaction(int BookingID, string PaymentDetails,
            float PaidInitialTotalDueAmount)

        {
            // This function will return the new person id if succeeded and -1 if not
            int TransactionID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"insert into RentalTransaction (BookingID, PaymentDetails, PaidInitialTotalDueAmount, TransactionDate)
values (@BookingID, @PaymentDetails, @PaidInitialTotalDueAmount, @TransactionDate)
select scope_identity()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookingID", BookingID);
                        command.Parameters.AddWithValue("@PaymentDetails", PaymentDetails);
                        command.Parameters.AddWithValue("@PaidInitialTotalDueAmount", PaidInitialTotalDueAmount);
                        command.Parameters.AddWithValue("@TransactionDate", DateTime.Now);

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int InsertID))
                        {
                            TransactionID = InsertID;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

            }

            return TransactionID;
        }

        public static bool UpdateTransaction(int TransactionID, int ReturnID,
            float ActualTotalDueAmount, float TotalRefundedAmount)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"Update RentalTransaction
set ReturnID = @ReturnID,
ActualTotalDueAmount = @ActualTotalDueAmount,
TotalRefundedAmount = @TotalRefundedAmount,
UpdatedTransactionDate = @UpdatedTransactionDate
where TransactionID = @TransactionID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionID", TransactionID);
                        command.Parameters.AddWithValue("@ReturnID", ReturnID);
                        command.Parameters.AddWithValue("@ActualTotalDueAmount", ActualTotalDueAmount);
                        command.Parameters.AddWithValue("@TotalRefundedAmount", TotalRefundedAmount);
                        command.Parameters.AddWithValue("@UpdatedTransactionDate", DateTime.Now);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {

            }

            return (RowAffected > 0);
        }

        public static bool DeleteTransaction(int TransactionID)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"delete RentalTransaction where TransactionID = @TransactionID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionID", TransactionID);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {

            }

            return (RowAffected > 0);
        }

        public static bool DoesTransactionExist(int TransactionID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select found = 1 from RentalTransaction where TransactionID = @TransactionID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionID", TransactionID);

                        object result = command.ExecuteScalar();

                        IsFound = (result != null);
                    }
                }
            }
            catch (SqlException ex)
            {
                IsFound = false;
            }

            return IsFound;
        }

        public static DataTable GetAllRentalTransaction()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select * from RentalTransaction";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

            }

            return dt;
        }

        public static int GetTransactionsCount()
        {
            int Count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT COUNT(*) FROM RentalTransaction";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int Value))
                        {
                            Count = Value;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

            }

            return Count;
        }
    }
}
