namespace firstconsolapp{
    class Permanent:Employee{
        public int Basicpay { get; set; }
        public int HRA { get; set; }
        public int DA { get; set; }
        public int PF { get; set; }

        public void getDetails(){
            Console.WriteLine("Enter the followind details for permanent employee: ");
            Basicpay=Convert.ToInt32(System.Console.ReadLine());
            HRA=Convert.ToInt32(System.Console.ReadLine());
            DA=Convert.ToInt32(System.Console.ReadLine());
            PF=Convert.ToInt32(System.Console.ReadLine());
        }
        public void showDetails(){
            Console.WriteLine("the details for the permanent employees are : {0} {1} {2} {3} and salary is : {4}",Basicpay,HRA,DA,PF,Salary);
        }
        public override void CalculateSalary(){
            Salary = Basicpay+HRA+DA+PF;
        }

    }

}