namespace firstconsolapp{
    class Client{
        public static void Main(){

            Employee e = new Employee();
            e.AcceptDetails();
            e.DisplayDetails();
            e.CalculateSalary();

            Permanent p = new Permanent();
            p.getDetails();
            p.CalculateSalary();
            p.showDetails();

            Trainee t = new Trainee();
            t.getTraineeDetails();
            t.CalculateSalary();
            t.showTraineeDetails();
        }
    }
}