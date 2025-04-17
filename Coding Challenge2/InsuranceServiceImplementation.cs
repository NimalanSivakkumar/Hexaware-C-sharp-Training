using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using coding_challenge.Entity;
using coding_challenge.ExceptionInfor;
using System.Data.SqlClient;

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
                {
                    while(reader.Read())
                    {
                        PolicyList.Add(new Policy
                        {
                            PolicyId = reader.GetInt32(0),
                            PolicyName = reader.GetString(1),
                            PolicyAmount = reader.GetDecimal(2),
                            PolicyDuration = reader.GetDateTime(3),




                        });
                    }
                }
                return PolicyList;
            }
        }

        public Policy GetPolicy(int policyId)
        {
            using (SqlConnection con = DBUtility.GetConnection())
            {

                string query = "select * from policies where PolicyId = @id";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.Add(new SqlParameter("@id", policyId));

                SqlDataReader reader = command.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        var policy = new Policy
                        {
                            PolicyId = reader.GetInt32(0),
                            PolicyName = reader.GetString(1),
                            PolicyAmount = reader.GetDecimal(2),
                            PolicyDuration = reader.GetDateTime(3),




                        };

                    }
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
    }
}
