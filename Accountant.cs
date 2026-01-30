using System;

namespace SWENG421_Lab3
{
    public class Accountant : Employee, SalaryUpdater, TaskPerformer
    {
        private const decimal STARTING_STIPEND = 45_000m;

        private bool isOutOfTown;
        private SalaryUpdater delegatedUpdater; 
        private TaskPerformer delegatedPerformer;

        //Constructor
        public Accountant(string name, int age)
            : base(name, age, "Accountant", STARTING_STIPEND)
        {
            isOutOfTown = false;
            delegatedUpdater = null;
            delegatedPerformer = null;
        }

        public void SetOutOfTown(bool outOfTown)
        {
            isOutOfTown = outOfTown;
        }

        public void DelegateSalaryUpdateTo(SalaryUpdater helper)
        {
            delegatedUpdater = helper;
        }

        public void DelegateTaskTo(TaskPerformer helper)
        {
            delegatedPerformer = helper;
        }

        //Implements updating salary
        public void UpdateSalary(Employee target, decimal amount)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));

            //Delegation starts here
            if (isOutOfTown)
            {
                if (delegatedUpdater == null)
                    throw new InvalidOperationException("Accountant is unavailable !!!");

                delegatedUpdater.UpdateSalary(target, amount); //Delegation
                return;
            }

            update(target, amount);
        }

        //Implements task
        public void Perform(Task task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));

            if (isOutOfTown)
            {
                if (delegatedPerformer == null)
                    throw new InvalidOperationException("Accountant is unavailable, but no delegated TaskPerformer is assigned.");

                delegatedPerformer.Perform(task);
                return;
            }

            Console.WriteLine($"[Task Help] {Name} (Accountant) helps perform Task #{task.Id}: {task.Description} (Due {task.DueDate:d}).");
        }

        //One private method in Accountant
        private void update(Employee target, decimal amount)
        {
            var oldSalary = target.GetSalary();
            var newSalary = oldSalary + amount;

            target.SetSalary(newSalary);

            Console.WriteLine($"[Salary Update] {Name} updated {target.Name}'s salary: {oldSalary:C} -> {newSalary:C} (Change {amount:C}).");
        }
    }
}
