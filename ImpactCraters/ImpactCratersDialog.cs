using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ImpactCraters
    {
    public partial class ImpactCratersDialog : Form
        {
        private ListView CraterListView_ = null;
        public ListView CraterListView
            {
            get { return CraterListView_; }
            set { CraterListView_ = value; }
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

        public ImpactCratersDialog ()
            {
            InitializeComponent ();

            Reader.Read ("C:\\Various Code\\IMPACT_CRATERS\\Impact_database_2010_1.txt");

            CreateCraterListView ();

            LvwColumnSorter = new ListViewColumnSorter ();
            CraterListView.ListViewItemSorter = LvwColumnSorter;

            ResizeBegin += new EventHandler (LibraryResizeBegin);
            ResizeEnd += new EventHandler (LibraryResizeEnd);
            SizeChanged += new EventHandler (LibraryResize);
            }

        private void CreateCraterListView ()
            {
            CraterListView = new ListView ();
            CraterListView.Bounds = new Rectangle (new Point (10, 24), new Size (Width - 40, Height - ( 60 + 24 )));

            CraterListView.View = View.Details;
            CraterListView.LabelEdit = false;
            CraterListView.AllowColumnReorder = true;
            CraterListView.CheckBoxes = false;
            CraterListView.FullRowSelect = true;
            CraterListView.GridLines = true;
            CraterListView.Sorting = SortOrder.None;

            AddItemsToListView (CraterListView);
            CraterListView.ColumnClick += new ColumnClickEventHandler (CraterListView_ColumnClick);
            CraterListView.Click += new EventHandler (CraterListView_Click);
            Controls.Add (CraterListView);
            }

        private void AddColumnsToListView (ListView listView)
            {
            listView.Columns.Add ("Class", -2, HorizontalAlignment.Center);
            listView.Columns.Add ("Structure Name", -2, HorizontalAlignment.Center);
            listView.Columns.Add ("Region", -2, HorizontalAlignment.Center);
            listView.Columns.Add ("Country", -2, HorizontalAlignment.Center);
            listView.Columns.Add ("Continent", -2, HorizontalAlignment.Center);
            listView.Columns.Add ("Latitude", -2, HorizontalAlignment.Center);
            listView.Columns.Add ("Longitude", -2, HorizontalAlignment.Center);
            listView.Columns.Add ("Diameter (km)", -2, HorizontalAlignment.Center);
            listView.Columns.Add ("Age (mly)", -2, HorizontalAlignment.Center);
            listView.Columns.Add ("Impactor", -2, HorizontalAlignment.Center);
            }

        private void AddItemsToListView (ListView listView)
            {
            if (listView != null)
                listView.BeginUpdate ();

            AddColumnsToListView (listView);

            List<ListViewItem> items = new List<ListViewItem> ();

            if (ImpactCraters.CraterArray != null)
                foreach (ImpactCrater crater in ImpactCraters.CraterArray)
                    {
                    if (Queries.CurrentQueries != null)
                        if (!Queries.CurrentQueries.MatchesQuery (crater))
                            continue;

                    ListViewItem item = new ListViewItem (crater.Class, 0);

                    item.SubItems.Add (crater.StructureName);
                    item.SubItems.Add (crater.Region);
                    item.SubItems.Add (crater.Country);
                    item.SubItems.Add (crater.Continent);
                    item.SubItems.Add (crater.Latitude);
                    item.SubItems.Add (crater.Longitude);
                    item.SubItems.Add (crater.Diameter.Diameter);
                    item.SubItems.Add (crater.Ages.Age);
                    item.SubItems.Add (crater.Impactor);
                    item.Tag = crater;

                    items.Add (item);
                    }

            if (listView != null)
                {
                listView.Items.AddRange (items.ToArray ());
                listView.EndUpdate ();
                }
            }

        private void UpdateCraterListView (ListView listView)
            {
            if (listView != null)
                listView.BeginUpdate ();

            List<ListViewItem> items = new List<ListViewItem> ();

            if (ImpactCraters.CraterArray != null)
                foreach (ImpactCrater crater in ImpactCraters.CraterArray)
                    {
                    if (Queries.CurrentQueries != null)
                        if (!Queries.CurrentQueries.MatchesQuery (crater))
                            continue;

                    ListViewItem item = new ListViewItem (crater.Class, 0);

                    item.SubItems.Add (crater.StructureName);
                    item.SubItems.Add (crater.Region);
                    item.SubItems.Add (crater.Country);
                    item.SubItems.Add (crater.Continent);
                    item.SubItems.Add (crater.Latitude);
                    item.SubItems.Add (crater.Longitude);
                    item.SubItems.Add (crater.Diameter.Diameter);
                    item.SubItems.Add (crater.Ages.Age);
                    item.SubItems.Add (crater.Impactor);
                    item.Tag = crater;

                    items.Add (item);
                    }

            if (listView != null)
                {
                listView.Items.AddRange (items.ToArray ());
                listView.EndUpdate ();
                }
            }

        private void LibraryResizeBegin (object sender, EventArgs e)
            {
            }

        private void LibraryResizeEnd (object sender, EventArgs e)
            {
            }

        private void LibraryResize (object sender, EventArgs e)
            {
            Control control = ( Control )sender;

            if (CraterListView != null)
                {
                CraterListView.Height = Size.Height - ( 60 + 24 );
                CraterListView.Width = Size.Width - 40;
                }
            }

        private void CraterListView_ColumnClick (object sender, ColumnClickEventArgs e)
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

            LvwColumnSorter.IsExtendedNumeric = ( LvwColumnSorter.ColumnToSort == 7 || LvwColumnSorter.ColumnToSort == 8 ) ? true : false;

            CraterListView.Sort ();
            }

        private void CraterListView_Click (object sender, EventArgs e)
            {
            if (CraterListView.SelectedItems.Count == 1)
                {
                ImpactCrater crater = ( ImpactCrater )CraterListView.SelectedItems [0].Tag;

                if (crater.Longitude.Length > 0 && crater.Latitude.Length> 0)
                    {
                    string longitudeSuffix = crater.Longitude.StartsWith ("-") ? "W" : "E";
                    string longitude = crater.Longitude.Replace ('-', ' ');
                    string latitudeSuffix = crater.Latitude.StartsWith ("-") ? "S" : "N";
                    string latitude = crater.Latitude.Replace ('-', ' ');

                    string url = "https://www.google.com/maps/place/" + longitude + longitudeSuffix + "+" + latitude + latitudeSuffix;

                    System.Diagnostics.Process.Start (url);
                     }
                }
            }

        private void query_Click (object sender, EventArgs e)
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
            for (int index = CraterListView.Items.Count - 1; index >= 0; --index)
                CraterListView.Items.RemoveAt (index);

            UpdateCraterListView (CraterListView);
            }
        }
    }
