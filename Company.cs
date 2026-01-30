using System;
using System.Collections.Generic;
using System.Linq;

namespace SWENG421_Lab3
{
    public class Company
    {
        private Owner owner;
        private List<Employee> employees;

        public Company(Owner owner)
        {
            this.owner = owner ?? throw new ArgumentNullException(nameof(owner));
            employees = new List<Employee>();
        }

        public Owner Owner
        {
            get { return owner; }
        }

        public void AddEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            employees.Add(employee);
        }

        public IReadOnlyList<Employee> Employees
        {
            get { return employees.AsReadOnly(); }
        }

        public Employee? FindEmployeeByName(string name)
        {
            return employees.FirstOrDefault(e =>
                e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Employee> FindEmployeesByNames(params string[] names)
        {
            var set = new HashSet<string>(names, StringComparer.OrdinalIgnoreCase);

            foreach (var e in employees)
            {
                if (set.Contains(e.Name))
                    yield return e;
            }
        }
    }
}
