using System;
using System.Collections.Generic;
namespace Laboratorio_6
{
    [Serializable]
    public class Division
    {
        public string Name { get; set; }
        public List<Person> worker = new List<Person>();
    }
}
