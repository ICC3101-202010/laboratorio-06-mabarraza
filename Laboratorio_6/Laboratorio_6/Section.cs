using System;
namespace Laboratorio_6
{
    [Serializable]
    public class Section:Division
    {
        public Section(string Name)
        {
            this.Name = Name;
        }
    }
}
