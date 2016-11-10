using System.IO;
using System.Collections;

namespace ImpactCraters
    {
    public class Reader
        {
        static public int Read (string csvFileName)
            {
            ArrayList craters = new ArrayList ();

            if (File.Exists (csvFileName))
                {
                TextReader reader = null;

                using (reader = File.OpenText (csvFileName))
                    {
                    string line = null;
                    ImpactCrater crater = null;

                    line = reader.ReadLine ();

                    for (;;)
                        {
                        if (( line = reader.ReadLine () ) != null)
                            {
                            if (IsDataLine (line))
                                crater = AssignFromString (line);
                            else if (crater != null)
                                crater.AddReferences (line);
                            }
                        else
                            break;
                        }
                    }
                }

            return 0;
            }

        static private bool IsDataLine (string line)
            {
            if (line.StartsWith ("0\t"))
                return true;
            else if (line.StartsWith ("1\t"))
                return true;
            else if (line.StartsWith ("2\t"))
                return true;
            else if (line.StartsWith ("3\t"))
                return true;
            else if (line.StartsWith ("4\t"))
                return true;
            else if (line.StartsWith ("5\t"))
                return true;
            else if (line.StartsWith ("6\t"))
                return true;
            else
                return false;
            }

        static private ImpactCrater AssignFromString (string line)
            {
            ImpactCrater crater = new ImpactCrater ();
            char [] delimiterChars = { '\t' };
            string [] strings = line.Split (delimiterChars);
            string [] classes = { "Confirmed", "Most Probable", "Probable", "Possible", "Improbable", "Rejected", "Proposed" };

            crater.Class = classes [int.Parse (strings [0]) + 1];
            crater.InheritedClass = AssignString( strings [1] );
            crater.StructureName = AssignString (strings [2] );
            crater.CraterField = AssignString (strings [3] );
            crater.Region = AssignString (strings [4] );
            crater.Country = AssignString (strings [5] );
            crater.Continent = AssignString( strings [6]);
            crater.Latitude = AssignString( strings [7]);
            crater.Longitude = AssignString( strings [8]);
            crater.Diameter.FinalRim = AssignString( strings [9]);
            crater.Diameter.PresentDay = AssignString( strings [10]);
            crater.Diameter.OuterLimitOfDeformation = AssignString( strings [11]);
            crater.Diameter.Diameter = AssignString( strings [12]);
            crater.Diameter.SQL = AssignString( strings [13]);
            crater.Ages.Age = AssignString( strings [14]);
            crater.Ages.Youngest = AssignString( strings [15]);
            crater.Ages.Best = AssignString( strings [16]);
            crater.Ages.Oldest = AssignString( strings [17]);
            crater.Ages.Uncertain = AssignString( strings [18]);
            crater.Ages.UncertainType = AssignString( strings [19]);
            crater.Overburden = AssignString( strings [20]);
            crater.PresentWaterDepth = AssignString( strings [21]);
            crater.Drilled = AssignString( strings [22]);
            crater.Target = AssignString( strings [23]);
            crater.TargetWaterDepth = AssignString( strings [24]);
            crater.Impactor = AssignString( strings [25]);
            crater.UpdatedOn = AssignString( strings [26]);
            crater.CompiledBy = AssignString( strings [27]);

            ImpactCraters.Add (crater);

            crater.AddReferences (strings [28]);

            return crater;
            }

        static private string AssignString (string stringer)
            {
            stringer = stringer.Trim ();

            if( stringer == "-")
                stringer = stringer.Replace ("-", "");

            stringer = stringer.Replace ("\"", "");

            return stringer;
            }
        }
    }

