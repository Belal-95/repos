using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using RSN.ER.BLL;
using System.Data;

namespace EventReminderSchedular
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Schedular objScheduler = new Schedular();

            //Get All Registered Users
            DataTable dtUsers = objScheduler.GetAllRegisteredUsers();

            DataRowCollection drcUsers = dtUsers.Rows;

            foreach (DataRow drUser in drcUsers)
            {
                int userId = int.Parse(drUser["UserId"].ToString());

                string strUserEmailId = drUser["EmailId"].ToString();

                //Get All Birthday Event Details
                DataTable dtBirthdayDetails = objScheduler.GetBirthdayDetailsByUserId(userId);

                DataRowCollection drcBirthdayDetails = dtBirthdayDetails.Rows;

                string strBdayEventDetails = string.Empty;

                foreach (DataRow drBirthdayDetail in drcBirthdayDetails)
                {
                    int birthdayDetailsId = int.Parse(drBirthdayDetail["BirthdayDetailsId"].ToString());

                    string strDateOfBirth = drBirthdayDetail["DateOfBirth"].ToString();

                    //Get Birthday Event Reminder
                    DataTable dtBirthdatReminder = objScheduler.GetBirthdayReminder(userId, birthdayDetailsId);

                    if(dtBirthdatReminder.Rows.Count >0)
                    {
                        DataRow drBirthdayReminder = dtBirthdatReminder.Rows[0];

                        bool DaysBefore30 = (bool)drBirthdayReminder["30DaysBefore"];

                        bool DaysBefore14 = (bool)drBirthdayReminder["14DaysBefore"];

                        bool DaysBefore7= (bool)drBirthdayReminder["7DaysBefore"];

                        bool DaysBefore3 = (bool)drBirthdayReminder["3DaysBefore"];

                        bool DayofEvent = (bool)drBirthdayReminder["DayofEvent"];

                        //Get The Current Date
                        DateTime dtCurrentDate = DateTime.Now;

                        DateTime dtDateOfBirth = DateTime.Parse(strDateOfBirth);

                        string strBirthdayName = drBirthdayDetail["FirstName"].ToString();

                        if (DaysBefore30 == true)
                        {
                            DateTime dtNew = dtDateOfBirth.AddDays(-30);
                            if((dtNew.Day == dtCurrentDate.Day) && (dtNew.Month == dtCurrentDate.Month))
                            {
                                strBdayEventDetails += "<tr style='background-color:#D2FFFF;'><td width='50%'>" + strBirthdayName + "</td><td width='50%'>" + dtDateOfBirth.ToString("dd-MMM-yyyy") + "</td></tr>";
                            }
                        }

                        if (DaysBefore14 == true)
                        {
                            DateTime dtNew = dtDateOfBirth.AddDays(-14);
                            if ((dtNew.Day == dtCurrentDate.Day) && (dtNew.Month == dtCurrentDate.Month))
                            {
                                strBdayEventDetails += "<tr style='background-color:#D2FFFF;'><td width='50%'>" + strBirthdayName + "</td><td width='50%'>" + dtDateOfBirth.ToString("dd-MMM-yyyy") + "</td></tr>";
                            }
                        }

                        if (DaysBefore7 == true)
                        {
                            DateTime dtNew = dtDateOfBirth.AddDays(-7);
                            if ((dtNew.Day == dtCurrentDate.Day) && (dtNew.Month == dtCurrentDate.Month))
                            {
                                strBdayEventDetails += "<tr style='background-color:#D2FFFF;'><td width='50%'>" + strBirthdayName + "</td><td width='50%'>" + dtDateOfBirth.ToString("dd-MMM-yyyy") + "</td></tr>";
                            }
                        }

                        if (DaysBefore3 == true)
                        {
                            DateTime dtNew = dtDateOfBirth.AddDays(-3);
                            if ((dtNew.Day == dtCurrentDate.Day) && (dtNew.Month == dtCurrentDate.Month))
                            {
                                strBdayEventDetails += "<tr style='background-color:#D2FFFF;'><td width='50%'>" + strBirthdayName + "</td><td width='50%'>" + dtDateOfBirth.ToString("dd-MMM-yyyy") + "</td></tr>";
                            }
                        }

                        if (DayofEvent == true)
                        {
                            if((dtDateOfBirth.Day == dtCurrentDate.Day) && 
                                (dtDateOfBirth.Month == dtCurrentDate.Month))
                            {
                                strBdayEventDetails += "<tr style='background-color:#D2FFFF;'><td width='50%'>" + strBirthdayName + "</td><td width='50%'>" + dtDateOfBirth.ToString("dd-MMM-yyyy") + "</td></tr>";
                            }
                          
                        }

                    }
                }
                if (strBdayEventDetails != String.Empty)
                {
                    objScheduler.SendMail(strUserEmailId, strBdayEventDetails);
                }
            }
        }
    }
}
