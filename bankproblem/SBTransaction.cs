namespace bankproblem{
    public class SBTransaction{
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int AccountNumber { get; set; }
        public int Amount { get; set; }
        public string TransactionType { get; set; }

        public SBTransaction(int tId, DateTime tDate, int accNo, int amt , string tType){
           TransactionId = tId;
           TransactionDate = tDate;
           AccountNumber = accNo;
           Amount = amt;
           TransactionType = tType;
        }
    }
}