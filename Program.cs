using System;

namespace SWENG421_Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create Owner & Company
            Owner craig = new Owner("Craig", 55);
            Company company = new Company(craig);


            //Create Managers
            Manager john = new Manager("John", 40);
            Manager mary = new Manager("Mary", 42);

            //Create Accountants
            Accountant jane = new Accountant("Jane", 38);
            Accountant joe = new Accountant("Joe", 45);

            //Create Blacksmiths
            Blacksmith jack = new Blacksmith("Jack", 30);
            Blacksmith katie = new Blacksmith("Katie", 28);
            Blacksmith amy = new Blacksmith("Amy", 26);
            Blacksmith lin = new Blacksmith("Lin", 35);
            Blacksmith greg = new Blacksmith("Greg", 33);

            // Add employees to company
            company.AddEmployee(john);
            company.AddEmployee(mary);
            company.AddEmployee(jane);
            company.AddEmployee(joe);
            company.AddEmployee(jack);
            company.AddEmployee(katie);
            company.AddEmployee(amy);
            company.AddEmployee(lin);
            company.AddEmployee(greg);

            //Create tasks
            Task t1 = new Task(1, DateTime.Today.AddDays(3), "Forge sword");
            Task t2 = new Task(2, DateTime.Today.AddDays(5), "Repair armor");
            Task t3 = new Task(3, DateTime.Today.AddDays(7), "Craft shield");

 
            //Task 1: Craig sends "Good Job" to John, Jane, and Jack
            Console.WriteLine("Scenario 1: Craig sends \"Good Job\" to John, Jane, and Jack");

            Employee[] receivers = { john, jane, jack };
            craig.Send("Good Job", receivers);
            Console.WriteLine();

            //Task 2: Greg performs his own task and helps Amy
            Console.WriteLine("Scenario 2: Greg performs t1 and helps Amy with t2");

            greg.Perform(t1);
            greg.Perform(t2);
            Console.WriteLine();

            //Task 3: Jane updates Greg's salary and helps Lin
            Console.WriteLine("Scenario 3: Jane updates Greg's salary and helps Lin");

            Console.WriteLine("Greg salary BEFORE: $" + greg.GetSalary());
            jane.UpdateSalary(greg, 1000m);
            Console.WriteLine("Greg salary AFTER : $" + greg.GetSalary());

            jane.Perform(t3);
            Console.WriteLine();

            //Task 4: Normal evaluation
            Console.WriteLine("Scenario 4: Normal evaluation");

            john.Evaluate(jack, 3);
            mary.Evaluate(katie, 4);
            Console.WriteLine();


            //Task 5: John is out of town, delegates evaluation to Craig
            Console.WriteLine("Scenario 5: John is out of town -> delegates evaluation to Craig");

            //Mark John as unavailable
            john.SetAvailability(false);

            //John delegates evaluation responsibility to Craig
            john.DelegateEvaluateTo(craig);

            //Calls are made on John, but execution is delegated to Craig
            john.Evaluate(jack, 4);
            john.Evaluate(katie, 5);

            Console.WriteLine();
            Console.WriteLine("Here is Changed!!!");
        }
    }
}
