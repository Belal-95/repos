using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using FAR.Project.DAL;
//using FAR.Project.BLL;

/// <summary>
/// Summary description for Student
/// </summary>

namespace FAR.Project.BLL
{
    public class Student :Standard
    {
        #region Class Protected Fields
        private int _studentId;
        private string _name;
        private string _address;
        private string _phoneNumber;
        private string _familyNumber;
        //private int _grad;
        #endregion

        #region Class Public Properties
        public int StudentId
        {
            set { this._studentId = value; }
            get { return this._studentId; }
        }
        public string Name
        {
            set { this._name = value; }
            get { return this._name; }
        }
        public string Address
        {
            set { this._address = value; }
            get { return this._address; }
        }
        public string PhoneNumber
        {
            set { this._phoneNumber = value; }
            get { return this._phoneNumber; }
        }
        public string FamilyNumber
        {
            set { this._familyNumber = value; }
            get { return this._familyNumber; }
        }
        //public int Grad
        //{
        //    set { this._grad = value; }
        //    get { return this._grad; }
        //}

        #endregion

        #region Class Public Methods
        public DataSet GetAllStudents()
        {
            sqlCommandText = "SP_GetAllStudents";
            DataSet dataSet = SqlHelper.ExecuteDataSet(sqlCommandText, CommandType.StoredProcedure);

            return dataSet;
        }

        public DataSet GetStudentDetails()
        {
            sqlCommandText = "SP_GetStuentDetailsByStudentId";
            SqlParameter Parameter = new SqlParameter("@StudentId", this._studentId);
            DataSet dataSet = SqlHelper.ExecuteDataSet(sqlCommandText, Parameter, CommandType.StoredProcedure);

            return dataSet;
        }

        public DataSet GetStudentDetails(int studentId)
        {
            sqlCommandText = "SP_GetStuentDetailsByStudentId";

            SqlParameter parameter = new SqlParameter("@StudentId", studentId);
            DataSet dataSet = SqlHelper.ExecuteDataSet(sqlCommandText, parameter, CommandType.StoredProcedure);

            return dataSet;
        }

        public int InsertStudentDetails(string name, string address, string phoneNumber, string familyNumber, int grad)
        {
            sqlCommandText = "SP_InseretStudentDetails";

            SqlParameter[] parameters = new SqlParameter[5]
            {
                new SqlParameter ("@Name",name),
                new SqlParameter ("@Address", address),
                new SqlParameter ("@PhoneNumber",phoneNumber),
                new SqlParameter ("@FamilyNumber", familyNumber),
                new SqlParameter ("@Grad",grad),
            };

           return SqlHelper.ExecuteNonQuery(sqlCommandText, parameters, CommandType.StoredProcedure);
        }

        public int InsertStudentDetails()
        {
            sqlCommandText = "SP_InseretStudentDetails";

            SqlParameter[] parameters = new SqlParameter[5]
            {
                new SqlParameter ("@Name",this._name),
                new SqlParameter ("@Address", this._address),
                new SqlParameter ("@PhoneNumber",this._phoneNumber),
                new SqlParameter ("@FamilyNumber", this._familyNumber),
                new SqlParameter ("@Grad",this._grad),
            };

            return SqlHelper.ExecuteNonQuery(sqlCommandText, parameters, CommandType.StoredProcedure);
        }

      

        public int UpdateStudentDetails(int studentId, string name, string address, string phoneNumber, string familyNumber, int grad)
        {
            sqlCommandText = "SP_UpdateStudentDetialsByStudentId";

            SqlParameter[] parameters = new SqlParameter[6]{
                new SqlParameter("@StudentId", studentId),
                new SqlParameter ("@Name",name),
                new SqlParameter ("@Address", address),
                new SqlParameter ("@PhoneNumber",phoneNumber),
                new SqlParameter ("@FamilyNumber",familyNumber),
                new SqlParameter ("@Grad",grad),
        };
            
            

            return SqlHelper.ExecuteNonQuery(sqlCommandText, parameters,CommandType.StoredProcedure);
        }

        public int UpdateStudentDetails()
        {
            sqlCommandText = "SP_UpdateStudentDetialsByStudentId";

            SqlParameter[] parameters = new SqlParameter[6]{
                new SqlParameter("@StudentId", this._studentId),
                new SqlParameter ("@Name",this._name),
                new SqlParameter ("@Address", this._address),
                new SqlParameter ("@PhoneNumber",this._phoneNumber),
                new SqlParameter ("@FamilyNumber", this._familyNumber),
                new SqlParameter ("@Grad",this._grad),
        };



            return SqlHelper.ExecuteNonQuery(sqlCommandText, parameters, CommandType.StoredProcedure);
        }

        public int DeleteStudent(int studentId)
        {
            sqlCommandText = "SP_DeleteStudentDetailsByStudentId";

            SqlParameter parameter = new SqlParameter("@StudentId", studentId);

            return SqlHelper.ExecuteNonQuery(sqlCommandText, parameter, CommandType.StoredProcedure);
        }

        public int DeleteStudent()
        {
            sqlCommandText = "SP_DeleteStudentDetailsByStudentId";

            SqlParameter parameter = new SqlParameter("@StudentId", this._studentId);

            return SqlHelper.ExecuteNonQuery(sqlCommandText, parameter, CommandType.StoredProcedure);
        }
        #endregion




    }
}