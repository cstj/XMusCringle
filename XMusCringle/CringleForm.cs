using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;
using System.Data.Objects;

namespace XMusCringle
{
    public partial class CringleForm : Form
    {
        public CringleForm()
        {
            InitializeComponent();
            /*
            this.db = dbContext;
            this.listDraw.Enabled = false;
            this.db.CringleDetails.Load();
            this.db.XmusCringle.Load();
            listYears.DisplayMember = "YearOnly";
            RefreshYears();*/
        }

        private void RefreshDraw()
        {
            /*
            listDraw.Items.Clear();
            //Get Draw of the selected year
            var draws = from d in db.XmusCringle
                                       where d.Year == ((CringleDetail)listYears.SelectedItem).Year
                                       select d;
            foreach (CringleDraw c in draws)
            {
                this.listDraw.Items.Add(c);
            }
            this.listDraw.DisplayMember = "PersonName";
            */
        }



        
        //Create personalised list of people to choose from
        private List<XMusCringleLib.Model.Person> SelectionList(XMusCringleLib.Model.Person person, List<XMusCringleLib.Model.Person> fullList, Boolean removePartner)
        {
            /*
            //Create copty of full List removing self and partner
            List<XMusCringle.CringleDBClass.Person> selPeople = new List<Person>();
            foreach (Person p in fullList)
            {
                if (p.PersonID != person.PersonID && (p.PersonID != person.PartnerID && removePartner))
                    selPeople.Add(p);
            }
            return selPeople;*/
            return null;
        }

        private void listDraw_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void SaveChang()
        {
            /*
            //Update Cover Letter
            try
            {
                ((CringleDetail)this.listYears.SelectedItem).Amount = Decimal.Parse(this.textAmount.Text);
            }
            catch (Exception) { ((CringleDetail)this.listYears.SelectedItem).Amount = 0; }
            ((CringleDetail)this.listYears.SelectedItem).CoverLetter = this.textCover.Text;
            ((CringleDetail)this.listYears.SelectedItem).CringleName = this.textCringleName.Text;
            //Save the changes
            this.db.SaveChanges();
            this.db.CringleDetails.Load();
            this.db.XmusCringle.Load();
            */
        }

        private void butEmailOne_Click(object sender, EventArgs e)
        {
            /*
            if (listDraw.SelectedItem != null)
                DoEmails(true);
            else
                MessageBox.Show("Please select a draw item first");*/
        }

        private void butEmailAll_Click(object sender, EventArgs e)
        {
            //DoEmails(false);
        }

        private void DoEmails(Boolean selectedOnly)
        {
            /*
            //Save Any Changes
            this.SaveChang();
            //Test Name & Cover letter is not nothing.
            if (textCover.Text.Trim() == "" || textCringleName.Text.Trim() == "")
            {
                MessageBox.Show("Need NonEmpty Entries for Cover Letter and Cringle Name");
            }
            //Otherwise on with the show!
            else
            {
                if (selectedOnly)
                {
                    EmailPerson((CringleDraw)this.listDraw.SelectedItem, textCover.Text);
                }
                else
                {
                    foreach (CringleDraw draw in this.listDraw.Items)
                    {
                        EmailPerson(draw, textCover.Text);
                    }
                }
            }*/
        }

        private void EmailPerson(XMusCringleLib.Model.CringleDraw draw, String coverLetter)
        {
            /*
            //Construct Cover Letter
            String Contents = coverLetter;
            Contents = Regex.Replace(coverLetter, @"(?i)%name%", draw.Person.Name);
            Contents = Regex.Replace(Contents, @"(?i)%draw%", draw.Draw.Name);
            Contents = Regex.Replace(Contents, @"(?i)%amount%", "$" + draw.CringleInfo.Amount.ToString());
            Contents = Regex.Replace(Contents, @"(?i)%year%", draw.CringleInfo.YearOnly.ToString());

            //Header
            string Subject = draw.CringleInfo.CringleName;
            Subject = Regex.Replace(Subject, @"(?i)%name%", draw.Person.Name);
            Subject = Regex.Replace(Subject, @"(?i)%draw%", draw.Draw.Name);
            Subject = Regex.Replace(Subject, @"(?i)%amount%", "$" + draw.CringleInfo.Amount.ToString());
            Subject = Regex.Replace(Subject, @"(?i)%year%", draw.CringleInfo.YearOnly.ToString());
            
            //Send Email
            MailAddress fromAddress = new MailAddress("cstjohn83@gmail.com");
            MailAddress toAddress = new MailAddress(draw.Person.Email);
            // zqdyxjmlppasamdl 
            String fromPassword = " zqdyxjmlppasamdl";
            SmtpClient smtp = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (MailMessage msg = new MailMessage(fromAddress, toAddress))
            {
                msg.Subject = Subject;
                msg.Body = Contents;
                Boolean fail = true;
                Int32 counter = 0;
                while (fail && counter < 5)
                {
                    try
                    {
                        smtp.Send(msg);
                        fail = false;
                    }
                    catch (SmtpException s) { fail = true; }
                }
            }*/
            
        }

        private void textAmount_Leave(object sender, EventArgs e)
        {
            /*
            Int64 longAmount;
            if (!Int64.TryParse(textAmount.Text, out longAmount))
                longAmount = 0;
            this.textAmount.Text = longAmount.ToString();
            SaveChang();*/
        }

        private void textCover_Leave(object sender, EventArgs e)
        {
            //SaveChang();
        }

        private void textCringleName_Leave(object sender, EventArgs e)
        {
            //SaveChang();
        }

        private void CringleForm_Load(object sender, EventArgs e)
        {

        }
    }
}
