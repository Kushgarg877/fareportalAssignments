namespace firstconsolapp{
    class Trainee:Employee{
        public int Tsalary;
        public string projectName;

        public void getTraineeDetails(){
            Console.WriteLine("Enter the followind details for Trainee employee: ");
            Tsalary=Convert.ToInt32(System.Console.ReadLine());
            projectName=System.Console.ReadLine();
        }
        public void showTraineeDetails(){
            Console.WriteLine("the details for the permanent employees are : {0} {1}",Tsalary,projectName);
        }
        public override void CalculateSalary(){
            if (projectName == "Banking"){
                Tsalary=(int)(Tsalary+ (0.05*Tsalary));
            }
            if (projectName == "Insurance"){
                Tsalary=(int)(Tsalary+(0.1*Tsalary));
            }
        }
    }

}