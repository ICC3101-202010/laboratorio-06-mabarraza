using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Laboratorio_6
{
    class MainClass
    {
        static void CompanyFile(IFormatter formatter)
        {

            Console.Write("Ingresa el nombre de tu empresa:");
            string name = Console.ReadLine();
            Console.Write("Ingresa el rut de tu empresa:");
            string id = Console.ReadLine();
            Company company = new Company(name, id);
            Stream stream = new FileStream("empresa.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, company);
            stream.Close();
        }

        public static void Main(string[] args)
        {
            int choice;
            Company company;
            IFormatter formatter = new BinaryFormatter();
            Stream stream;
        choice_input:
            Console.WriteLine("Desea utilizar un archivo con la información de la empresa?");
            Console.WriteLine("1. si\n2. no\n3. salir");
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
                if ((choice != 1) && (choice != 2)&&(choice != 3))
                {
                    Console.WriteLine("La opcion ingresada es incorrecta, porfvor vuelva a intentarlo!");
                    goto choice_input;
                }

            }
            catch(System.FormatException)
            {
                Console.WriteLine("Formato incorrecto , porfavor vuelva a intentarlo");
                goto choice_input;
            }
            if (choice == 1)
            {
                try
                {
                    stream = new FileStream("empresa.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                    company = (Company)formatter.Deserialize(stream);
                    stream.Close();
                    Console.WriteLine("Nombre de la empresa:{0}\nRut:{1}",company.Name,company.ID);
                }
                catch (System.IO.FileNotFoundException)
                {
                    Console.WriteLine("El archivo de su empresa no existe!");
                    Console.WriteLine("Porfavor ingrese sus datos para generar uno");
                    CompanyFile(formatter);

                }
            }
            else if (choice==2)
            {
                CompanyFile(formatter);
            }
            
        }
    }
}
