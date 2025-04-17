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
            bool leave = false;


            while (!leave)
            {

                Console.WriteLine("1.Create Policy");
                Console.WriteLine("2.get Policcy");
                Console.WriteLine("3.Get all Policies");
                Console.WriteLine("4.Update Policy");
                Console.WriteLine("5.Delete policy");
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
