using AddressBook.Helper;
using AddressBook.Modules;
namespace PersonCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PersonHelper helper = new PersonHelper();
            Person person=new Person();
            Console.WriteLine(helper.AddPerson(person));
            Console.WriteLine("------------------------");

            List<Person> persons= helper.GetPersons();
            foreach(Person list in persons)
            {
                Console.WriteLine(list.personId);
                Console.WriteLine(list.title);
                Console.WriteLine(list.firstName);
                Console.WriteLine(list.lastName);
                Console.WriteLine(list.middleName);
                Console.WriteLine(list.age);
            }
            Console.WriteLine("------------------------");
            Console.WriteLine("Enter Id and FirstName to update");
            Console.WriteLine(helper.UpdateFirstName(Console.ReadLine(), Console.ReadLine()));
            List<Person> persons1 = helper.GetPersons();
            foreach (Person list in persons1)
            {
                Console.WriteLine(list.personId);
                Console.WriteLine(list.title);
                Console.WriteLine(list.firstName);
                Console.WriteLine(list.lastName);
                Console.WriteLine(list.middleName);
                Console.WriteLine(list.age);
            }
            Console.WriteLine("------------------------");
            Console.WriteLine("Enter Id and Age to update");
            Console.WriteLine(helper.UpdateAge(Console.ReadLine(),int.Parse(Console.ReadLine())));
            List<Person> persons2 = helper.GetPersons();
            foreach (Person list in persons2)
            {
                Console.WriteLine(list.personId);
                Console.WriteLine(list.title);
                Console.WriteLine(list.firstName);
                Console.WriteLine(list.lastName);
                Console.WriteLine(list.middleName);
                Console.WriteLine(list.age);
            }
            Console.WriteLine("------------------------");

          

            Console.WriteLine(helper.DeletePerson(1));
            List<Person> persons3 = helper.GetPersons();
            foreach (Person list in persons3)
            {
                Console.WriteLine(list.personId);
                Console.WriteLine(list.title);
                Console.WriteLine(list.firstName);
                Console.WriteLine(list.lastName);
                Console.WriteLine(list.middleName);
                Console.WriteLine(list.age);
            }
            Console.WriteLine("------------------------");



        }
    }
}