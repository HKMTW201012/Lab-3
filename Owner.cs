using System;
using System.Collections.Generic;

namespace SWENG421_Lab3
{
    public class Owner : Person, MessageSender, Evaluator
    {
        private bool isOutOfTown;
        private MessageSender delegatedSender; //The object of delegation, Manager or Accountant

        //Constructor
        public Owner(string name, int age) : base(name, age, "Owner")
        {
            isOutOfTown = false;
            delegatedSender = null;
        }

        //Declare if the owner is out of town
        public void SetOutOfTown(bool outOfTown)
        {
            isOutOfTown = outOfTown;
        }

        //Declare the objects of delegation
        public void DelegateSendTo(MessageSender helper)
        {
            delegatedSender = helper;
        }

        //Implements sending message
        public void Send(string message, IEnumerable<Employee> recipients)
        {
            if (isOutOfTown)
            {
                if (delegatedSender == null)
                    throw new InvalidOperationException("Owner is out of town !!!");

                delegatedSender.Send(message, recipients);
            }

            send(message, recipients);
        }

        //Implements evaluation
        public void Evaluate(Employee target, int score)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));
            if (score < 1 || score > 5) throw new ArgumentOutOfRangeException(nameof(score), "Likert score must be 1..5.");

            Console.WriteLine($"[Owner Evaluation] {Name} evaluated {target.Name} with Likert score {score}.");
        }

        //One private method in Owner
        private void send(string message, IEnumerable<Employee> recipients)
        {
            if (recipients == null) throw new ArgumentNullException(nameof(recipients));

            foreach (var e in recipients)
            {
                if (e == null) continue;
                Console.WriteLine($"[Text] From {Name} to {e.Name}: \"{message}\"");
            }
        }
    }
}
