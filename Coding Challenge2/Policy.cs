using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coding_challenge.Entity
{
    public class Policy
    {
        public int PolicyId {  get; set; }
        public string PolicyName { get; set; }

        public DateTime PolicyDuration { get; set; }
        public decimal PolicyAmount { get; set; }


        public Policy()
        {
            
        }


        public Policy(int policyId,string  policyName,DateTime policyDuration,Decimal policyAmount)
        {
            PolicyId = policyId;
            PolicyName = policyName;
            PolicyDuration = policyDuration;
            PolicyAmount = policyAmount;
        }


        public override string ToString()
        {
           return $"PolicyId:{PolicyId},PolicyName:{PolicyName},PolicyDuration:{PolicyDuration},PolicyAmount:{PolicyAmount}";
        }



    }
}
