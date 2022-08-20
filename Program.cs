using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkCRUDconsole.Models;

namespace EntityFrameworkCRUDconsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Refresh();
            print("\nType an id");
            int id = int.Parse(Console.ReadLine());
            DeleteData(id);
            Refresh();
        }

        static void print(string Sentence)
        {
            Console.WriteLine(Sentence);
        }
        static void InsertDatas(int id, string name)
        {
            using (EmployeeEntities Employees = new EmployeeEntities())
            {
                Person person = new Person();
                person.id = id;
                person.name = name;
                Employees.Person.Add(person);
                Employees.SaveChanges();
            }
        }
        static void DeleteData(int idToDelete)
        {
            using (EmployeeEntities Employees = new EmployeeEntities())
            {
                Person person = Employees.Person.Find(idToDelete);
                Employees.Person.Remove(person);
                Employees.SaveChanges();
            }
        }
        static void UpdateDatas(int idToChange, string name)
        {
            using (EmployeeEntities Employees = new EmployeeEntities())
            {
                Person person = Employees.Person.Find(idToChange);
                person.name = name;
                Employees.Entry(person).State = System.Data.Entity.EntityState.Modified;
                Employees.SaveChanges();
            }
        }
        static void Refresh()
        {
            using (EmployeeEntities Employees = new EmployeeEntities())
            {
                var List = from Database in Employees.Person
                                select Database;
                ShowList(List.ToList());
            }
        }
        static void ShowList(List<Person> list)
        {
            foreach( Person person in list)
            {
                Console.WriteLine($"\nName: {person.name} \nId: {person.id}");
            }
            Console.ReadKey();
        }
    }
}
