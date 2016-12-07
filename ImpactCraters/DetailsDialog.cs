using System;
using System.Windows.Forms;

namespace ImpactCraters
    {
    public partial class DetailsDialog : Form
        {
        public DetailsDialog ()
            {
            }

        public DetailsDialog (ImpactCratersDialog parent)
            {
            ParentDialog = parent;
            InitializeComponent ();

            ResizeBegin += new EventHandler (LibraryResizeBegin);
            ResizeEnd += new EventHandler (LibraryResizeEnd);
            SizeChanged += new EventHandler (LibraryResize);
            }

        public void AddText (Object obj)
            {
            if (obj is ImpactCrater)
                AddText (obj as ImpactCrater);
            }

        public void AddText (ImpactCrater crater)
            {
            detailsTextBox.ResetText ();

            detailsTextBox.Text += "Name             " + GetText (crater.Name) + "\r\n";
            detailsTextBox.Text += "Location         " + GetText (crater.Location) + "\r\n";
            detailsTextBox.Text += "Latitude         " + GetText (crater.Latitude) + "\r\n";
            detailsTextBox.Text += "Longitude        " + GetText (crater.Longitude) + "\r\n";
            detailsTextBox.Text += "Diameter         " + GetDiameters (crater.Diameter) + "\r\n";
            detailsTextBox.Text += "Age              " + GetAges (crater.Age) + "\r\n";
            detailsTextBox.Text += "Exposed          " + GetText (crater.Exposed) + "\r\n";
            detailsTextBox.Text += "Drilled          " + GetText (crater.Drilled) + "\r\n";
            detailsTextBox.Text += "Target Rock      " + GetText (crater.TargetRock) + "\r\n";
            detailsTextBox.Text += "Bolide Type      " + GetText (crater.BolideType) + "\r\n";

            detailsTextBox.Text += "\r\n";
            detailsTextBox.Text += "References\r\n";
            detailsTextBox.Text += "\r\n";

            for (int index = 0; index < crater.References.Count; ++index)
                detailsTextBox.Text += crater.References [index] + "\r\n";

            Update ();
            }

        private string GetText (string stringer)
            {
            return ( stringer.Length > 0 ) ? stringer : "-";
            }

        private string GetDiameters (string stringer)
            {
            return ( stringer.Length > 0 ) ? stringer + " (km)" : "-";
            }

        private string GetAges (string stringer)
            {
            return ( stringer.Length > 0 ) ? stringer + " (mly)" : "-";
            }

        private ImpactCratersDialog ParentDialog_ = null;
        private ImpactCratersDialog ParentDialog
            {
            get { return ParentDialog_; }
            set { ParentDialog_ = value; }
            }

        private void Details_FormClosing (object sender, FormClosingEventArgs e)
            {
            if (ParentDialog != null)
                ParentDialog.DetailsClosed ();
            }

        private void LibraryResizeBegin (object sender, EventArgs e)
            {
            }

        private void LibraryResizeEnd (object sender, EventArgs e)
            {
            }

        private void LibraryResize (object sender, EventArgs e)
            {
            if (detailsTextBox != null)
                {
                detailsTextBox.Height = Size.Height - 60;
                detailsTextBox.Width = Size.Width - 40;
                }
            }
        }
    }
