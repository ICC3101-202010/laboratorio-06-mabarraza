using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Laboratorio_6
{
    class MainClass
    {
        static Person workercreation(Division d)
        {
            string[] names = { "Jose", "Tomas", "Daniel", "Claudio", "Raimundo", "Nicolas", "Miguel" };
            string[] lastnames = { "Morales", "Aramundiz", "Barrales", "Diaz", "Jofre", "Bravo", "Barraza" };
            string[] ids = { "19.293.950-k", "17.298.304-2", "18.079.694-k", "17.098.652-1", "18.290.341-9", "12.364.298-1", "7.988.131-7" };
            Random workername = new Random();
            Random workerlastname = new Random();
            Random workerid = new Random();
            int actualname = workername.Next(0, names.Length);
            int actualastname = workerlastname.Next(0, lastnames.Length);
            int actualid = workerid.Next(0, ids.Length);
            Person person;
            if(d.GetType()==typeof(Block))
                person = new Person(names[actualname], lastnames[actualastname], "personal general en el "+d.Name, ids[actualid]);
            else
                person = new Person(names[actualname], lastnames[actualastname], "Encargado en "+d.Name, ids[actualid]);
            return person;
        }
        static void SerCompanyFile(IFormatter formatter)
        {
            Console.Write("Ingresa el nombre de tu empresa:");
            string name = Console.ReadLine();
            Console.Write("Ingresa el rut de tu empresa:");
            string id = Console.ReadLine();
            Company company = new Company(name, id);
            Area area = new Area("Area de "+company.Name);
            Department department = new Department("Departamento de "+company.Name);
            Section section = new Section("Seccion de "+company.Name);
            Block block_a = new Block("Bloque A de "+company.Name);
            Block block_b = new Block("Bloque B de "+company.Name);
            company.divisions.Add(area);
            company.divisions.Add(department);
            company.divisions.Add(section);
            company.divisions.Add(block_a);
            company.divisions.Add(block_b);
            foreach (Division d in company.divisions)
            {
                if (d.GetType() == typeof(Block))
                {
                    d.worker.Add(workercreation(d));

                }
                d.worker.Add(workercreation(d));
            }
            Stream stream = new FileStream("empresa.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, company);
            stream.Close();
        }

        static void DesCompanyFile(IFormatter formatter)
        {
            Stream stream = new FileStream("empresa.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            Company company = (Company)formatter.Deserialize(stream);
            Console.WriteLine("Nombre de la empresa:{0}\nRut:{1}", company.Name, company.ID);
            foreach(Division d in company.divisions)
            {
                Console.WriteLine("Division: "+d.Name);
                Console.WriteLine("Trabajador/es:");
                foreach (Person p in d.worker)
                {
                    Console.WriteLine("\tNombre:{0}\n\tApellido:{1}\n\tRut:{2}\n\tCargo:{3}\n", p.Name,p.LastName,p.ID,p.Position);
                }
            }
            stream.Close();
        }

        public static void Main(string[] args)
        {
            int choice;
            IFormatter formatter = new BinaryFormatter();
        choice_input:
            Console.WriteLine("Desea utilizar un archivo con la información de la empresa?");
            Console.WriteLine("1. si\n2. no\n3. salir");
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
                if ((choice != 1) && (choice != 2) && (choice != 3))
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
                    DesCompanyFile(formatter);
                }
                catch (System.IO.FileNotFoundException)
                {
                    Console.WriteLine("El archivo de su empresa no existe!");
                    Console.WriteLine("Porfavor ingrese sus datos para generar uno");
                    SerCompanyFile(formatter);

                }
            }
            else if (choice==2)
            {
                SerCompanyFile(formatter);
            }
            
        }
    }
}
