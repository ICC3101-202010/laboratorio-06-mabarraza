using System;
namespace Laboratorio_6
{
    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string ID { get; set; }
        public Person(string Name, string LastName , string Position , string ID)
        {
            this.Name = Name;
            this.LastName = LastName;
            this.Position = Position;
            this.ID = ID;
        }
    }
}
