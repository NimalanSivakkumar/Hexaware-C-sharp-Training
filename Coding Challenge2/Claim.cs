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
        public string ClaimNumber {  get; set; }
        public DateTime DateFiled { get; set; }
        public decimal ClaimAmount {  get; set; }
        public string Status {  get; set; }
        public string Policy {  get; set; }
        public Client Client { get; set; }


        public Claim()
        {
            
        }


        public Claim(int claimId,string claimNumber,DateTime dateFiled,decimal claimAmount,string status,string policy,Client client)
        {
            ClaimId = claimId;
            ClaimNumber = claimNumber;
            DateFiled = dateFiled;
            ClaimAmount = claimAmount;
            Status = status;
            Policy = policy;
            Client = client;

        }


        public override string ToString()
        {
            return $"ClaimId:{ClaimId},ClaimNumber:{ClaimNumber},DateFiled:{DateFiled},ClaimAmount:{ClaimAmount},Status:{Status},Policy:{Policy},Client:{Client.ClientName}";
        }







    }
}
