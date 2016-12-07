using System;
using System.Windows.Forms;

namespace ImpactCraters
    {
    static class Program
        {
        [STAThread]
        static void Main ()
            {
            Application.EnableVisualStyles ();
            Application.SetCompatibleTextRenderingDefault (false);
            Application.Run (new ImpactCratersDialog ());
            }
        }
    }
