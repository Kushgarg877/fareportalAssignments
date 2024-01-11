namespace bankproblem{
    public class SBAccount{
        public int AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public int CurrentBalance { get; set; }

        
        public SBAccount(int accNo, string custName, string custAdd, int currBal){
            AccountNumber = accNo;
            CustomerName = custName;
            CustomerAddress = custAdd;
            CurrentBalance = currBal;
        }
    }
}