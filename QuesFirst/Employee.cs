namespace firstconsolapp{
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public decimal Salary { get; set; }
        public DateTime DOJ { get; set; }
        
        // public Employee(int id, string name, decimal salary, DateTime doj )
        // {
        //     EmpId = id;
        //     EmpName=name
        //     Salary = salary;
        //     DOJ = doj;
        // }

        public void AcceptDetails(){
            Console.WriteLine("Enter the followind details: ");
            EmpId=Convert.ToInt32(System.Console.ReadLine());
            EmpName = System.Console.ReadLine();
            Salary = Convert.ToInt32(System.Console.ReadLine());
            DOJ = DateTime.Parse(System.Console.ReadLine());
        }
        public void DisplayDetails(){
            Console.WriteLine("the details for the employees are : {0} {1} {2} {3}",EmpId,EmpName,Salary,DOJ);
        }
        public virtual  void CalculateSalary(){
            Console.WriteLine("Salary is calculated according to the raole distictively");
        }
    }
}