using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace XMusCringleLib.Model
{
    [Table("Settings")]
    public class Settings
    {
        [Key]
        public Int64 ID { get; set; }
        public string EmailFromAddress { get; set; }
        [NotMapped] //Store Password with Some Encryption
        public string Password
        {
            get
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                des.Key = this.PasswordKey;
                ICryptoTransform decryptor = des.CreateDecryptor();
                // decrypt
                byte[] originalAgain = decryptor.TransformFinalBlock(this.PasswordText, 0, this.PasswordText.Length);
                return originalAgain.ToString();
            }

            set
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                des.GenerateKey();
                byte[] key = des.Key; // save this!
                this.PasswordKey = key;

                ICryptoTransform encryptor = des.CreateEncryptor();
                // encrypt
                byte[] text = Encoding.UTF8.GetBytes(value);
                byte[] enc = encryptor.TransformFinalBlock(text, 0, text.Length);
                this.PasswordText = enc;
            }
        }
        private byte[] PasswordKey { get; set; }
        private byte[] PasswordText { get; set; }
        public string EmailHost { get; set; }
        public string EmailPort { get; set; }
        public bool EmailSSL { get; set; }
    }/*
      * 

                //Send Email
            MailAddress fromAddress = new MailAddress("cstjohn83@gmail.com");
            MailAddress toAddress = new MailAddress(draw.Draw.Email);
            // zqdyxjmlppasamdl 
            String fromPassword = " zqdyxjmlppasamdl";
            SmtpClient smtp = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)*/
}
