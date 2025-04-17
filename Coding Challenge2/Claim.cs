using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coding_challenge.Entity
{
    public class Claim
    {
        public int ClaimId {  get; set; }
        public string ClaimNuber {  get; set; }
        public DateTime DateFiled { get; set; }
        public decimal ClaimAmount {  get; set; }
        public string Status {  get; set; }
        public int PolicyId {  get; set; }
        public int ClientId { get; set; }


        public Claim()
        {
            
        }


        public Claim(int claimId,string claimNuber,DateTime dateFiled,decimal claimAmount,string status,int policyId,int clientId)
        {
            ClaimId = claimId;
            ClaimNuber = claimNuber;
            DateFiled = dateFiled;
            ClaimAmount = claimAmount;
            Status = status;
            PolicyId = policyId;
            ClientId = clientId;

        }


        public override string ToString()
        {
            return $"ClaimId:{ClaimId},ClaimNumber:{ClaimNuber},DateFiled:{DateFiled},ClaimAmount:{ClaimAmount},Status:{Status},PolicyId:{PolicyId},ClientId:{ClientId}";
        }







    }
}
