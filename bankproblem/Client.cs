using System.Collections;
using System.Diagnostics;

namespace bankproblem{
    public class Client{
        public static void Main(){
            System.Console.WriteLine("Welcome to online bamking system");
            System.Console.WriteLine("choose below options to move forward");
            System.Console.WriteLine("1. Add your account to system \n2. Get the list of all acccounts \n3. Get the details of your account \n4. Deposit \n5. Withdraw \n6. Get transaction details of your account");
           
           System.Console.WriteLine("");
           
           BankRepository br = new BankRepository();

           int i=1;
           
           while(i==1){
            int ans = Convert.ToInt32(System.Console.ReadLine());
            switch (ans)
        {
           
            case 1: SBAccount sb = new SBAccount(123,"kush","delhi",5000000); 
                    br.NewAccount(sb);
                    break;
            case 2: List<SBAccount> listA = br.GetAllAccounts();
                    break;
            case 3: SBAccount a = br.GetAccountDetails(123);
                    break;
            case 4: br.DepositAmount(123,500000);
                    break;
            case 5: br.WithdrawAmount(123,50000);
                    break;
            case 6: List<SBTransaction> listT = br.GetTransactions(123);
                    break;
            default: break;
        }

            System.Console.WriteLine("if you want to continue type 1 else 0");
            i = Convert.ToInt32(System.Console.ReadLine());
           }
        }
    }
}