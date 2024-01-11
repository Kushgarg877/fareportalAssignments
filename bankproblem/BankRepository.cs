using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Collections;

namespace bankproblem{
    public class BankRepository:IBankRepository{
        List<SBAccount> sba = new List<SBAccount>();
        List<SBTransaction> sbt = new List<SBTransaction>();

        
        public void NewAccount(SBAccount acc){
            sba.Add(acc);
        }
        public List<SBAccount> GetAllAccounts(){
            return sba;
        }
        public SBAccount GetAccountDetails(int accno){
            foreach(SBAccount acc in sba){
                if (acc.AccountNumber==accno){
                    return acc;
                }
            }
            return null;
        }
        public void DepositAmount(int accno, decimal amt){
            int tId = sbt.Last().TransactionId+1;
            DateTime tDate = DateTime.Now;
            int newAmt=0;
            foreach(SBAccount acc in sba){
                if (acc.AccountNumber == accno){
                    acc.CurrentBalance += (int)amt;
                    newAmt = acc.CurrentBalance;
                }
            }
            String tType = "Deposit";
            SBTransaction newT = new SBTransaction(tId,tDate,accno,(int)newAmt,tType);
            sbt.Add(newT);

        }
        public void WithdrawAmount(int accno, decimal amt){
            int tId = sbt.Last().TransactionId+1;
            DateTime tDate = DateTime.Now;
            int newAmt=0;
            foreach(SBAccount acc in sba){
                if (acc.AccountNumber == accno){
                    if(acc.CurrentBalance < amt){
                        System.Console.WriteLine("Not enough balance...Loan is provided");
                    }
                    acc.CurrentBalance -= (int)amt;
                    newAmt = acc.CurrentBalance;
                }
            }
            String tType = "Withdraw";
            SBTransaction newT = new SBTransaction(tId,tDate,accno,(int)newAmt,tType);
            sbt.Add(newT);
        }
        public List<SBTransaction> GetTransactions(int accno){
            List<SBTransaction> listT= new List<SBTransaction>();
            foreach(SBTransaction trans in sbt ){
                if(trans.AccountNumber == accno){
                    listT.Add(trans);
                }
            }
            return listT;
        }
    }
}