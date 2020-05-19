using System;
namespace Laboratorio_6
{
    [Serializable]
    public class Department:Division
    {
        public Department(string Name)
        {
            this.Name = Name;
        }
    }
}
