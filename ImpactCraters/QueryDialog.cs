using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImpactCraters
    {
    public partial class QueryDialog : Form
        {
        static private int CurrentIndex = 0;

        public QueryDialog ()
            {
            }

        public QueryDialog (ImpactCratersDialog parent) : this ()
            {
            ParentDialog = parent;
            InitializeComponent ();

            Queries.ReadQueries ();

            queryComboBox.BeginUpdate ();
            queryComboBox.Items.AddRange (Queries.Name);
            queryComboBox.EndUpdate ();

            queryComboBox.SelectedIndex = CurrentIndex;
            queryTextBox.Text = Queries.WhereClause [CurrentIndex];
            Update ();
            }

        private ImpactCratersDialog ParentDialog_ = null;
        private ImpactCratersDialog ParentDialog
            {
            get { return ParentDialog_; }
            set { ParentDialog_ = value; }
            }

        private void QueryBuilder_FormClosing (object sender, FormClosingEventArgs e)
            {
            if (ParentDialog != null)
                ParentDialog.QueryBuilderClosed ();
            }

        private void queryComboBox_selectedIndexChanged (object sender, EventArgs e)
            {
            if (queryComboBox.SelectedIndex >= 0 && queryComboBox.SelectedIndex < Queries.Name.Length)
                {
                CurrentIndex = queryComboBox.SelectedIndex;
                queryTextBox.Text = Queries.WhereClause [CurrentIndex];
                queryTextBox.Update ();
                Update ();
                }
            }

        private void exampleQueryButton_click (object sender, EventArgs e)
            {
            MessageBox.Show (
                "where <keyword> <string-value>\n" +
                "where <keyword> startswith <string-value>\n" +
                "where <keyword> contains <string-value>\n" +
                "where <keyword> endswith <string-value>\n" +
                "<keyword> is either 'class', 'region', 'country', 'continent', 'diameter', 'age' or 'impacter'\n" +
                "<string-value> is an alpha-numeric string\n\n"
                , "Example query statements"
                );
            }

        private void updateQueryButton_Click (object sender, EventArgs e)
            {
            if (queryComboBox.SelectedIndex >= 0 && queryComboBox.SelectedIndex < Queries.Name.Length)
                {
                CurrentIndex = queryComboBox.SelectedIndex;
                Queries.WhereClause [CurrentIndex] = queryTextBox.Text;

                Queries.Name [CurrentIndex] = NameFromWhereClause ();

                queryComboBox.Items.Clear ();

                queryComboBox.BeginUpdate ();
                queryComboBox.Items.AddRange (Queries.Name);
                queryComboBox.EndUpdate ();

                queryComboBox.SelectedIndex = CurrentIndex;
                }
            }

        private void applyButton_Click (object sender, EventArgs e)
            {
            Queries.CurrentQueries = new Queries (queryTextBox.Text);
            Queries.WriteQueries ();

            ParentDialog.ProcessQuery ();
            }

        private string NameFromWhereClause ()
            {
            if (Queries.WhereClause [CurrentIndex].Length > 0)
                {
                char [] delimiterChars = { '\n', '\r' };
                string [] strings = Queries.WhereClause [CurrentIndex].Split (delimiterChars);

                return strings [0];
                }

            return Queries.Name [CurrentIndex];
            }
        }
    }
