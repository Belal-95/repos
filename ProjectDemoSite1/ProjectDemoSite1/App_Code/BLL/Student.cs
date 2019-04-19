using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using RSN.Project.Utility;
using RNS.Project.BLL;
using RNS.Project.DAL;

/// <summary>
/// Summary description for Student
/// </summary>

namespace RSN.Project.BLL
{
    public class Student : Standard
    {
        #region Class Private fields
        private int _studentId;
        private string _name;
        private string _address;
        private string _city;
        private string _state;
        private string _pinCode;
        #endregion

        #region Class Public Properties
        public int StudentId
        {
            get { return this._studentId; }
            set { this._studentId = value; }
        }

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public string Address
        {
            get { return this._address; }
            set { this._address = value; }
        }
        public string City
        {
            get { return this._city; }
            set { this._city = value; }
        }
        public string State
        {
            get { return this._state; }
            set { this._state = value; }
        }
        public string PinCode
        {
            get { return this._pinCode; }
            set { this._pinCode = value; }
        }
        #endregion
       
        #region Class Public Methods

        public DataSet GetStudents()
        {
            //Prepare sql Query Select statment to get all students data as a ResultSet
            //sqlCommandText = "Select s.StudentId, s.Name, s.Address, s.City, s.State, s.PinCode, st.StandardName from Student s, Standard st where s.StandardId = st.StandardId";

            sqlCommandText = "SP_GetAllStudent";

            DataSet dataSet = SqlHelper.ExecuteDataSet(sqlCommandText,CommandType.StoredProcedure);

            return dataSet;
        
        }

        public DataSet GetStudentDetails()
        {
            //sqlCommandText = "Select s.StudentId, s.Name, s.Address, s.City, s.State, s.PinCode, s.StandardId, st.StandardName from Student s
            //, Standard st where s.StandardId = st.StandardId and s.StudentId=" +_studentId;

            //sqlCommandText = "Select s.StudentId, s.Name, s.Address, s.City, s.State, s.PinCode, s.StandardId, st.StandardName from Student s" +
            //    ", Standard st where s.StandardId = st.StandardId and s.StudentId=@StudentId";

            sqlCommandText = "SP_GetStuentDetailsByStudentId";

            SqlParameter parameter = new SqlParameter("@StudentId", this._studentId);

            DataSet dataSet = SqlHelper.ExecuteDataSet(sqlCommandText,parameter,CommandType.StoredProcedure);

            return dataSet;

        }

        public DataSet GetStudentDetails(int studentId)
        {
            //sqlCommandText = "Select s.StudentId, s.Name, s.Address, s.City, s.State, s.PinCode, s.StandardId, st.StandardName from Student s" +
            //    ", Standard st where s.StandardId = st.StandardId and s.StudentId=" + studentId;

            //sqlCommandText = "Select s.StudentId, s.Name, s.Address, s.City, s.State, s.PinCode, s.StandardId, st.StandardName from Student s" +
            //    ", Standard st where s.StandardId = st.StandardId and s.StudentId=@StudentId";

            sqlCommandText = "SP_GetStuentDetailsByStudentId";

            SqlParameter parameter = new SqlParameter("@StudentId",studentId);

            DataSet dataSet = SqlHelper.ExecuteDataSet(sqlCommandText,parameter, CommandType.StoredProcedure);

            return dataSet;

        }

        public int InsertStudentDetails()
        {
            //sqlCommandText = "Insert into Student (Name, Address, City, State," +
            //    " pinCode, StandardId) Values('" + _name + " ', '" + _address + "', '" + _city + "', '" + _state + "', '" + _pinCode + "', "
            //    + _standardId + ")";

            //sqlCommandText = "Insert into Student (Name, Address, City, State," +
            //    " pinCode, StandardId) Values(@Name , @Address , @City , @State , @PinCode , @StandardId)";

            sqlCommandText = "SP_InseretStudentDetails";

            SqlParameter[] parameters = new SqlParameter[6]
            {
                new SqlParameter("@Name",this._name),
                new SqlParameter("@Address",this._address),
                new SqlParameter("@City",this._city),
                new SqlParameter("@State",this._state),
                new SqlParameter("@PinCode",this._pinCode),
                new SqlParameter("@StandardId",this._standardId),
            };

            return SqlHelper.ExecuteNonQuery(sqlCommandText, CommandType.StoredProcedure, parameters);
        }

        public int InsertStudentDetails(String name, string address, string city,string state, string pinCode, int standardId)
        {
            //sqlCommandText = "Insert into Student (Name, Address, City, State," +
            //    " pinCode, StandardId) Values('" + name + " ', '" + address + "', '" + city + "', '" + state + "', '" + PinCode + "', "
            //    + standardId + ")";

            //sqlCommandText = "Insert into Student (Name, Address, City, State," +
            //" pinCode, StandardId) Values(@Name , @Address , @City , @State , @PinCode , @StandardId)";

            sqlCommandText = "SP_InseretStudentDetails";


            SqlParameter[] parameters = new SqlParameter[6]
            {
                new SqlParameter("@Name",name),
                new SqlParameter("@Address",address),
                new SqlParameter("@City",city),
                new SqlParameter("@State",state),
                new SqlParameter("@PinCode",pinCode),
                new SqlParameter("@StandardId",standardId),
            };

            return SqlHelper.ExecuteNonQuery(sqlCommandText, CommandType.StoredProcedure,parameters);
        }

        public int DeleteStudentDetails()
        {
            //sqlCommandText = "Delete from Student Where StudentId=" + _studentId;

            //sqlCommandText = "Delete from Student Where StudentId=@StudentId";

            sqlCommandText = "SP_DeleteStudentDetailsByStudentId";

            SqlParameter parameter = new SqlParameter("@StudentId", this._studentId);

            return SqlHelper.ExecuteNonQuery(sqlCommandText,CommandType.StoredProcedure, parameter);
        }

        public int DeleteStudentDetails(int studentId)
        {
            //sqlCommandText = "Delete from Student Where StudentId=" + studentId;

            //sqlCommandText = "Delete from Student Where StudentId=@StudentId";

            sqlCommandText = "SP_DeleteStudentDetailsByStudentId";


            //this line is added because we change the query and used parameter

            SqlParameter parameter = new SqlParameter("@StudentId", studentId);

            return SqlHelper.ExecuteNonQuery(sqlCommandText,CommandType.StoredProcedure, parameter);
        }

        public int UpdateStuedentDetails()
        {

            //sqlCommandText = "Update Student Set Name='" + _name + "', Address='" + _address + "', City='" + _city + "', State='" + _state +
            //    "', PinCode='" + _pinCode + "', StandardId=" + _standardId + " Where StudentId=" + _studentId;

            //sqlCommandText = "Update Student Set Name=@Name, Address=@Address, City=@City, State=@State," +
            //    " PinCode=@PinCode, StandardId=@StandardId Where StudentId=@StudentId";

            sqlCommandText = "SP_UpdateStudentDetialsByStudentId";


            SqlParameter[] parameters = new SqlParameter[7]
           {
                new SqlParameter("@StudentId",this._studentId),
                new SqlParameter("@Name",this._name),
                new SqlParameter("@Address",this._address),
                new SqlParameter("@City",this._city),
                new SqlParameter("@State",this._state),
                new SqlParameter("@PinCode",this._pinCode),
                new SqlParameter("@StandardId",this._standardId)
           };

            return SqlHelper.ExecuteNonQuery(sqlCommandText,CommandType.StoredProcedure, parameters);
        }

        public int UpdateStuedentDetails(String name, string address, string city, string state, string pinCode, int standardId, int studentId)
        {
            //sqlCommandText = "Update Student Set Name='" + name + "', Address='" + address + "', City='" + city + "', State='" + state +
            //    "', PinCode='" + pinCode + "', StandardId=" +   standardId + " Where StudentId=" + studentId;

            //        sqlCommandText = "Update Student Set Name=@Name, Address=@Address, City=@City, State=@State," +
            //" PinCode=@PinCode, StandardId=@StandardId Where StudentId=@StudentId";

            sqlCommandText = "SP_UpdateStudentDetialsByStudentId";

            SqlParameter[] parameters = new SqlParameter[7]
          {
                new SqlParameter("@StudentId",studentId),
                new SqlParameter("@Name",name),
                new SqlParameter("@Address",address),
                new SqlParameter("@City",city),
                new SqlParameter("@State",state),
                new SqlParameter("@PinCode",pinCode),
                new SqlParameter("@StandardId",standardId),
          };

            return SqlHelper.ExecuteNonQuery(sqlCommandText,CommandType.StoredProcedure, parameters);
        }

        #endregion
    }
}