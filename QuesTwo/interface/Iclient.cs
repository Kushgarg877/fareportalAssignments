namespace interface{
    class Iclient{
        public static void Main(){

            Permanent p = new Permanent();
            p.acceptDetails();
            p.calculateSalary();
            p.displayDetails();

            Trainee t = new Trainee();
            t.acceptDetails();
            t.calculateSalary();
            t.displayDetails();
        }
    }
}