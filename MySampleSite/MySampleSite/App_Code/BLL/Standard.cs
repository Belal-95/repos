using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using FAR.Project.Utility;
using FAR.Project.DAL;

/// <summary>
/// Summary description for Standard
/// </summary>

namespace FAR.Project.BLL
{
   public class Standard : Common
    {
        #region Class Protected FieldsB
        protected int _grad;
        protected string _teacherName;
        #endregion

        #region Class public Properties
        public string TeacherName
        {
            get{ return this._teacherName; }
            set{ this._teacherName = value; }
        }

        public int Grad
        {
            get { return this._grad; }
            set { this._grad = value; }
        }

        #endregion Class public methods
        public DataSet GetStandards()
        {
            // we can also do the same using a query not a stored procedure

            sqlCommandText = "SP_GetAllStandard";

            DataSet dataSet = SqlHelper.ExecuteDataSet(sqlCommandText, CommandType.StoredProcedure);

            return dataSet;
        }
    }
}