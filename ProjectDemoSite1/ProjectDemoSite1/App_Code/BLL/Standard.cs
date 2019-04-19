using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RSN.Project.Utility;
using RNS.Project.DAL;
using System.Data;

/// <summary>
/// Summary description for Standard
/// </summary>

namespace RNS.Project.BLL
{
    public class Standard : Common
    {
        #region Class Protected Fields
        protected int _standardId;
        protected string _standardName;
        #endregion


        #region Class Public Properties
        public int StandardId
        {
            get { return this._standardId; }
            set { this._standardId = value; }
        }

        public string StandardNamea
        {
            get { return this._standardName; }
            set { this._standardName = value; }
        }
        #endregion

        #region Class Public Methods
        public DataSet GetStandards()
        {
            // Prepare Sql Query Select Statement to Get All Standards Data as a ResultSet
            //sqlCommandText = "Select * from Standard";

            sqlCommandText = "SP_GetAllStandards";

            DataSet dataSet = SqlHelper.ExecuteDataSet(sqlCommandText, CommandType.StoredProcedure);

            return dataSet;
        }
        #endregion
        
    }
}