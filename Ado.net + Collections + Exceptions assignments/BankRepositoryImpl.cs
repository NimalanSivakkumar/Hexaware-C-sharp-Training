using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AdoAssignment.Data
{
    public class BankRepositoryImpl : IBankRepository
    {
        SqlConnection con = null;
        SqlCommand command = null;

        public void CreateAccount(Customer owner, string accountType, double initialbalance )
        {
            
            
            int rowsAffected1 = 0;
            int rowsAffected2 = 0;
            int CustomerId = 0;
            long AccountId = 0;
            string query1 = $"insert into Accounts(account_number,account_Type,account_balance,owner) values(@aaccno,@aacctype,@aaccbalance,@aowner)";
            string query2 = $"insert into Customer(customer_id ,first_name ,last_name ,Email ,phone ,customer_address)values(@cid,@cfname,@lname,@cemail,@cphone,@caddress)";
            string query3 = $"select top 1 customer_id from Customer order by customer_id desc";
            string query4 = $"select top 1 account_number from Accounts order by account_number desc";

            try
            {

                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query3, con);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {

                        CustomerId = (int)reader["customer_id"];
                    }

                    command = new SqlCommand(query4, con);

                    SqlDataReader reader1 = command.ExecuteReader();
                    if(reader1.Read())
                    {
                        AccountId = (long)reader1["account_number"];
                    }


                }
               // AccountId = ++AccountId;
                CustomerId = ++CustomerId;
                Account account1 = new Account
                {
                    AccountNumber = ++AccountId,
                    Owner = owner
                };

                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query1, con);
                    command.Parameters.Add(new SqlParameter("@aaccno", AccountId));
                    command.Parameters.Add(new SqlParameter("@aacctype", accountType));
                    command.Parameters.Add(new SqlParameter("@aaccbalance",initialbalance));
                    command.Parameters.Add(new SqlParameter("@aowner", CustomerId));


                    rowsAffected1 = command.ExecuteNonQuery();

                }
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query2, con);
                    command.Parameters.Add(new SqlParameter("@cid", CustomerId));
                    command.Parameters.Add(new SqlParameter("@cfname", owner.FirstName));
                    command.Parameters.Add(new SqlParameter("@lname", owner.LastName));
                    command.Parameters.Add(new SqlParameter("@cemail", owner.Email));
                    command.Parameters.Add(new SqlParameter("@cphone", owner.Phone));
                    command.Parameters.Add(new SqlParameter("@caddress", owner.Address));
                    rowsAffected2 = command.ExecuteNonQuery();


                }
                if (rowsAffected1 <= 0)
                {
                    throw new InvalidAccountException("cannot create account");
                }
                else if (rowsAffected2 <= 0)
                {
                    throw new InvalidAccountException("cannot add Customer");
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message); 
            }

          
            catch(InvalidAccountException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }

        public int Deposit(long AccountNumber, double amount)
        {

            int rowAffected = 0;
            double finalamt1 = 0;
            string query = "update Accounts set account_balance = account_balance + @amount Where account_number = @aid";
            try
            {
                Account accountvalues2 = GetAccountDetails(AccountNumber);

                if(accountvalues2 == null)
                {
                    throw new NullPointerException($"Account {AccountNumber} not found");
                }

                if(amount <0)
                {
                    throw new InsufficientFundException($"{amount} cannot be less than zero");
                }


                finalamt1 = ((accountvalues2.AccountBalance) + amount);
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@aid", AccountNumber);
                    command.Parameters.AddWithValue("@amount", amount);
                    rowAffected = command.ExecuteNonQuery();

                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return (int)finalamt1;
        }

        public int Withdraw(long AccountNumber, decimal amount)
        {

            int rowAffected = 0;
            decimal finalamt = 0;
            string query = "update Accounts set account_balance = account_balance - @amount Where account_number = @aid";
            try
            {
                Account accountvalues = GetAccountDetails(AccountNumber);

                if(accountvalues == null)
                {
                    throw new NullPointerException($"Account no :{AccountNumber} not found");
                }

                if(amount > (decimal)accountvalues.AccountBalance)
                {
                    throw new InsufficientFundException("Insufficient balance amount");
                }


                finalamt =(decimal) accountvalues.AccountBalance - amount;
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@aid", AccountNumber);
                    command.Parameters.AddWithValue("@amount", amount);
                    rowAffected = command.ExecuteNonQuery();

                }
                if(rowAffected >0)
                {
                    finalamt = GetBalance(AccountNumber);
                    Console.WriteLine($"withdraw done.New balance is:{finalamt}");
                }
                else
                {
                    Console.WriteLine("error during withdraw");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return (int)finalamt;
        }

        public int GetBalance(long AccountNumber)
        {
            Account account = null;
            decimal balance = 0;
            string query = "select account_balance from Accounts Where account_number = @aid";
            try
            {

                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@aid", AccountNumber);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        balance = (decimal)reader["account_balance"];
                    }


                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return (int)balance;
        }

        public void Transfer(int fromid, int toid, double amount)
        {
            int rowAffected1 = 0;
            int rowAffected2 = 0;
            string debitquery = "update Accounts set account_balance = account_balance - @amount Where account_number = @fromid";
            string toquery = "update Accounts set account_balance = account_balance + @amount Where account_number = @toid";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(debitquery, con);
                    command.Parameters.AddWithValue("@amount", amount);
                    command.Parameters.AddWithValue("@fromid", fromid);
                    rowAffected1 = command.ExecuteNonQuery();

                    command = new SqlCommand(toquery, con);
                    command.Parameters.AddWithValue("@amount", amount);
                    command.Parameters.AddWithValue("@toid", toid);
                    rowAffected2 = command.ExecuteNonQuery();


                }


            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message );
            }
         


        }

        public Account GetAccountDetails(long AccountNumber)
        {
            Account account = null;
            string query = "select * from Accounts Where account_number = @aid";
            try
            {

                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@aid", AccountNumber);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        account = new Account();
                        account.AccountNumber = (long)reader["account_number"];
                        account.AccountType = (string)reader["account_type"];
                        account.AccountBalance = Convert.ToSingle(reader["account_balance"]);

                    }

                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return account;





        }

        public List<Account> ListAccounts()
        {
            List<Account> list = new List<Account>();
            Account account = null;
            string query = "select * from Accounts";
            try
            {

                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query, con);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        account = new Account();
                        account.AccountBalance = Convert.ToSingle(reader["account_balance"]);
                        account.AccountNumber = (long)reader["account_number"];
                        account.AccountType = (string)reader["account_type"];

                        list.Add(account);
                    }




                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message );
            }

            return list;
        }



        public void CalculateInterest()
        {
            
            string query = "update Accounts set account_balance = account_balance + (account_balance * 4.5)/100 Where account_type = 'savings'";
            try
            {
                using(con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query, con);
                   int rowAffected =  command.ExecuteNonQuery();

                    if(rowAffected > 0)
                    {
                        Console.WriteLine("interest applied to savings account tyep");

                        string Query = "select account_number, account_balance from Accounts where account_type = 'savings'";
                        command = new SqlCommand(Query, con);

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            long accountNumber = (long)reader["account_number"];
                            decimal balance = (decimal)(reader["account_balance"]);
                            Console.WriteLine($"Account Number: {accountNumber}, Updated Balance: {balance}");


                        }

                    }
                    else
                    {
                        Console.WriteLine("No savings account found");
                    }


                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message );
            }


        }

        public List<Transaction> GetTransaction(DateTime fromdate, DateTime todate)
        {

            List<Transaction> list = new List<Transaction>();
            Transaction transaction = null;

            string query = "select * from Transactions where date_time between @fromdate and @todate ";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@fromdate", fromdate);
                    command.Parameters.AddWithValue("@todate", todate);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {


                        transaction = new Transaction();
                        transaction.TransactionType = (string)reader["transaction_type"];
                        transaction.DateATime = (DateTime)reader["date_time"];
                        transaction.TransactionAmount = Convert.ToDecimal(reader["transaction_amount"]);
                        list.Add(transaction);
                    }


                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message );
            }
            return list;
        }







    }
}  

