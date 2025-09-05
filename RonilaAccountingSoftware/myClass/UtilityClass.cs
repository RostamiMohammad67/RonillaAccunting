using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace RonilaAccountingSoftware.myClass
{
    internal class UtilityClass
    {
        public static string Help_code1 = "";
        public static string Help_code2 = "";

        public static string Username;
        /// <summary>
        /// 1=success 2=warning 3=fail
        /// </summary>
        /// <param name="message"></param>
        /// <param name="alert_type"></param>
        public void Alert(string message, int alert_type)
        {
            RadDesktopAlert alert = new RadDesktopAlert();
            alert.CaptionText = "توجه";
            alert.AutoCloseDelay = 5;
            alert.AutoClose = true;
            alert.ContentText = message;
            if (alert_type == 1)
            {
                alert.ContentImage = Properties.Resources.opts_24;
            }
            else if (alert_type == 2)
            {
                alert.ContentImage = Properties.Resources.go_24;

            }
            else if (alert_type == 3)
            {
                alert.ContentImage = Properties.Resources.del_24;

            }
            alert.ScreenPosition = AlertScreenPosition.BottomRight;
            SystemSounds.Asterisk.Play();
            alert.Show();
        }
        public void successAlert()
        {
            RadDesktopAlert alert = new RadDesktopAlert();
            alert.CaptionText = "توجه";
            alert.AutoCloseDelay = 5;
            alert.AutoClose = true;
            alert.ContentText = "اطلاعات با موفقیت دخیره شدند";
            alert.ContentImage = Properties.Resources.opts_24;
            alert.ScreenPosition = AlertScreenPosition.BottomRight;
            SystemSounds.Asterisk.Play();
            alert.Show();
        }
        public void successDeleteAlert()
        {
            RadDesktopAlert alert = new RadDesktopAlert();
            alert.CaptionText = "توجه";
            alert.AutoCloseDelay = 5;
            alert.AutoClose = true;
            alert.ContentText = "اطلاعات با موفقیت حذف شدند";
            alert.ContentImage = Properties.Resources.opts_24;
            alert.ScreenPosition = AlertScreenPosition.BottomRight;
            SystemSounds.Asterisk.Play();
            alert.Show();
        }
        public void failAlert()
        {
            RadDesktopAlert alert = new RadDesktopAlert();
            alert.CaptionText = "توجه";
            alert.AutoCloseDelay = 5;
            alert.AutoClose = true;
            alert.ContentText = "داده ای ذخیره نشد";
            alert.ContentImage = Properties.Resources.del_24;
            alert.ScreenPosition = AlertScreenPosition.BottomRight;
            SystemSounds.Asterisk.Play();
            alert.Show();
        }
        #region DateTime()
        /// <summary>
        /// tarikh jari ra midahad  1393/06/09
        /// </summary>
        /// <returns></returns>
        public string today()
        {
            //Persia.SolarDate solarDate = Persia.Calendar.ConvertToPersian(DateTime.Now);
            //// getting the simple format of persian date
            //string str = solarDate.ToString();
            //return str;


            //-----------------------------------------
            DateTime dt = DateTime.Now;
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            string daynow = p.GetDayOfMonth(dt).ToString();
            if (daynow.Length == 1)
                daynow = "0" + daynow;
            string monthnow = p.GetMonth(dt).ToString();
            if (monthnow.Length == 1)
                monthnow = "0" + monthnow;


            string str = p.GetYear(dt) + "/" + monthnow + "/" + daynow;
            return str;
        }
        public string Miladi2Shamsi(string date)
        {

            DateTime dt = Convert.ToDateTime(date);
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            string daynow = p.GetDayOfMonth(dt).ToString();
            if (daynow.Length == 1)
                daynow = "0" + daynow;
            string monthnow = p.GetMonth(dt).ToString();
            if (monthnow.Length == 1)
                monthnow = "0" + monthnow;


            string str = p.GetYear(dt) + "/" + monthnow + "/" + daynow;
            return str;
        }
        public string day_of_week()
        {
            //Persia.SolarDate solarDate = Persia.Calendar.ConvertToPersian(DateTime.Now);
            //// getting the simple format of persian date

            //return day_of_week(solarDate.DayOfWeek);
            DateTime dt = DateTime.Now;
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            return GetPersianDayName(p.GetDayOfWeek(dt).ToString());

        }
        public string day_of_week(int day)
        {
            //Dictionary<string, string[]> DayOfWeeks = new Dictionary<string, string[]>();
            ////DayOfWeeks.Add("en", new string[] { "Saturday", "Sunday", "Monday", "Tuesday", "Thursday", "Wednesday", "Friday" });
            //DayOfWeeks.Add("fa", new string[] { "شنبه", "یک شنبه", "دو شنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه" });
            //return DayOfWeeks["fa"][(int)day].ToString();
            DateTime dt = DateTime.Now;
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            return GetPersianDayName(day.ToString());

        }
        public string today(string n)
        {
            //Persia.SolarDate solarDate = Persia.Calendar.ConvertToPersian(DateTime.Now);
            //string str = solarDate.ToString(n);



            DateTime dt = DateTime.Now;
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            string daynow = p.GetDayOfMonth(dt).ToString();
            if (daynow.Length == 1)
                daynow = "0" + daynow;
            string monthnow = p.GetMonth(dt).ToString();
            if (monthnow.Length == 1)
                monthnow = "0" + monthnow;
            string str = " امروز " + GetPersianDayName(p.GetDayOfWeek(dt).ToString()) + "  " + daynow + "  " + GetPersianMonthName(Convert.ToInt32(p.GetMonth(dt).ToString())) + " " + p.GetYear(dt);
            return str;
        }
        public string GetPersianDayName(string day)
        {
            PersianCalendar pc = new PersianCalendar();

            switch (day)
            {
                case "Saturday": return "شنبه";
                case "Sunday": return "یک شنبه";
                case "Monday": return "دوشنبه";
                case "Tuesday": return "سه شنبه";
                case "Wednesday": return "چهارشنبه";
                case "Thursday": return "پنج شنبه";
                case "Friday": return "جمعه";
                default: return "";
            }
        }
        public string GetPersianMonthName(int month)
        {
            string[] monthNames = new string[]
             {
                         "فروردین", "اردیبهشت", "خرداد",
                          "تیر", "مرداد", "شهریور",
                         "مهر", "آبان", "آذر",
                         "دی", "بهمن", "اسفند"
    };

            return monthNames[month - 1];
        }
        public string Gettime()
        {
            int H, M, S;
            string h, m, s;
            H = System.DateTime.Now.Hour;
            M = System.DateTime.Now.Minute;
            S = System.DateTime.Now.Second;
            if (H < 10) h = "0" + H; else h = "" + H;
            if (M < 10) m = "0" + M; else m = "" + M;
            if (S < 10) s = "0" + S; else s = "" + S;
            return h + ":" + m + ":" + s;
            //-----------------------------------------------
            //mydb db = new mydb();
            //db.dbname = "Tolid_Golsazi";
            //int H, M, S;
            //string h, m, s;
            //db.connect();
            //DateTime d = Convert.ToDateTime(db.select_AsCount("select GETDATE()"));
            //db.disconnect();
            //H = d.Hour;
            //M = d.Minute;
            //S = d.Second;

            //if (H < 10) h = "0" + H; else h = "" + H;
            //if (M < 10) m = "0" + M; else m = "" + M;
            //if (S < 10) s = "0" + S; else s = "" + S;
            //return h + ":" + m + ":" + s;

        }
        public string Gettime_server()
        {

            mydb db = new mydb();
            db.dbname = "Tolid_Golsazi";
            int H, M, S;
            string h, m, s;
            db.connect();
            DateTime d = Convert.ToDateTime(db.select_AsCount("select GETDATE()"));
            db.disconnect();
            H = d.Hour;
            M = d.Minute;
            S = d.Second;

            if (H < 10) h = "0" + H; else h = "" + H;
            if (M < 10) m = "0" + M; else m = "" + M;
            if (S < 10) s = "0" + S; else s = "" + S;
            return h + ":" + m + ":" + s;

        }
        public string Gettime_server(mydb db)
        {
            int H, M, S;
            string h, m, s;
            DateTime d = Convert.ToDateTime(db.select_AsCount("select GETDATE()"));
            H = d.Hour;
            M = d.Minute;
            S = d.Second;
            if (H < 10) h = "0" + H; else h = "" + H;
            if (M < 10) m = "0" + M; else m = "" + M;
            if (S < 10) s = "0" + S; else s = "" + S;
            return h + ":" + m + ":" + s;

        }

        public string TimeStamp()
        {
            return today() + " " + Gettime();

        }
        public string Time_Spam_server()
        {
            return today() + " " + Gettime_server();

        }
        public string Time_Spam_server(mydb db)
        {
            return today() + " " + Gettime_server(db);

        }


        public string farda(string date)
        {
            return AddDate(date, 1);

        }
        public double Sub_date(string start_date, string end_date)
        {
            TimeSpan result = Shamsi2Miladi(end_date) - Shamsi2Miladi(start_date);
            return result.TotalDays;
        }

        DateTime d;
        public DateTime Shamsi2Miladi(string _date)
        {
            int year = int.Parse(_date.Substring(0, 4));
            int month = int.Parse(_date.Substring(5, 2));
            int day = int.Parse(_date.Substring(8, 2));
            PersianCalendar p = new PersianCalendar();
            DateTime date = p.ToDateTime(year, month, day, 0, 0, 0, 0);
          
            return date;
        }
        public string Shamsi2MiladiString(string _date)
        {
            int year = int.Parse(_date.Substring(0, 4));
            int month = int.Parse(_date.Substring(5, 2));
            int day = int.Parse(_date.Substring(8, 2));
            PersianCalendar p = new PersianCalendar();
            DateTime date = p.ToDateTime(year, month, day, 0, 0, 0, 0);
            d = date;
            string res = d.ToString("yyyy/MM/dd");
            return res;
        }
        public string AddDate(string mydate, int numToAdd)
        {
            d=Shamsi2Miladi(mydate);
            d = d.AddDays(Convert.ToInt32(numToAdd));
            System.Globalization.PersianCalendar shamsi = new System.Globalization.PersianCalendar();
            DateTime sh;
            string strdate = null;
            strdate = d.ToShortDateString();
            sh = DateTime.Parse(strdate);
            int ysh = shamsi.GetYear(sh);
            int msh = shamsi.GetMonth(sh);
            int dsh = shamsi.GetDayOfMonth(sh);
            string M = "", D = "";
            if (dsh < 10)
            {
                D = "0" + dsh;
            }
            else
            {
                D = "" + dsh;
            }
            if (msh < 10)
            {
                M = "0" + msh;
            }
            else
            {
                M = "" + msh;
            }
            return ysh + "/" + M + "/" + D;

        }
        public string Addtime(string time, int minute)
        {
            DateTime t = Convert.ToDateTime(time);
            t = t.AddMinutes(minute);
            return t.ToString("T", DateTimeFormatInfo.InvariantInfo);
        }


        #endregion
        #region Message
        public DialogResult Edit_Question()
        {
            return MessageBox.Show("آیا از ویرایش داده ها اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        }
        public DialogResult Delete_Question()
        {
            return MessageBox.Show("آیا از حذف داده ها اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        }
        #endregion
        #region Image
        public byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        public Image ByteArrayToImage(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }

        #endregion
        #region StopMessage
        public void F_message(string mymessage)
        {
            MessageBox.Show(mymessage, "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void T_message()
        {
            MessageBox.Show("اطلاعات با موفقیت ثبت شدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public void T_message(string message)
        {
            MessageBox.Show(message, "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public DialogResult Q_message(string question)
        {
            return MessageBox.Show(question, "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        }
        public void Pleasecomplete_message()
        {
            MessageBox.Show("لطفا اطلاعات را کامل کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public DialogResult Save_message()
        {
            return MessageBox.Show("آیا از ثبت داده ها اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        #endregion
    }



}

