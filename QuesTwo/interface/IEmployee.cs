namespace interface{
    interface IEmployee{
        int EmployeeId { get; set; }
        string empName { get; set; }
     `  DateTime DateOfJoining { get; set; }
        decimal Salary { get; set; }

        public void acceptDetails();
        public void calculateSalary();
        public void displayDetails();
        
    }
}