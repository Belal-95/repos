using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;
using System.Text;
using System.Security.Cryptography;

using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace EventReminderService.Common
{
    public class Utility
    {
        #region Encrypt & Decrypt Methods

        public static string Encrypt(string plainText, string encryptionKey)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(plainText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x62, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    plainText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return plainText;
        }


        public static string Decrypt(string encryptText, string decryptionKey)
        {
            byte[] encryptBytes = Convert.FromBase64String(encryptText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(decryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x62, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(encryptBytes, 0, encryptBytes.Length);
                        cs.Close();
                    }
                    encryptText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return encryptText;
        }

        public static void SendEmail(string subject, string to, string body, bool isBodyHtml)
        {
            MailMessage objMailMessage = new MailMessage();

            objMailMessage.From = new MailAddress(ConfigurationManager.AppSettings["From"].ToString());

            //objMailMessage.From = new MailAddress("belal.khanjar95@gmail.com");

            string[] toMails = to.Split(',');

            foreach (string toMail in toMails)
            {
                objMailMessage.To.Add(new MailAddress(toMail));
            }
            objMailMessage.Subject = subject;

            objMailMessage.Body = body;
            objMailMessage.IsBodyHtml = isBodyHtml;
            objMailMessage.Priority = MailPriority.High;

            SmtpClient objSmptpClient = new SmtpClient();

            objSmptpClient.Host = ConfigurationManager.AppSettings["Host"].ToString();

            //objSmptpClient.Host = "smtp.gmail.com";


            objSmptpClient.Port = int.Parse(ConfigurationManager.AppSettings["Port"].ToString());

            //objSmptpClient.Port = 587;


            //NetworkCredential objNetworkCredential = new NetworkCredential(ConfigurationManager.AppSettings["Form"].ToString(), ConfigurationManager.AppSettings["Password"].ToString());

            NetworkCredential objNetworkCredential = new NetworkCredential(ConfigurationManager.AppSettings["From"].ToString(), ConfigurationManager.AppSettings["Password"].ToString());

            objSmptpClient.Credentials = objNetworkCredential;
            objSmptpClient.EnableSsl = true;

            objSmptpClient.Send(objMailMessage);
        }


        // overloaded method

        public static void SendEmail(string displayName, string subject, string to, string body, bool isBodyHtml, HttpPostedFileBase[] fileAattachs)
        {
            MailMessage objMailMessage = new MailMessage();

            objMailMessage.From = new MailAddress(ConfigurationManager.AppSettings["From"].ToString(),displayName);

            string[] toMails = to.Split(',');

            foreach (string toMail in toMails)
            {
                objMailMessage.To.Add(new MailAddress(toMail));
            }
            objMailMessage.Subject = subject;

            objMailMessage.Body = body;
            objMailMessage.IsBodyHtml = isBodyHtml;
            objMailMessage.Priority = MailPriority.High;

            if(fileAattachs != null)
            {
                foreach (HttpPostedFileBase file in fileAattachs)
                {
                    if (file != null)
                    {
                        objMailMessage.Attachments.Add(new Attachment(file.InputStream, file.FileName));
                    }
                }
            }
            SmtpClient objSmptpClient = new SmtpClient();

            objSmptpClient.Host = ConfigurationManager.AppSettings["Host"].ToString();

            objSmptpClient.Port = int.Parse(ConfigurationManager.AppSettings["Port"].ToString());

            //NetworkCredential objNetworkCredential = new NetworkCredential(ConfigurationManager.AppSettings["From"].ToString(), ConfigurationManager.AppSettings["Password"].ToString());

            NetworkCredential objNetworkCredential = new NetworkCredential(ConfigurationManager.AppSettings["From"].ToString(), ConfigurationManager.AppSettings["Password"].ToString());

            objSmptpClient.Credentials = objNetworkCredential;
            objSmptpClient.EnableSsl = true;

            objSmptpClient.Send(objMailMessage);
        }

        #endregion
    }
}