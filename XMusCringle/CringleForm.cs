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

        private void RefreshYears()
        {
            /*
            var result = from y in db.CringleDetails
                         orderby y.Year
                         select y;
            //test for items in box in list
            List<CringleDetail> remList = new List<CringleDetail>();
            List<CringleDetail> inBox = new List<CringleDetail>();
            foreach (CringleDetail d in listYears.Items)
            {
                if (!result.Any(u => u.Year == d.Year)) remList.Add(d);
                else inBox.Add(d);
            }
            remList.ForEach(r => listYears.Items.Remove(r));
            
            //test items in list against box
            foreach (CringleDetail d in result)
            {
                if (!inBox.Any(u => u.Year == d.Year)) listYears.Items.Add(d);
            }*/
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            /*
            if (this.listYears.SelectedItem != null)
            {
                //delete all related cringle info
                ((CringleDetail)this.listYears.SelectedItem).CringleDraws.ToList<CringleDraw>().ForEach(p => db.XmusCringle.Remove(p));
                db.CringleDetails.Remove((CringleDetail)this.listYears.SelectedItem);
                db.SaveChanges();
                RefreshYears();
            }*/
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            /*
            //Get New year for new cringle
            SelectYear formYear = new SelectYear();
            DialogResult result = formYear.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                DateTime year = formYear.Year;
                //Test to see if it exists already
                var cd = (from d in db.CringleDetails
                          where d.Year == year
                          orderby d.Year
                          select d).ToList();
                if (cd.Count == 0)
                {
                    CringleDetail cdet = new CringleDetail { Year = year };
                    this.db.CringleDetails.Add(cdet);
                }
                this.db.SaveChanges();
                this.db.CringleDetails.Load();
                RefreshYears();
                foreach (var i in listYears.Items)
                {
                    if (((CringleDetail)i).Year == year)
                    {
                        listYears.SelectedItem = i;
                        break;
                    }
                    
                }
            }
            formYear.Close();*/
        }

        private void listYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            //Test if its been run already
            DateTime? year = null;
            List<CringleDraw> c;
            try
            {
                CringleDetail item = (CringleDetail)listYears.SelectedItem;
                year = item.Year;
                c = (from d in db.XmusCringle
                        where d.Year == year
                        orderby d.Person.Name
                        select d).ToList();
            }
            catch (Exception ex)
            {
                c = new List<CringleDraw>();
            }
            //Do we have a year and no cringle data, if so run said cringle
            if (c.Count == 0 && year != null)
            {
                List<XMusCringle.CringleDBClass.Person> people;
                //Not Run! Get List of ppl
                SelectPeople d = new SelectPeople(this.db);
                d.ShowDialog(this);
                people = d.People;
                d.Close();
                //Run the draw on the peopl
                RunDraw(people, (DateTime)year);
                SelectYearData();
            }
            //If we have cringle data and a year show it!
            else if (year != null)
            {
                SelectYearData();
            }
            else
            {
                listDraw.Items.Clear();
            }*/
        }

        private void SelectYearData()
        {
            /*
            //Load Approiate Info
            try
            {
                textAmount.Text = ((CringleDetail)listYears.SelectedItem).Amount.ToString();
            }
            catch (Exception)
            {
                textAmount.Text = null;
            }
            try
            {
                textCover.Text = ((CringleDetail)listYears.SelectedItem).CoverLetter;
            }
            catch (Exception)
            {
                textCover.Text = null;
            }
            try
            {
                textCringleName.Text = ((CringleDetail)listYears.SelectedItem).CringleName;
            }
            catch (Exception)
            {
                textCringleName.Text = null;
            }
            RefreshDraw();
            this.listDraw.Enabled = true;*/
        }

        private void RunDraw(List<XMusCringleLib.Model.Person> people, DateTime Year)
        {
            /*
            //Got a list of 'people' have ot pair them up with random people
            //Create Copy of list
            List<XMusCringle.CringleDBClass.Person> selFullPeople = new List<Person>();
            foreach (Person p in people)
            {
                selFullPeople.Add(p);
            }
            //Save First
            db.SaveChanges();
            //Init random!
            Random rand = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            //Do untill we have a good success or counter exceeds
            Boolean success = false;
            Int64 counter = 0;
            while (success == false && counter <= 10000)
            {
                //Throw away any changes
                foreach (var a in db.ChangeTracker.Entries())
                {
                    switch (a.State)
                    {
                        case System.Data.Entity.EntityState.Deleted:
                        case System.Data.Entity.EntityState.Modified:
                            a.Reload();
                            break;
                        case System.Data.Entity.EntityState.Added:
                            a.State = System.Data.Entity.EntityState.Detached;
                            break;
                    }
                }
                //Assume i will succeed
                counter++;
                success = true;
                foreach (Person p in people)
                {
                    //Create Selection List
                    List<XMusCringle.CringleDBClass.Person> selPeople = SelectionList(p, selFullPeople, true);
                    //Check we have a valid list
                    if (selPeople.Count > 0)
                    {
                        //Make selection
                        Int32 intPerson = rand.Next(0, selPeople.Count());
                        XMusCringle.CringleDBClass.CringleDraw draw = new CringleDraw()
                        {
                            DrawnID = selPeople[intPerson].PersonID,
                            PersonID = p.PersonID,
                            Year = Year
                        };
                        db.XmusCringle.Add(draw);
                        //Remove the person they drew
                        foreach (Person pe in selFullPeople)
                        {
                            if (pe.PersonID == selPeople[intPerson].PersonID)
                            {
                                selFullPeople.Remove(pe);
                                break;
                            }
                        }
                    }
                    //No valid list, we FAILED!
                    else
                    {
                        success = false;
                        break;
                    }
                }
            }
            //If we're here we MUST have sucedded or REALLY failed (list 10000 times)
            if (success)
            {
                //save oru changes
                db.SaveChanges();
                db.CringleDetails.Load();
                //refresh the peoples draw boxen
            }*/
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
    }
}
