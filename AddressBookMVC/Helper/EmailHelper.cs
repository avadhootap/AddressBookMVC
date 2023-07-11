 using AddressBook.Modules;
using System.Data;
using System.Runtime.InteropServices;

namespace AddressBook.Helper
{
    public class EmailHelper
    {
       //static List<EmailAddress>emails = new List<EmailAddress>();
       // EmailAddress mails=new EmailAddress();

        public void AddEmail(EmailAddress emailAddress)
        {
            DataAccess dataAccess = new DataAccess();
            string query = "insert into emails(EId,EmailAdd,EmailType,personId,isDelete)values(@EId,@EmailAdd,@EmailType,@personId,@isDelete)";
            Dictionary<string, object> data = new Dictionary<String, object>
            {
                {"@EId",emailAddress.EId=Guid.NewGuid().ToString() },
                {"@EmailAdd",emailAddress.EmailAdd},
                {"@EmailType",emailAddress.EmailType },
                {"@personId",emailAddress.personId },
                {"@isDelete",false }
            };
            dataAccess.adddata(query,data);

        }

        public List<EmailAddress> GetAllEmails([Optional]string id)
        {
            Console.WriteLine("Person Id : "+id);
            List<EmailAddress> emails = new List<EmailAddress>();
            if(id != null)
            {
                string query = "select * from emails where personId=@personId and isDelete=0";
                DataAccess dataAccess = new DataAccess();
                DataTable data = dataAccess.Get(query,id);
                foreach (DataRow rows in data.Rows)
                {
                    EmailAddress emailAddress = new EmailAddress();
                    emailAddress.EId = rows["EId"].ToString();
                    emailAddress.EmailAdd = rows["EmailAdd"].ToString();
                    emailAddress.EmailType = (EmailType)Enum.Parse(typeof(EmailType), rows["EmailType"].ToString());
                    emailAddress.personId = rows["personId"].ToString();

                    emails.Add(emailAddress);

                }
                return emails;
            }
            else
            {
                string query = "select * from emails where isDelete=0";
                DataAccess dataAccess = new DataAccess();
                DataTable data = dataAccess.Get(query);
                foreach (DataRow rows in data.Rows)
                {
                    EmailAddress emailAddress = new EmailAddress();
                    emailAddress.EId = rows["EId"].ToString();
                    emailAddress.EmailAdd = rows["EmailAdd"].ToString();
                    emailAddress.EmailType = (EmailType)Enum.Parse(typeof(EmailType), rows["EmailType"].ToString());
                    emailAddress.personId = rows["personId"].ToString();

                    emails.Add(emailAddress);

                }
                return emails;
            }

        }

        public void UpdateEmailId(EmailAddress EAddress)
        {
            DataAccess dataAccess = new DataAccess();
            string query = "update emails set Eid=@Eid,EmailAdd=@EmailAdd,EmailType=@EmailType,personId=@personId where Eid=@Eid";
            Dictionary<string, object> data = new Dictionary<string, object>
            {
                {"@Eid",EAddress.EId },
                {"@EmailAdd",EAddress.EmailAdd },
                {"@EmailType",EAddress.EmailType },
                {"@personId",EAddress.personId}

            };
            dataAccess.updatedata(query, data);
        }

        public void deleteEmail(string id)
        {
            string query = "update emails set isDelete=1 where Eid=@Eid";
            DataAccess dataAccess = new DataAccess();
            Dictionary<string, object> mydictionary = new Dictionary<string, object>
            {
                {"@Eid",id }
            };

            dataAccess.DeleteData(query, id, mydictionary);
        }

        //public List<EmailAddress> GetEmailAddressesByPersonId(string id)
        //{
        //    List<EmailAddress> emails = new List<EmailAddress>();
        //    string query = "select * from emails where personId=@personId";
        //    DataAccess dataAccess = new DataAccess();
        //    DataTable data = dataAccess.Get(query, id);
        //    for (int i = 0; i < data.Rows.Count; i++)
        //    {
        //        EmailAddress email = new EmailAddress();
        //        email.EId = data.Rows[i]["EId"].ToString();
        //        email.EmailAdd = data.Rows[i]["EmailAdd"].ToString();
        //        email.EmailType = (EmailType)Enum.Parse(typeof(EmailType), data.Rows[i]["EmailType"].ToString());
        //        email.personId = data.Rows[i]["personId"].ToString();
        //        emails.Add(email);
        //    }
        //    return emails;

        //}

        //public void AddEmail(EmailAddress emailAddress)
        //{
        //    emailAddress.EId=Guid.NewGuid().ToString();
        //    DataAccess dataAccess = new DataAccess();
        //    string query = "insert into emails(EId,EmailAdd,EmailType,personId,isDelete)values(@EId,@EmailAdd,@EmailType,@personId,@isDelete)";
        //    Dictionary<string, object> mydictionary = new Dictionary<string, object>
        //    {
        //        {"@EId",emailAddress.EId},
        //        {"@EmailAdd",emailAddress.EmailAdd },
        //        {"@EmailType",emailAddress.EmailType },
        //        {"@personId",emailAddress.personId },
        //        {"@isDelete",false }
        //    };
        //    dataAccess.adddata(query,mydictionary);

        //}

        //public List<EmailAddress>GetDyanamic(string id)
        //{
        //    List<EmailAddress> emails = new List<EmailAddress>();
        //    DataAccess dataAccess = new DataAccess();
        //    if (string.IsNullOrEmpty(id))
        //    {
        //        string query = "select * from emails where isDelete=0";
        //        DataTable data = dataAccess.Get(query);
        //        foreach (DataRow rows in data.Rows)
        //        {
        //            EmailAddress emailAddress = new EmailAddress();
        //            emailAddress.EId = rows["EId"].ToString();
        //            emailAddress.EmailAdd = rows["EmailAdd"].ToString();
        //            emailAddress.EmailType = (EmailType)Enum.Parse(typeof(EmailType), rows["EmailType"].ToString());
        //            emailAddress.personId = rows["personId"].ToString();

        //            emails.Add(emailAddress);

        //        }
        //        return emails;
        //    }
        //    else
        //    {
        //        string query = "select * from emails where personId=@personId";
        //        DataTable data = dataAccess.GetDetailsBypersonId(query, id);
        //        for (int i = 0; i < data.Rows.Count; i++)
        //        {
        //            EmailAddress email = new EmailAddress();
        //            email.EId = data.Rows[i]["EId"].ToString();
        //            email.EmailAdd = data.Rows[i]["EmailAdd"].ToString();
        //            email.EmailType = (EmailType)Enum.Parse(typeof(EmailType), data.Rows[i]["EmailType"].ToString());
        //            email.personId = data.Rows[i]["personId"].ToString();
        //            emails.Add(email);
        //        }
        //        return emails;
        //    }
        //}
    }
}
