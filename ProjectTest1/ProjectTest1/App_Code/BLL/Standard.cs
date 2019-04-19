using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using RSN.Project.Utility;
using RSN.Project.DAL;

/// <summary>
/// Summary description for Standard
/// </summary>
/// 

namespace RSN.Project.BLL
{
    public class Standard : Common
    {
        #region Class Protected Fields
        protected int _standardId;
        protected string _standardName;
        #endregion

        #region  Class Public Properties

        public int StandardId {
            set {this._standardId = value; }
            get { return this._standardId; }
        }

        public string StandardName
        {
            set { this._standardName = value; }
            get { return this._standardName; }
        }

        #endregion

        #region Class Public Methods

        public DataSet GetStandards()
        {
            SqlCommandText = "SP_GetAllStandards";
            DataSet dataSet = SqlHelper.exe
            
        }
        #endregion

    }
}