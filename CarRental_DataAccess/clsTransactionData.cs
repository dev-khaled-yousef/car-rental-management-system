﻿using System;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace CarRental_DataAccess
{
    public class clsTransactionData
    {
        public static bool GetTransactionInfoByTransactionID(int? TransactionID, ref int? BookingID,
            ref int? ReturnID, ref string PaymentDetails, ref float PaidInitialTotalDueAmount,
            ref float? ActualTotalDueAmount, ref float? TotalRemaining,
            ref float? TotalRefundedAmount, ref DateTime TransactionDate,
            ref DateTime? UpdatedTransactionDate, ref byte TransactionType)
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

                                BookingID = (reader["BookingID"] != DBNull.Value) ? (int?)reader["BookingID"] : null;
                                ReturnID = (reader["ReturnID"] != DBNull.Value) ? (int?)reader["ReturnID"] : null;
                                PaymentDetails = (string)reader["PaymentDetails"];
                                PaidInitialTotalDueAmount = Convert.ToSingle(reader["PaidInitialTotalDueAmount"]);
                                ActualTotalDueAmount = (reader["ActualTotalDueAmount"] != DBNull.Value) ? (float?)Convert.ToSingle(reader["ActualTotalDueAmount"]) : null;
                                TotalRemaining = (reader["TotalRemaining"] != DBNull.Value) ? (float?)Convert.ToSingle(reader["TotalRemaining"]) : null;
                                TotalRefundedAmount = (reader["TotalRefundedAmount"] != DBNull.Value) ? (float?)Convert.ToSingle(reader["TotalRefundedAmount"]) : null;
                                TransactionDate = (DateTime)reader["TransactionDate"];
                                UpdatedTransactionDate = (reader["UpdatedTransactionDate"] != DBNull.Value) ? (DateTime?)reader["UpdatedTransactionDate"] : null;
                                TransactionType = Convert.ToByte(reader["TransactionType"]);
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

                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                IsFound = false;

                clsLogError.LogError("General Exception", ex);
            }

            return IsFound;
        }

        public static bool GetTransactionInfoByReturnID(int? ReturnID, ref int? TransactionID,
            ref int? BookingID, ref string PaymentDetails, ref float PaidInitialTotalDueAmount,
            ref float? ActualTotalDueAmount, ref float? TotalRemaining,
            ref float? TotalRefundedAmount, ref DateTime TransactionDate,
            ref DateTime? UpdatedTransactionDate, ref byte TransactionType)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select * from RentalTransaction where ReturnID = @ReturnID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ReturnID", ReturnID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;

                                TransactionID = (reader["TransactionID"] != DBNull.Value) ? (int?)reader["TransactionID"] : null;
                                BookingID = (reader["BookingID"] != DBNull.Value) ? (int?)reader["BookingID"] : null;
                                PaymentDetails = (string)reader["PaymentDetails"];
                                PaidInitialTotalDueAmount = Convert.ToSingle(reader["PaidInitialTotalDueAmount"]);
                                ActualTotalDueAmount = (reader["ActualTotalDueAmount"] != DBNull.Value) ? (float?)Convert.ToSingle(reader["ActualTotalDueAmount"]) : null;
                                TotalRemaining = (reader["TotalRemaining"] != DBNull.Value) ? (float?)Convert.ToSingle(reader["TotalRemaining"]) : null;
                                TotalRefundedAmount = (reader["TotalRefundedAmount"] != DBNull.Value) ? (float?)Convert.ToSingle(reader["TotalRefundedAmount"]) : null;
                                TransactionDate = (DateTime)reader["TransactionDate"];
                                UpdatedTransactionDate = (reader["UpdatedTransactionDate"] != DBNull.Value) ? (DateTime?)reader["UpdatedTransactionDate"] : null;
                                TransactionType = Convert.ToByte(reader["TransactionType"]);
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

                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                IsFound = false;

                clsLogError.LogError("General Exception", ex);
            }

            return IsFound;
        }

        public static bool GetTransactionInfoByBookingID(int? BookingID, ref int? TransactionID,
            ref int? ReturnID, ref string PaymentDetails, ref float PaidInitialTotalDueAmount,
            ref float? ActualTotalDueAmount, ref float? TotalRemaining,
            ref float? TotalRefundedAmount, ref DateTime TransactionDate,
            ref DateTime? UpdatedTransactionDate, ref byte TransactionType)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select * from RentalTransaction where BookingID = @BookingID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookingID", BookingID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;

                                TransactionID = (reader["TransactionID"] != DBNull.Value) ? (int?)reader["TransactionID"] : null;
                                ReturnID = (reader["ReturnID"] != DBNull.Value) ? (int?)reader["ReturnID"] : null;
                                PaymentDetails = (string)reader["PaymentDetails"];
                                PaidInitialTotalDueAmount = Convert.ToSingle(reader["PaidInitialTotalDueAmount"]);
                                ActualTotalDueAmount = (reader["ActualTotalDueAmount"] != DBNull.Value) ? (float?)Convert.ToSingle(reader["ActualTotalDueAmount"]) : null;
                                TotalRemaining = (reader["TotalRemaining"] != DBNull.Value) ? (float?)Convert.ToSingle(reader["TotalRemaining"]) : null;
                                TotalRefundedAmount = (reader["TotalRefundedAmount"] != DBNull.Value) ? (float?)Convert.ToSingle(reader["TotalRefundedAmount"]) : null;
                                TransactionDate = (DateTime)reader["TransactionDate"];
                                UpdatedTransactionDate = (reader["UpdatedTransactionDate"] != DBNull.Value) ? (DateTime?)reader["UpdatedTransactionDate"] : null;
                                TransactionType = Convert.ToByte(reader["TransactionType"]);
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

                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                IsFound = false;

                clsLogError.LogError("General Exception", ex);
            }

            return IsFound;
        }

        public static int? AddNewTransaction(int? BookingID, string PaymentDetails,
            float PaidInitialTotalDueAmount)

        {
            // This function will return the new person id if succeeded and null if not
            int? TransactionID = null;

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
                        command.Parameters.AddWithValue("@BookingID", (object)BookingID ?? DBNull.Value);
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
                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsLogError.LogError("General Exception", ex);
            }

            return TransactionID;
        }

        public static bool UpdateTransaction(int? TransactionID, int? ReturnID,
            float? ActualTotalDueAmount, float? TotalRemaining,
            float? TotalRefundedAmount)
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
TotalRemaining = @TotalRemaining,
TotalRefundedAmount = @TotalRefundedAmount,
UpdatedTransactionDate = @UpdatedTransactionDate
where TransactionID = @TransactionID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionID", (object)TransactionID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ReturnID", (object)ReturnID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TotalRemaining", (object)TotalRemaining ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ActualTotalDueAmount", (object)ActualTotalDueAmount ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TotalRefundedAmount", (object)TotalRefundedAmount ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedTransactionDate", DateTime.Now);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsLogError.LogError("General Exception", ex);
            }

            return (RowAffected > 0);
        }

        public static bool UpdateTotalRefundedAmount(int? TransactionID, float? TotalRemaining)

        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"Update RentalTransaction
                                     set TotalRefundedAmount = ABS(@TotalRemaining),
                                         TotalRemaining = 0
                                     where TransactionID = @TransactionID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionID", (object)TransactionID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TotalRemaining", (object)TotalRemaining ?? DBNull.Value);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsLogError.LogError("General Exception", ex);
            }

            return (RowAffected > 0);
        }

        public static bool DeleteTransaction(int? TransactionID)
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
                        command.Parameters.AddWithValue("@TransactionID", (object)TransactionID ?? DBNull.Value);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsLogError.LogError("General Exception", ex);
            }

            return (RowAffected > 0);
        }

        public static bool DoesTransactionExist(int? TransactionID)
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
                        command.Parameters.AddWithValue("@TransactionID", (object)TransactionID ?? DBNull.Value);

                        object result = command.ExecuteScalar();

                        IsFound = (result != null);
                    }
                }
            }
            catch (SqlException ex)
            {
                IsFound = false;

                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                IsFound = false;

                clsLogError.LogError("General Exception", ex);
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

                    string query = @"select * from TransactionDetails_View order by UpdatedTransactionDate desc";

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
                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsLogError.LogError("General Exception", ex);
            }

            return dt;
        }

        public static DataTable GetAllRentalTransactionByCustomerID(int? CustomerID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select * from TransactionDetails_View where CustomerID = @CustomerID order by TransactionID desc";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", (object)CustomerID ?? DBNull.Value);

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
                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsLogError.LogError("General Exception", ex);
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
                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsLogError.LogError("General Exception", ex);
            }

            return Count;
        }

        public static int? GetReturnIDByBookingID(int? BookingID)
        {
            int? ReturnID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select RentalTransaction.ReturnID from RentalTransaction
                                     where RentalTransaction.BookingID = @BookingID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookingID", (object)BookingID ?? DBNull.Value);

                        object result = command.ExecuteScalar();

                        if (result != null && (int.TryParse(result.ToString(), out int Value)))
                        {
                            ReturnID = Value;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsLogError.LogError("General Exception", ex);
            }

            return ReturnID;
        }

    }
}
