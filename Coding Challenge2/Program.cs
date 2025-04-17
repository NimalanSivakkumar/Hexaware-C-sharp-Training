using coding_challenge.Dao;
using coding_challenge.Entity;
using coding_challenge.ExceptionInfor;

namespace coding_challenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPolicyService service = new InsuranceServiceImplementation();
            


            while (true)
            {

                Console.WriteLine("1.Create Policy");
                Console.WriteLine("2.get Policcy");
                Console.WriteLine("3.Get all Policies");
                Console.WriteLine("4.Update Policy");
                Console.WriteLine("5.Delete policy");
                Console.WriteLine("6.Create Client");
                Console.WriteLine("7.Update client");
                Console.WriteLine("8.Delete Client");
                Console.WriteLine("9.View all clients");
                Console.WriteLine("10.Create Claim");
                Console.WriteLine("11.Update Claim");
                Console.WriteLine("12.Delete Claim");
                Console.WriteLine("Enter your choice");
                int choice = Convert.ToInt32(Console.ReadLine());

                try
                {

                    switch(choice)
                    {

                        case 1:

                            Console.WriteLine("Enter Policy Id");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Policy Name:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter policy duration");
                            DateTime duration = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("Enter policy amount");
                            decimal amount = Convert.ToDecimal(Console.ReadLine());

                            Policy newPolicy = new Policy(id,name,duration,amount);

                            service.CreatePolicy(newPolicy);

                            break;

                        case 2:
                            Console.WriteLine("Enter Policy Id");
                            id = Convert.ToInt32(Console.ReadLine());

                            var policy = service.GetPolicy(id);
                            Console.WriteLine(policy);
                            break;

                        case 3:

                            foreach (var p in service.GetAllPolicies())
                                Console.WriteLine(p);
                            break;

                        case 4:

                            Console.WriteLine("Enter PolicyId to do updation");
                            int newid = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter new policy Name");
                            string newname = Console.ReadLine();

                            Console.WriteLine("Enter new duration");
                            DateTime newDuration = Convert.ToDateTime(Console.ReadLine());

                            Console.WriteLine("enter new amount");
                            decimal newamount = Convert.ToDecimal(Console.ReadLine());


                            bool update = service.UpdatePolicy(newid, newname, newDuration, newamount);

                            Console.WriteLine(update);

                            break;

                        case 5:

                            Console.WriteLine("Enter policy Id to delete");
                            int delid = Convert.ToInt32(Console.ReadLine());
                            service.DeletePolicy(delid);
                            Console.WriteLine("policy Deleted");
                            break;


                        case 6:
                            Console.Write("Enter Client ID: ");
                            int cid = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter Client Name: ");
                            string cname = Console.ReadLine();
                            Console.Write("Enter Contact Info: ");
                            string contact = Console.ReadLine();
                            Console.Write("Enter Policy: ");
                            string pol = Console.ReadLine();

                            Client client = new Client(cid, cname, contact, pol);

                            Console.WriteLine(service.CreateClient(client));
                            break;

                        case 7:

                            Console.Write("Enter Client ID: ");
                            int upCid = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter New Name: ");
                            string upCName = Console.ReadLine();
                            Console.Write("Enter New Contact Info: ");
                            string upContact = Console.ReadLine();
                            Console.Write("Enter New Policy: ");
                            string upPolicy = Console.ReadLine();

                            Client upClient = new Client(upCid, upCName, upContact, upPolicy);
                            Console.WriteLine(service.UpdateClient(upClient));
                            break;

                        case 8:
                            Console.Write("Enter Client ID to delete: ");
                            Console.WriteLine(service.DeleteClient(Convert.ToInt32(Console.ReadLine())));
                            break;


                        case 9:
                            foreach (Client c in service.GetAllClients())
                                Console.WriteLine(c);
                            break;

                        case 10:
                            Console.Write("Enter Claim ID: ");
                            int clid = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter Claim Number: ");
                            string clnum = Console.ReadLine();
                            Console.Write("Enter Date Filed ");
                            DateTime cdate = Convert.ToDateTime(Console.ReadLine());
                            Console.Write("Enter Claim Amount: ");
                            decimal camount = Convert.ToDecimal(Console.ReadLine());
                            Console.Write("Enter Status: ");
                            string cstatus = Console.ReadLine();
                            Console.Write("Enter Policy Id: ");
                            int cpol = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter Client: ");
                            int ccli = Convert.ToInt32(Console.ReadLine());

                            Claim claim = new Claim(clid, clnum, cdate, camount, cstatus, cpol, ccli);
                            Console.WriteLine(service.CreateClaim(claim));
                            break;

                            case 11:

                            Console.Write("Enter Claim ID: ");
                            int updatelid = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter Claim Number: ");
                            string updateclnum = Console.ReadLine();
                            Console.Write("Enter Date Filed ");
                            DateTime updatecdate = Convert.ToDateTime(Console.ReadLine());
                            Console.Write("Enter Claim Amount: ");
                            decimal updatecamount = Convert.ToDecimal(Console.ReadLine());
                            Console.Write("Enter Status: ");
                            string updatecstatus = Console.ReadLine();
                            Console.Write("Enter Policy Id: ");
                            int updatecpol = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter Client: ");
                            int updateccli = Convert.ToInt32(Console.ReadLine());

                            Claim updatedClaim = new Claim(updatelid, updateclnum, updatecdate, updatecamount, updatecstatus, updatecpol, updateccli);
                            Console.WriteLine(service.UpdateClaim(updatedClaim));
                            break;

                        case 12:
                            Console.Write("Enter Claim ID to delete: ");
                            clid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(service.DeleteClaim(clid));
                            break;



                        default:
                            Console.WriteLine("Invalid choice");
                            break;




                    }



                }

                catch(PolicyNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }

                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }








            }





        }
    }
}
