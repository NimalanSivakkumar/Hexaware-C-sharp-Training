using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using coding_challenge.Entity;
using coding_challenge.ExceptionInfor;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace coding_challenge.Dao
{
    public class InsuranceServiceImplementation : IPolicyService
    {
        List<Policy>PolicyList = new List<Policy>();
        private Policy policy;

        public bool CreatePolicy(Policy policy)
        {
            using (SqlConnection con = DBUtility.GetConnection())
            {

                string query = "insert into policies(PolicyId,PolicyName,PolicyDuration,PolicyAmount) values(@id,@name,@duration,@amount)";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.Add(new SqlParameter("@id",policy.PolicyId));
                command.Parameters.Add(new SqlParameter("@name",policy.PolicyName));
                command.Parameters.Add(new SqlParameter("@duration",policy.PolicyDuration));
                command.Parameters.Add(new SqlParameter("@amount",policy.PolicyAmount));

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool DeletePolicy(int policyId)
        {
            using (SqlConnection con = DBUtility.GetConnection())
            {

                string query = "delete from policies where policyId = @id";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.Add(new SqlParameter("@id",policyId));
             
                return command.ExecuteNonQuery() > 0;
            }
        }

        public List<Policy> GetAllPolicies()
        {
            using (SqlConnection con = DBUtility.GetConnection())
            {
                
                string query = "select * from policies" ;
                SqlCommand command = new SqlCommand(query, con);
                
                SqlDataReader reader = command.ExecuteReader();
                
                    while(reader.Read())
                    {
                        PolicyList.Add(new Policy
                        {
                            PolicyId = reader.GetInt32(0),
                            PolicyName = reader.GetString(1),
                            PolicyDuration = reader.GetDateTime(2),
                            PolicyAmount = reader.GetDecimal(3),
                            




                        });
                    }
                
               
            }
            return PolicyList;
        }

        public Policy GetPolicy(int policyId)
        {
            using (SqlConnection con = DBUtility.GetConnection())
            {
                Policy policy = null;
                string query = "select * from policies where PolicyId = @id";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.Add(new SqlParameter("@id", policyId));

                SqlDataReader reader = command.ExecuteReader();
                

                    while (reader.Read())
                    {
                        policy = new Policy
                        {
                            PolicyId = reader.GetInt32(0),

                            PolicyName = reader.GetString(1),
                            PolicyDuration = reader.GetDateTime(2),
                            PolicyAmount = reader.GetDecimal(3),





                        };

                    }

                return policy;

            }
            
        }  

        public bool UpdatePolicy(int PolicyId,string NewName,DateTime NewTiming,decimal newAmount)
        {

            using (SqlConnection con = DBUtility.GetConnection())
            {

                string query = "update policies set PolicyName = @name,PolicyDuration = @duration,PolicyAmount = @amount where PolicyId =@id ";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.Add(new SqlParameter("@id", policy.PolicyId));
                command.Parameters.Add(new SqlParameter("@name", policy.PolicyName));
                command.Parameters.Add(new SqlParameter("@duration", policy.PolicyDuration));
                command.Parameters.Add(new SqlParameter("@amount", policy.PolicyAmount));

                return command.ExecuteNonQuery() > 0;
            }


        }
        public bool CreateClient(Client client)
        {
            using(SqlConnection con = DBUtility.GetConnection())
            {
                string query = "insert into clients(ClientId,ClientName,ContactInfo,PolicyId)values(@id,@name,@contact,@policy)";
                SqlCommand command   = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@id", client.ClientId);
                command.Parameters.AddWithValue("@name", client.ClientName);
                command.Parameters.AddWithValue("@contact", client.ContactInfo);
                command.Parameters.AddWithValue("@policy", client.Policy);

                return command.ExecuteNonQuery() > 0;





            }


        }

        public bool UpdateClient(Client client)
        {

            using(SqlConnection con = DBUtility.GetConnection())
            {
                string query = "update clients set ClientName = @name,ContactInfo = @contact,@Policy = @policy where ClientId = @id";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@id", client.ClientId);
                command.Parameters.AddWithValue("@name", client.ClientName);
                command.Parameters.AddWithValue("@contact", client.ContactInfo);
                command.Parameters.AddWithValue("@policy", client.Policy);
                return command.ExecuteNonQuery() > 0;




            }

        }

        public bool DeleteClient(int ClientId)
        {

            using (SqlConnection con = DBUtility.GetConnection())
            {
                string query = "delete from clients where ClientId = @id";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@id", ClientId);
                return command.ExecuteNonQuery() > 0;




            }

        }

        public List<Client>GetAllClients()
        {
            List<Client> clients = new List<Client>();
            using(SqlConnection con = DBUtility.GetConnection())
            {
                string query = "Select * from clients";
                SqlCommand command = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    clients.Add(new Client
                    {
                        ClientId = reader.GetInt32(0),
                        ClientName = reader.GetString(1),
                        ContactInfo = reader.GetString(2),
                        Policy = reader.GetString(3)

                    });

                }


            }
            return clients;


        }

        public bool CreateClaim(Claim claim)
        {
            using(SqlConnection con = DBUtility.GetConnection())
            {
                string query = "insert into claims(ClaimId,ClaimNuber,DateFiled,ClaimAmount,Status,PolicyId,ClientId) values (@id, @number, @date, @amount, @status, @policyId, @clientId)";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@id", claim.ClaimId);
                command.Parameters.AddWithValue("@number", claim.ClaimNuber);
                command.Parameters.AddWithValue("@date", claim.DateFiled);
                command.Parameters.AddWithValue("@amount", claim.ClaimAmount);
                command.Parameters.AddWithValue("@status", claim.Status);
                command.Parameters.AddWithValue("@policyId", claim.PolicyId);
                command.Parameters.AddWithValue("@clientId", claim.ClientId);

                return command.ExecuteNonQuery() > 0;


            }
        }

        public  bool UpdateClaim(Claim claim)
        {
            using (SqlConnection con = DBUtility.GetConnection())
            {
                string query = "Update claims set ClaimNuber = @number, DateFiled = @dateFiled,ClaimAmount = @amount, Status = @status, PolicyId = @policyId, ClientId = @clientId where ClaimId = @id";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@id", claim.ClaimId);
                command.Parameters.AddWithValue("@number", claim.ClaimNuber);
                command.Parameters.AddWithValue("@date", claim.DateFiled);
                command.Parameters.AddWithValue("@amount", claim.ClaimAmount);
                command.Parameters.AddWithValue("@status", claim.Status);
                command.Parameters.AddWithValue("@policy", claim.PolicyId);
                command.Parameters.AddWithValue("@client", claim.ClientId);

                return command.ExecuteNonQuery() > 0;


            }
        }

        public bool DeleteClaim(int ClaimId)
        {

            using (SqlConnection con = DBUtility.GetConnection())
            {
                string query = "delete from claims where ClaimId = @id";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@id", ClaimId);
                return command.ExecuteNonQuery() > 0;

            }


        }



    }
}
