namespace Exception_assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
                HMBank acc1 = new HMBank("9874", 6000,"savings",1000);
                HMBank acc2 = new HMBank("9875", 8000, "current", 2000);

            
                    acc1.Display();
                    acc2.Display();


                try
                {
                    acc1.Withdraw(8000);
                }
                catch (InsufficientFundException e)
                {
                    Console.WriteLine($"Insuff fund:{e.Message}");
                }

                try
                {
                    acc1.Transfer(7000.00, acc2.account_num);
                }
                catch (InsufficientFundException e)
                {
                    Console.WriteLine($"Insuff fund:{e.Message}");
                }

                try
                {
                    acc2.Transfer(3000.00, "123456789");
                }

                catch(InvalidAccountException e)
                { 
            
                    Console.WriteLine($"Invalid acc:{e.Message}");
                }
                try
                {

                    acc2.Withdraw(1500.00);
                }
                catch (OverDraftLimitExcededException e)
                {
                    Console.WriteLine($"Overlimit:{e.Message}");
                }
            

           

            

          

          


        }
    }
}
