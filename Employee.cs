namespace SWENG421_Lab3
{
    public abstract class Employee : Person
    {
        private decimal salary;
        private bool isAvailable; 

        protected Employee(string name, int age, string title, decimal startingSalary)
            : base(name, age, title)
        {
            salary = startingSalary;
            isAvailable = true;
        }

        //Everyone can view their own salary
        public decimal GetSalary()
        {
            return salary;
        }

        //Only Accountant can change salary
        protected internal void SetSalary(decimal newSalary)
        {
            salary = newSalary;
        }

        //Check whether the employee is available
        public bool IsAvailable()
        {
            return isAvailable;
        }

        //Set employee's availability
        public void SetAvailability(bool available)
        {
            isAvailable = available;
        }
    }
}
