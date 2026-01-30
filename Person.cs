namespace SWENG421_Lab3

{
    //Abstract base class for Owner and Employee
    public abstract class Person
    {
        private string name;
        private int age;
        private string title;

        protected Person(string name, int age, string title)
        {
            this.name = name;
            this.age = age;
            this.title = title;
        }

        public string Name
        {
            get { return name; }
        }

        public int Age
        {
            get { return age; }
        }

        public string Title
        {
            get { return title; }
        }
    }
}
