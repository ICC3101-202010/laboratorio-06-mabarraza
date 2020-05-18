using System;
namespace Laboratorio_6
{
    [Serializable]
    public class Company
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public Company(string Name , string ID)
        {
            this.Name = Name;
            this.ID = ID;
        }
    }
}
