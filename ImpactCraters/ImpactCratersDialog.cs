using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ImpactCraters
    {
    public partial class ImpactCratersDialog : Form
        {
        private ListView ImpacterListView_ = null;
        public ListView ImpacterListView
            {
            get { return ImpacterListView_; }
            set { ImpacterListView_ = value; }
            }

        private ListViewColumnSorter LvwColumnSorter_ = null;
        public ListViewColumnSorter LvwColumnSorter
            {
            get { return LvwColumnSorter_; }
            set { LvwColumnSorter_ = value; }
            }

        private QueryDialog QueryDialog_ = null;
        public QueryDialog QueryDialog
            {
            get { return QueryDialog_; }
            set { QueryDialog_ = value; }
            }

        private Queries Query_ = null;
        public Queries Query
            {
            get { return Query_; }
            set { Query_ = value; }
            }

        private DetailsDialog DetailsDialog_ = null;
        public DetailsDialog DetailsDialog
            {
            get { return DetailsDialog_; }
            set { DetailsDialog_ = value; }
            }

        private string LastDataDirectory_ = "C:\\ProgramData\\Impact Craters\\";
        private string LastDataDirectory
            {
            get { return LastDataDirectory_; }
            set { LastDataDirectory_ = value; }
            }

        public ImpactCratersDialog ()
            {
            InitializeComponent ();

            ReadSettings ();

            LvwColumnSorter = new ListViewColumnSorter ();

            CreateImpacterListView ();
            ImpacterListView.ListViewItemSorter = LvwColumnSorter;
            LvwColumnSorter.ColumnToSort = 1;
            LvwColumnSorter.OrderOfSort = SortOrder.Ascending;
            ImpacterListView.Sort ();

            ResizeBegin += new EventHandler (ImpacterResizeBegin);
            ResizeEnd += new EventHandler (ImpacterResizeEnd);
            SizeChanged += new EventHandler (ImpacterResize);
            }

        private void CreateImpacterListView ()
            {
            ImpacterListView = new ListView ();
            ImpacterListView.Bounds = new Rectangle (new Point (10, 24), new Size (Width - 40, Height - ( 60 + 24 )));

            ImpacterListView.View = View.Details;
            ImpacterListView.LabelEdit = false;
            ImpacterListView.AllowColumnReorder = true;
            ImpacterListView.CheckBoxes = false;
            ImpacterListView.FullRowSelect = true;
            ImpacterListView.GridLines = true;
            ImpacterListView.Sorting = SortOrder.None;
            ImpacterListView.ShowItemToolTips = true;

            AddItemsToListView (ImpacterListView);
            ImpacterListView.ColumnClick += new ColumnClickEventHandler (ImpacterListView_ColumnClick);
            ImpacterListView.Click += new EventHandler (ImpacterListView_Click);
            Controls.Add (ImpacterListView);
            }

        private void AddColumnsToListView (ListView listView)
            {
            int scrollBar = 21;
            int width = ( listView.Width - scrollBar ) / 11;

            listView.Columns.Add ("Name", width, HorizontalAlignment.Center);
            listView.Columns.Add ("Location", width, HorizontalAlignment.Center);
            listView.Columns.Add ("Latitude", width, HorizontalAlignment.Center);
            listView.Columns.Add ("Longitude", width, HorizontalAlignment.Center);
            listView.Columns.Add ("Diameter (km)", width, HorizontalAlignment.Center);
            listView.Columns.Add ("Age (mya)", width, HorizontalAlignment.Center);
            listView.Columns.Add ("Geologic Period", width, HorizontalAlignment.Center);
            listView.Columns.Add ("Exposed", width, HorizontalAlignment.Center);
            listView.Columns.Add ("Drilled", width, HorizontalAlignment.Center);
            listView.Columns.Add ("Target Rock", width, HorizontalAlignment.Center);
            listView.Columns.Add ("Bolide Type", width, HorizontalAlignment.Center);
            }

        private void AddItemsToListView (ListView listView)
            {
            if (listView != null)
                listView.BeginUpdate ();

            ImpacterListView.Clear ();
            AddColumnsToListView (listView);

            List<ListViewItem> items = new List<ListViewItem> ();

            if (ImpactCraters.CraterArray != null)
                foreach (ImpactCrater crater in ImpactCraters.CraterArray)
                    {
                    if (Queries.CurrentQueries != null)
                        if (!Queries.CurrentQueries.MatchesQuery (crater))
                            continue;

                    ListViewItem item = new ListViewItem (crater.Name, 0);

                    item.SubItems.Add (Helper.GetText (crater.Location));
                    item.SubItems.Add (Helper.GetText (crater.Latitude));
                    item.SubItems.Add (Helper.GetText (crater.Longitude));
                    item.SubItems.Add (Helper.GetText (crater.Diameter));
                    item.SubItems.Add (Helper.GetText (crater.Age));
                    item.SubItems.Add (Helper.GetText (Period.Get (crater)));
                    item.SubItems.Add (Helper.GetText (crater.Exposed));
                    item.SubItems.Add (Helper.GetText (crater.Drilled));
                    item.SubItems.Add (Helper.GetText (crater.TargetRock));
                    item.SubItems.Add (Helper.GetText (crater.BolideType));
                    item.Tag = crater;

                    items.Add (item);
                    }

            if (listView != null)
                {
                listView.Items.AddRange (items.ToArray ());
                listView.EndUpdate ();
                }
            }

        private void ImpacterResizeBegin (object sender, EventArgs e)
            {
            }

        private void ImpacterResizeEnd (object sender, EventArgs e)
            {
            }

        private void ImpacterResize (object sender, EventArgs e)
            {
            if (ImpacterListView != null)
                {
                ImpacterListView.Height = Size.Height - ( 60 + 24 );
                ImpacterListView.Width = Size.Width - 40;

                AddItemsToListView (ImpacterListView);
                }
            }

        private void ImpacterListView_ColumnClick (object sender, ColumnClickEventArgs e)
            {
            if (e.Column == LvwColumnSorter.ColumnToSort)
                {
                if (LvwColumnSorter.OrderOfSort == SortOrder.Ascending)
                    LvwColumnSorter.OrderOfSort = SortOrder.Descending;
                else
                    LvwColumnSorter.OrderOfSort = SortOrder.Ascending;
                }
            else
                {
                LvwColumnSorter.ColumnToSort = e.Column;
                LvwColumnSorter.OrderOfSort = SortOrder.Ascending;
                }

            //
            // treat age and diameter as numeric values
            //

            LvwColumnSorter.IsExtendedNumeric = ( LvwColumnSorter.ColumnToSort == 4 || LvwColumnSorter.ColumnToSort == 5 ) ? true : false;

            ImpacterListView.Sort ();
            }

        private void ImpacterListView_Click (object sender, EventArgs e)
            {
            if (ImpacterListView.SelectedItems.Count == 1)
                {
                ImpactCrater crater = ( object )ImpacterListView.SelectedItems [0].Tag as ImpactCrater;

                if (displayReferencesToolStripMenuItem.Checked)
                    {
                    if (DetailsDialog == null)
                        DetailsDialog = new DetailsDialog (this);

                    DetailsDialog.AddText (( object )ImpacterListView.SelectedItems [0].Tag);
                    DetailsDialog.Show ();
                    DetailsDialog.BringToFront ();
                    }

                if (displayGoggleMapToolStripMenuItem.Checked)
                    {
                    if (crater.Longitude.Length > 0 && crater.Latitude.Length > 0)
                        {
                        string url = "https://www.google.com/maps/place/" + Helper.ReformatCoordinate (crater.Longitude) + "+" + Helper.ReformatCoordinate (crater.Latitude);

                        System.Diagnostics.Process.Start (url);
                        }
                    }

                if (displayEarthImpactDatabaseToolStripMenuItem.Checked)
                    {
                    string name = crater.Name.ToLower ();
                    string [] from = { "Ilumetsä", " ", "-", ".", "ö", "ô", "å", "ã", "ä", "'" };
                    string [] to = { "Ilumets", "", "", "", "o", "o", "a", "a", "a", "" };

                    for (int index = 0; index < from.Length; ++index)
                        name = name.Replace (from [index], to [index]);

                    string url = "http://www.passc.net/EarthImpactDatabase/" + name + ".html";

                    System.Diagnostics.Process.Start (url);
                    }

                Focus ();
                }
            }

        private void Query_Click (object sender, EventArgs e)
            {
            if (QueryDialog == null)
                QueryDialog = new QueryDialog (this);

            QueryDialog.Show ();
            QueryDialog.BringToFront ();
            }

        public void QueryBuilderClosed ()
            {
            QueryDialog = null;
            }

        public void ProcessQuery ()
            {
            AddItemsToListView (ImpacterListView);
            }

        public void DetailsClosed ()
            {
            DetailsDialog = null;
            }

        private void Open_click (object sender, EventArgs e)
            {
            OpenFileDialog openFileDialog = new OpenFileDialog ();

            openFileDialog.InitialDirectory = LastDataDirectory;
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog () == DialogResult.OK)
                {
                try
                    {
                    if (ImpactCraters.CraterArray != null)
                        ImpactCraters.CraterArray.RemoveRange (0, ImpactCraters.CraterArray.Count - 1);

                    LastDataDirectory = openFileDialog.FileNames [0];
                    LastDataDirectory = LastDataDirectory.Substring (0, LastDataDirectory.LastIndexOf ('\\')) + "\\";

                    for (int index = 0; index < openFileDialog.FileNames.Length; ++index)
                        if (openFileDialog.OpenFile () != null)
                            ImpactCraters.Read (openFileDialog.FileNames [index]);

                    AddItemsToListView (ImpacterListView);
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show ("Error: " + ex.Message);
                    }
                }
            }

        private void Save_Click (object sender, EventArgs e)
            {
            SaveFileDialog saveFileDialog = new SaveFileDialog ();

            saveFileDialog.InitialDirectory = LastDataDirectory;
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|KML files (*.kml)|*.kml|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog () == DialogResult.OK)
                {
                try
                    {
                    Stream stream = null;

                    if (( stream = saveFileDialog.OpenFile () ) != null)
                        {
                        stream.Close ();

                        if (saveFileDialog.FileName.EndsWith (".csv"))
                            Writer.CSV (saveFileDialog.FileName);
                        else if (saveFileDialog.FileName.EndsWith (".kml"))
                            Writer.KML (saveFileDialog.FileName);
                        }
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show ("Error: " + ex.Message);
                    }
                }
            }

        private void Update_Click (object sender, EventArgs e)
            {
            OpenFileDialog openFileDialog = new OpenFileDialog ();

            openFileDialog.InitialDirectory = LastDataDirectory;
            openFileDialog.Filter = "KML files (*.kml)|*.kml|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog () == DialogResult.OK)
                {
                for (int index = 0; index < openFileDialog.FileNames.Length; ++index)
                    if (openFileDialog.OpenFile () != null)
                        Updater.Read (LastDataDirectory, openFileDialog.FileNames [index]);

                AddItemsToListView (ImpacterListView);
                }
            }

        private void launchEarthImpactDatabaseToolStripMenuItem_Click (object sender, EventArgs e)
            {
            string url = "http://www.passc.net/EarthImpactDatabase/";

            System.Diagnostics.Process.Start (url);
            }

        private void launchGoogleMyMapsToolStripMenuItem_Click (object sender, EventArgs e)
            {
            string url = "https://www.google.com/maps/d/u/0/";

            System.Diagnostics.Process.Start (url);
            }

        private void Exit_click (object sender, EventArgs e)
            {
            WriteSettings ();
            Close ();
            }

        private void ImpactCratersDialog_FormClosing (object sender, FormClosingEventArgs e)
            {
            WriteSettings ();
            }

        private void About_click (object sender, EventArgs e)
            {
            AboutBox about = new AboutBox ();
            about.ShowDialog ();
            }

        private void MenuCheckBox_Click (object sender, EventArgs e)
            {
            if (sender == displayReferencesToolStripMenuItem)
                {
                displayReferencesToolStripMenuItem.Checked = displayReferencesToolStripMenuItem.CheckState == CheckState.Checked ? false : true;
                }
            else if (sender == displayGoggleMapToolStripMenuItem)
                {
                displayGoggleMapToolStripMenuItem.Checked = displayGoggleMapToolStripMenuItem.CheckState == CheckState.Checked ? false : true;
                }
            else if (sender == displayEarthImpactDatabaseToolStripMenuItem)
                {
                displayEarthImpactDatabaseToolStripMenuItem.Checked = displayEarthImpactDatabaseToolStripMenuItem.CheckState == CheckState.Checked ? false : true;
                }
            }

        private void WriteSettings ()
            {
            RegistryKey key = RegistryKey.OpenRemoteBaseKey (RegistryHive.CurrentUser, string.Empty);
            RegistryKey subkey = ( key != null ) ? key.CreateSubKey ("Software\\ImpactCraters\\Queries") : null;

            if (subkey != null)
                {
                subkey.SetValue ("DisplayReferences", displayReferencesToolStripMenuItem.Checked ? "True" : "False", RegistryValueKind.String);
                subkey.SetValue ("DisplayGoogleMap", displayGoggleMapToolStripMenuItem.Checked ? "True" : "False", RegistryValueKind.String);
                subkey.SetValue ("DisplayEarthImpactDatabase", displayEarthImpactDatabaseToolStripMenuItem.Checked ? "True" : "False", RegistryValueKind.String);
                subkey.SetValue ("LastDataDirectory", LastDataDirectory, RegistryValueKind.String);
                }

            if (key != null)
                key.Close ();
            }

        private void ReadSettings ()
            {
            RegistryKey key = RegistryKey.OpenRemoteBaseKey (RegistryHive.CurrentUser, string.Empty);
            RegistryKey subkey = ( key != null ) ? key.CreateSubKey ("Software\\ImpactCraters\\Queries") : null;

            if (subkey != null)
                {
                displayReferencesToolStripMenuItem.Checked = ReadValue (subkey, "DisplayReferences");
                displayGoggleMapToolStripMenuItem.Checked = ReadValue (subkey, "DisplayGoogleMap");
                displayEarthImpactDatabaseToolStripMenuItem.Checked = ReadValue (subkey, "DisplayEarthImpactDatabase");
                LastDataDirectory = ( string )subkey.GetValue ("LastDataDirectory");
                }

            if (key != null)
                key.Close ();
            }

        private bool ReadValue (RegistryKey subkey, string name)
            {
            object obj = subkey.GetValue (name);

            if (obj != null)
                {
                string value = obj as string;

                if (value.Equals ("True"))
                    return true;
                else if (value.Equals ("False"))
                    return false;
                }

            return false;
            }
        }
    }
