using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using coding_challenge.Entity;

namespace coding_challenge.Dao
{
     public interface IPolicyService
    {
        bool CreatePolicy(Policy policy);
        Policy GetPolicy(int  policyId);

        List<Policy>GetAllPolicies();

        bool UpdatePolicy (int PolicyId, string NewName, DateTime NewTiming, decimal newAmount);

        bool DeletePolicy(int policyId);

        bool CreateClient(Client client);
        bool UpdateClient(Client client);
        bool DeleteClient(int clientId);

        List<Client> GetAllClients();

        bool CreateClaim(Claim claim);
        bool UpdateClaim(Claim claim);
        bool DeleteClaim(int ClaimId);

    }
}
