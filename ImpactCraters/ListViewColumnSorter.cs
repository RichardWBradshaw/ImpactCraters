using System.Collections;
using System.Windows.Forms;

//
// google search "How to sort a ListView control by a column in Visual C#"
//

namespace ImpactCraters
    {
    public class ListViewColumnSorter : IComparer
        {
        private CaseInsensitiveComparer ObjectCompare;

        private int ColumnToSort_ = 0;
        public int ColumnToSort
            {
            set { ColumnToSort_ = value; }
            get { return ColumnToSort_; }
            }

        private SortOrder OrderOfSort_ = SortOrder.Ascending;
        public SortOrder OrderOfSort
            {
            set { OrderOfSort_ = value; }
            get { return OrderOfSort_; }
            }

        private bool IsExtendedNumeric_ = false;
        public bool IsExtendedNumeric
            {
            set { IsExtendedNumeric_ = value; }
            get { return IsExtendedNumeric_; }
            }

        public ListViewColumnSorter ()
            {
            ColumnToSort = 0;
            OrderOfSort = SortOrder.Ascending;
            ObjectCompare = new CaseInsensitiveComparer ();
            IsExtendedNumeric = false;
            }

        public int Compare (object x, object y)
            {
            int compareResults = 0;
            double dx, dy;
            ListViewItem listviewX, listviewY;

            listviewX = ( ListViewItem )x;
            listviewY = ( ListViewItem )y;
            string stringX = listviewX.SubItems [ColumnToSort].Text;
            string stringY = listviewY.SubItems [ColumnToSort].Text;

            if (IsExtendedNumeric)
                {
                stringX = Helper.RemoveUnwantedChars (stringX);
                stringY = Helper.RemoveUnwantedChars (stringY);

                if (double.TryParse (stringX, out dx) && double.TryParse (stringY, out dy))
                    compareResults = ObjectCompare.Compare (dx, dy);
                else
                    compareResults = ObjectCompare.Compare (stringX, stringY);
                }
            else if (double.TryParse (stringX, out dx) && double.TryParse (stringY, out dy))
                compareResults = ObjectCompare.Compare (dx, dy);
            else
                compareResults = ObjectCompare.Compare (stringX, stringY);

            if (OrderOfSort == SortOrder.Ascending)
                return compareResults;
            else if (OrderOfSort == SortOrder.Descending)
                return ( -compareResults );
            else
                return 0;
            }
        }
    }
