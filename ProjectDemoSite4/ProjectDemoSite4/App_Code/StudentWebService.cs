using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using RNS.BLL;
using RSN.BLL;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for StudentWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 

    //uncomment this line so we can use it and call it from ajax
[System.Web.Script.Services.ScriptService]
public class StudentWebService : System.Web.Services.WebService
{
    Student student = new Student();
    public StudentWebService()
    {
        student.Connection = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;


        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public List<Student> GetStudents()
    {
        DataSet dataSet = student.GetStudents();

        List<Student> students = new List<Student>();

        foreach(DataRow dataRow in dataSet.Tables[0].Rows)
        {
            students.Add(new Student()
            {
                StudentId = int.Parse(dataRow["StudentId"].ToString()),
                Name = dataRow["Name"].ToString(),
                Address = dataRow["Address"].ToString(),
                City = dataRow["City"].ToString(),
                State = dataRow["State"].ToString(),
                PinCode = dataRow["PinCode"].ToString(),
                StandardId= int.Parse(dataRow["StandardId"].ToString()),
                StandardNamea = dataRow["StandardName"].ToString(),
            });
        }
        return students;
    }

    [WebMethod]
    public List<Standard> GetStandards()
    {
        DataSet dataSet = student.GetStandards();

        List<Standard> standards = new List<Standard>();

        foreach (DataRow dataRow in dataSet.Tables[0].Rows)
        {
            standards.Add(new Standard()
            {
                StandardId = int.Parse(dataRow["StandardId"].ToString()),
                StandardNamea = dataRow["StandardName"].ToString(),
            });
        }
        return standards;
    }

    [WebMethod]
    public int InsertStudentDetails(string name, string address, string city, string state, string pinCode, int standardId)
    {
        return student.InsertStudentDetails(name, address, city, state, pinCode, standardId);
    }

    [WebMethod]
    public Student GetStudentDetails(int studentId)
    {
        DataSet dataSet = student.GetStudentDetails(studentId);

        Student studentDetails = null;

        if(dataSet.Tables[0].Rows.Count>0)
        {
            DataRow dataRow = dataSet.Tables[0].Rows[0];

            studentDetails = new Student()
            {
                StudentId = int.Parse(dataRow["StudentId"].ToString()),
                Name = dataRow["Name"].ToString(),
                Address = dataRow["Address"].ToString(),
                City = dataRow["City"].ToString(),
                State = dataRow["State"].ToString(),
                PinCode = dataRow["PinCode"].ToString(),
                StandardId = int.Parse(dataRow["StandardId"].ToString()),
                StandardNamea = dataRow["StandardName"].ToString(),
            };
        }
        return studentDetails;
    }

    [WebMethod]
    public int UpdateStudentDetails(string name, string address, string city, string state, string pinCode, int standardId, int studentId)
    {
        return student.UpdateStuedentDetails(name, address, city, state, pinCode, standardId, studentId);
    }

    [WebMethod]
    public int DeleteStudentDetails(int studentId)
    {
        return student.DeleteStudentDetails(studentId);
    }
}
