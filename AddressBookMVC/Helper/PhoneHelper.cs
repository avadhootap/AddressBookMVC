using AddressBook.Modules;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Runtime.InteropServices;

namespace AddressBook.Helper
{
    public class PhoneHelper
    {
        //static List<PhoneNo>phoneNos = new List<PhoneNo>();
        //PhoneNo Myphone=new PhoneNo();
        public void AddPhone(PhoneNo phoneNo)
        {
            DataAccess dataAccess = new DataAccess();
            string query = "Insert into phoneNos(phoneNoId,phoneNoType,phoneNo,personId,isDelete)values(@phoneNoId,@phoneNoType,@phoneNo,@personId,@isDelete)";
            Dictionary<string, object> data = new Dictionary<string, object>
            {
                {"@phoneNoId",phoneNo.phoneNoId=Guid.NewGuid().ToString()},
                {"@phoneNoType",phoneNo.phoneNoType },
                {"@phoneNo",phoneNo.phoneNo },
                {"@personId",phoneNo.personId },
                {"@isDelete",false }
            };
            dataAccess.adddata(query, data);
        }

        public List<PhoneNo> GetAllPhoneNos([Optional]string id)
        {
            List<PhoneNo> phoneNos = new List<PhoneNo>();
            if(id != null)
            {
                DataAccess dataAccess = new DataAccess();
                string query = "select * from PhoneNos where personId=@personId and isDelete=0";
                DataTable data = dataAccess.Get(query,id);
                foreach (DataRow rows in data.Rows)
                {
                    PhoneNo phones = new PhoneNo();
                    phones.phoneNoId = rows["phoneNoId"].ToString();
                    phones.phoneNo = Convert.ToInt64(rows["phoneNo"]);
                    phones.phoneNoType = (PhoneNoType)Enum.Parse(typeof(PhoneNoType), rows["phoneNoType"].ToString());
                    phones.personId = rows["personId"].ToString();
                    phoneNos.Add(phones);

                }
                return phoneNos;
            }
            else
            {
                DataAccess dataAccess = new DataAccess();
                string query = "select * from PhoneNos where isdelete=0;";
                DataTable data = dataAccess.Get(query);
                foreach (DataRow rows in data.Rows)
                {
                    PhoneNo phones = new PhoneNo();
                    phones.phoneNoId = rows["phoneNoId"].ToString();
                    phones.phoneNo = Convert.ToInt64(rows["phoneNo"]);
                    phones.phoneNoType = (PhoneNoType)Enum.Parse(typeof(PhoneNoType), rows["phoneNoType"].ToString());
                    phones.personId = rows["personId"].ToString();
                    phoneNos.Add(phones);

                }
                return phoneNos;
            }

        }

        public void UpdatePhoneNo(PhoneNo phoneNoss)
        {
            DataAccess dataAccess=new DataAccess();
            string query = "Update phoneNos set phoneNoId=@phoneNoId,phoneNoType=@phoneNoType,phoneNo=@phoneNo,personId=@personId where phoneNoId=@phoneNoId";
            Dictionary<string, object> mydictionary = new Dictionary<string, object>
            {
                {"@phoneNoId",phoneNoss.phoneNoId },
                {"@phoneNoType",phoneNoss.phoneNoType },
                {"@phoneNo",phoneNoss.phoneNo},
                {"@personId",phoneNoss.personId }
            };
            dataAccess.updatedata(query,mydictionary);
        }
        
        public void DeletePhoneNo(string id)
        {
            DataAccess dataAccess = new DataAccess();
            string query = "update phonenos set isDelete=1 where phoneNoId=@phoneNoId";
            Dictionary<string, object> mydictionary = new Dictionary<string, object>
            {
                {"@phoneNoId",id }
            };
            dataAccess.DeleteData(query,id,mydictionary);


        }

        //public void AddPhoneNos(PhoneNo phoneNo)
        //{
        //    phoneNo.phoneNoId=Guid.NewGuid().ToString();
        //    DataAccess dataAccess = new DataAccess();
        //    string query = "Insert into phoneNos(phoneNoId,phoneNoType,phoneNo,personId)values(@phoneNoId,@phoneNoType,@phoneNo,@personId)";
        //    dataAccess.add(query, phoneNo);
        //}

        //public List<PhoneNo> GetPhoneNoByPersonId(string id)
        //{
        //    List<PhoneNo> phoneNos = new List<PhoneNo>();
        //    DataAccess dataAccess = new DataAccess();
        //    string query = "select * from PhoneNos where personId=@personId";
        //    DataTable data = dataAccess.GetDetailsBypersonId(query, id);

        //    for (int i = 0; i < data.Rows.Count; i++)
        //    {
        //        PhoneNo phones = new PhoneNo();
        //        phones.phoneNoId = data.Rows[i]["phoneNoId"].ToString();
        //        phones.phoneNo = Convert.ToInt64(data.Rows[i]["phoneNo"]);
        //        phones.phoneNoType = (PhoneNoType)Enum.Parse(typeof(PhoneNoType), data.Rows[i]["phoneNoType"].ToString());
        //        phones.personId = data.Rows[i]["personId"].ToString();
        //        phoneNos.Add(phones);

        //    }
        //    return phoneNos;

        //}

        //public List<PhoneNo>GetDynamic(string id)
        //{
        //    List<PhoneNo> phoneNos = new List<PhoneNo>();
        //    DataAccess dataAccess = new DataAccess();
        //    if (string.IsNullOrEmpty(id)) 
        //    {
        //        string query = "select * from PhoneNos where isdelete=0;";
        //        DataTable data = dataAccess.Get(query);
        //        foreach (DataRow rows in data.Rows)
        //        {
        //            PhoneNo phones = new PhoneNo();
        //            phones.phoneNoId = rows["phoneNoId"].ToString();
        //            phones.phoneNo = Convert.ToInt64(rows["phoneNo"]);
        //            phones.phoneNoType = (PhoneNoType)Enum.Parse(typeof(PhoneNoType), rows["phoneNoType"].ToString());
        //            phones.personId = rows["personId"].ToString();
        //            phoneNos.Add(phones);

        //        }
        //        return phoneNos;
        //    }
        //    else
        //    {
        //        string query = "select * from PhoneNos where personId=@personId";
        //        DataTable data = dataAccess.GetDetailsBypersonId(query, id);

        //        foreach (DataRow rows in data.Rows)
        //        {
        //            PhoneNo phones = new PhoneNo();
        //            phones.phoneNoId = rows["phoneNoId"].ToString();
        //            phones.phoneNo = Convert.ToInt64(rows["phoneNo"]);
        //            phones.phoneNoType = (PhoneNoType)Enum.Parse(typeof(PhoneNoType), rows["phoneNoType"].ToString());
        //            phones.personId = rows["personId"].ToString();
        //            phoneNos.Add(phones);

        //        }
        //        return phoneNos;


        //    }
    }

}

