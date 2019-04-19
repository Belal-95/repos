using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RSN.ER.DBConnection;

using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

using System.Configuration;
using System.Net.Mail;

namespace RSN.ER.BLL
{
    class Schedular
    {
        #region Database Object Fields
        string sqlCommandText = String.Empty;
        DbCommand dbCommand = null;
        Database defaultDb = null;
        #endregion


        public DataTable GetAllRegisteredUsers()
        {
            sqlCommandText = "SP_GetAllRegisteredUsers";

            defaultDb = Connection.GEtDefaultDbConnection();

            dbCommand = defaultDb.GetStoredProcCommand(sqlCommandText);

            return defaultDb.ExecuteDataSet(dbCommand).Tables[0];
        }

        public DataTable GetBirthdayDetailsByUserId(int userId)
        {
            sqlCommandText = "SP_GetBirthdayDetailsByUserId";

            defaultDb = Connection.GEtDefaultDbConnection();

            dbCommand = defaultDb.GetStoredProcCommand(sqlCommandText);

            defaultDb.AddInParameter(dbCommand, "UserId", DbType.Int32, userId);

            return defaultDb.ExecuteDataSet(dbCommand).Tables[0];

        }

        public DataTable GetBirthdayReminder(int userId, int birthdayDetailsId)
        {
            sqlCommandText = "SP_GetBirthdayReminder";

            defaultDb = Connection.GEtDefaultDbConnection();

            dbCommand = defaultDb.GetStoredProcCommand(sqlCommandText);

            defaultDb.AddInParameter(dbCommand, "UserId", DbType.Int32, userId);
            defaultDb.AddInParameter(dbCommand, "BirthdayDetailsId", DbType.Int32, birthdayDetailsId);

            return defaultDb.ExecuteDataSet(dbCommand).Tables[0];
        }

        //Mail Business Function

        public void SendMail(string To, string bdayEventDetails)
        {
            MailMessage objMailMessage = new MailMessage();
            objMailMessage.To.Add(new MailAddress(To));
            objMailMessage.From = new MailAddress(ConfigurationManager.AppSettings["WebMasterMail"].ToString(), "Web Master Admin");

            objMailMessage.Subject = "::Event-Reminders::";

            string strMailBody = string.Empty;

            strMailBody += "<table width='700' border='0' cellpadding='0' cellspacing='0' style='background-color: #029D03; border: medium soild blue'>";
            strMailBody += "<tr>"
                + "<td width='5%'>" + "<img src='http://www.arraspeople.co.uk/assets/ckeditor/ckfinder/userfiles/images/Sectors/EventsProjectManagement.jpg' width='5%' height='100' alt='Logo' />"
                + "</td>"
                + "<td>"
                + "<span style='color: Yellow;font-family:Tahoma;font-size:25px;font-weight: bold;'>Event</span><span style='color: White;font-family:Tahoma;font-size:25px;font-weight: bold;'>-Reminders.com</span>"
                + "</td>"
                + "</tr>"
                + "<tr style='background-color: #D2FFFF;'>"
                + "<td colspan='2'>"
                + "<b>Dear Member,</b>"
                + "<br /><br />"
                + "<span>These are following People who has birthday on following Dates:</span>"
                + "<br /><br /><br />"
                + "</td></tr>"
                + bdayEventDetails
                + "<tr><td colspan='2'>"
                + "<br /><br />"
                + "<span style='font-weight:bold;'>Thanks & Best Regards,</span>"
                + "<br />"
                + "<span>Management - Team</span>"
                + "<br />"
                + "<span>Event - Reminders</span>"
                + "</td></tr>"
                + "</table>";

            objMailMessage.Body = strMailBody;

            objMailMessage.IsBodyHtml = true;
            objMailMessage.Priority = MailPriority.High;

            SmtpClient objSmtpClient = new SmtpClient();

            System.Net.NetworkCredential objNetworkCredential = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["WebMasterMail"].ToString(), ConfigurationManager.AppSettings["Pwd"].ToString());

            objSmtpClient.Credentials = objNetworkCredential;

            objSmtpClient.EnableSsl = true;

            objSmtpClient.Host = ConfigurationManager.AppSettings["Host"].ToString();
            objSmtpClient.Port = int.Parse(ConfigurationManager.AppSettings["Port"].ToString());

            objSmtpClient.Send(objMailMessage);
        }
    }

}
