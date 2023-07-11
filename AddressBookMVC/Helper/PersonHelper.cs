using AddressBook.Modules;
using System;
using System.Data;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Xml.Linq;

namespace AddressBook.Helper
{
    public class PersonHelper
    {

        //public void AddPerson(Person person)
        //{

        //    DataAccess dataAccess = new DataAccess();
        //    person.personId = Guid.NewGuid().ToString();
        //    string query = "Insert into person (personId,title,firstName,lastName,middleName,age,DOB,gender,category) values (@personId,@title,@firstName,@lastName,@middleName,@age,@DOB,@gender,@category)";
        //    dataAccess.add(query, person);

        //}

        public void addPerson(Person person)
        {
            string query = "Insert into person (personId,title,firstName,lastName,middleName,age,DOB,gender,category,isDelete) values (@personId,@title,@firstName,@lastName,@middleName,@age,@DOB,@gender,@category,@isDelete)";
            DataAccess data = new DataAccess();
            Dictionary<string, object> mydictionary = new Dictionary<string, object>
            {
                { "@personId",person.personId = Guid.NewGuid().ToString()},
                { "@title",person.title},
                { "@firstName",person.firstName},
                { "@lastName",person.lastName},
                { "@middleName",person.middleName},
                { "@age",person.age },
                { "@DOB",person.DOB },
                { "@gender",person.gender},
                { "@category",person.category},
                { "@isDelete",false }
            };
            data.adddata(query, mydictionary);

        }


        public List<Person> GetPersons() 
        {
            List<Person> persons = new List<Person>();
            DataAccess dataAccess = new DataAccess();   
            string query = "select * from person where isDelete=0";
            DataTable data= dataAccess.Get(query);
            
            foreach (DataRow rows in data.Rows)
            {
               
                Person person = new Person();
                person.personId = rows["personId"].ToString();
                person.title= rows["Title"].ToString();
                person.firstName = rows["firstName"].ToString() ;
                person.lastName = rows["lastName"].ToString();
                person.middleName = rows["middleName"].ToString();
                person.age =Convert.ToInt32 (rows["age"]);
                person.DOB = Convert.ToDateTime(rows["DOB"]);
                person.gender = (GenderType)Enum.Parse(typeof(GenderType), rows["gender"].ToString());
                person.category = (CategoryType)Enum.Parse(typeof(CategoryType), rows["category"].ToString());
                persons.Add(person);
            }
           
            return (persons);
        }

        public void DeletePerson(string id)
        {
            
            string query = "update person set isDelete=1 where personId=@personId";
            DataAccess data=new DataAccess();
            Dictionary<string, object> mydictionary = new Dictionary<string, object>
            {
                {"@personId",id}

            };
            data.DeleteData(query,id,mydictionary);
    
        }

        public void UpdatePerson(Person person) 
        {
            string query = "update person set personId=@personId,title=@title,firstName=@firstName,lastName=@lastName,middleName=@middleName,age=@age,DOB=@DOB,gender=@gender,category=@category where personId=@personId";
            DataAccess data = new DataAccess();
            Dictionary<string, object> mydictionary = new Dictionary<string, object>
            {
                { "@personId",person.personId },
                { "@title",person.title},
                { "@firstName",person.firstName},
                { "@lastName",person.lastName},
                { "@middleName",person.middleName},
                { "@age",person.age },
                { "@DOB",person.DOB },
                { "@gender",person.gender},
                { "@category",person.category},
                { "@isDelete",false }

            };
            data.updatedata(query, mydictionary);

        }
  
    }
}
