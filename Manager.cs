using System;

namespace SWENG421_Lab3
{
    public class Manager : Employee, Evaluator
    {
        private const decimal STARTING_STIPEND = 50_000m;

        private bool isOutOfTown;
        private Evaluator delegatedEvaluator; //The delegation objects

        //Constructor
        public Manager(string name, int age) : base(name, age, "Manager", STARTING_STIPEND)
        {
            isOutOfTown = false;
            delegatedEvaluator = null;
        }

        //Declare the manager is out of town
        public void SetOutOfTown(bool outOfTown)
        {
            isOutOfTown = outOfTown;
        }

        public void DelegateEvaluateTo(Evaluator helper)
        {
            delegatedEvaluator = helper;
        }

        //Implements evaluation
        public void Evaluate(Employee target, int score)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            if (score < 1 || score > 5)
                throw new ArgumentOutOfRangeException(nameof(score), "Likert score must be 1..5.");

            if (isOutOfTown)
            {
                if (delegatedEvaluator == null)
                    throw new InvalidOperationException("Manager is out of town !!!");

                delegatedEvaluator.Evaluate(target, score); //Delegation
                return;
            }

            if (target is not Accountant && target is not Blacksmith)
            {
                throw new InvalidOperationException("Manager can only evaluate an Accountant or a Blacksmith.");
            }

            evaluate(target, score);
        }

        //One private method in Manager
        private void evaluate(Employee target, int score)
        {
            Console.WriteLine($"[Manager Evaluation] {Name} evaluated {target.Name} with Likert score {score}.");
        }
    }
}
