using System;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI.Localization;

namespace RonilaAccountingSoftware
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            RadGridLocalizationProvider.CurrentProvider = new myClass.PersianRadGridLocalizationProvider();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Light";
            //Application.Run(new Login());
            Application.Run(new myForms.Main());
        }
    }
}