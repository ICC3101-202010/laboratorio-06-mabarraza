using System;
using System.Collections.Generic;
namespace Laboratorio_6
{
    [Serializable]
    public sealed class Company
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public List<Division> divisions = new List<Division>();
        public Company(string Name , string ID)
        {
            this.Name = Name;
            this.ID = ID;
        }
    }
}
