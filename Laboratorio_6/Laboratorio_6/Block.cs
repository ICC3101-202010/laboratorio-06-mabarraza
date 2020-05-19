using System;
namespace Laboratorio_6
{
    [Serializable]
    public class Block:Division
    {
        public Block(string Name)
        {
            this.Name = Name;
        }
    }
}
