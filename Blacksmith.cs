using System;

namespace SWENG421_Lab3
{
    public class Blacksmith : Employee, TaskPerformer
    {
        private const decimal STARTING_STIPEND = 35_000m;

        private bool isUnavailable;
        private TaskPerformer delegatedPerformer;

        //Constructor
        public Blacksmith(string name, int age)
            : base(name, age, "Blacksmith", STARTING_STIPEND)
        {
            isUnavailable = false;
            delegatedPerformer = null;
        }

        public void SetUnavailable(bool unavailable)
        {
            isUnavailable = unavailable;
        }

        public void RequestHelpFrom(TaskPerformer helper)
        {
            delegatedPerformer = helper;
        }

        //Implements performance
        public void Perform(Task task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));

            //Delegation starts here
            if (isUnavailable)
            {
                if (delegatedPerformer == null)
                    throw new InvalidOperationException("Blacksmith is unavailable, but no delegated TaskPerformer was assigned.");

                delegatedPerformer.Perform(task); //Delegation
                return;
            }

            perform(task);
        }

        //One private method in Blacksmith
        private void perform(Task task)
        {
            Console.WriteLine($"[Task] {Name} performed Task #{task.Id}: {task.Description} (Due {task.DueDate:d}).");
        }
    }
}
