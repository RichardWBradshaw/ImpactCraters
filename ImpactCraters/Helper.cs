namespace ImpactCraters
    {
    public class Helper
        {
        public Helper ()
            {
            }

        static public string AssignString (string stringer)
            {
            stringer = stringer.Trim ();

            if (stringer == "-")
                stringer = stringer.Replace ("-", "");

            stringer = stringer.Replace ("\"", "");

            return stringer;
            }

        static public string AssignYesNo (string stringer)
            {
            stringer = stringer.Trim ();

            if (stringer == "-")
                stringer = stringer.Replace ("-", "");

            if (stringer.ToLower () == "y")
                stringer = "Yes";
            else if (stringer.ToLower () == "n")
                stringer = "No";

            return stringer;
            }

        static public string AssignTarget (string stringer)
            {
            stringer = stringer.Trim ();

            if (stringer == "C")
                stringer = "Crystalline";
            else if (stringer == "C-Ms")
                stringer = "Metasedimentary";
            else if (stringer == "M")
                stringer = "Mixed";
            else if (stringer == "S")
                stringer = "Sedimentary";

            return stringer;
            }

        static public string GetText (string stringer)
            {
            return ( stringer.Length > 0 ) ? stringer : "-";
            }

        static public string ReformatCoordinate (string stringer)   // 86 10W or 32 31N or 86 10 12W or 32 31 34N
            {
            string prefix = stringer.Substring (0, 1);
            stringer = stringer.Substring (1, stringer.Length - 1);
            stringer = stringer + prefix;
            stringer = stringer.Replace ("°", " ");
            stringer = stringer.Replace ("'", "");
            stringer = stringer.Replace ("\"", "");

            return stringer.Trim ();
            }

        static public string SwapQuadrant (string stringer)         // 86 10 W to W 86 10
            {
            string prefix = stringer.Substring (0, 1);

            if (!( prefix == "N" || prefix == "S" || prefix == "W" || prefix == "E" ))
                {
                string suffix = stringer.Substring (stringer.Length - 1, 1);
                stringer = stringer.Replace (suffix, "");
                stringer = stringer.Replace ("°", "° ");
                stringer = stringer.Replace ("'", "' ");
                stringer = stringer.Replace ("  ", " ");
                stringer = suffix + " " + stringer;
                }

            return stringer.Trim ();
            }

        static public string RemoveUnwantedChars (string stringer)
            {
            stringer = stringer.Replace ("~", "");
            stringer = stringer.Replace ("<", "");
            stringer = stringer.Replace (">", "");

            string [] delimitors = { "±", "x", "to", "-" };

            for (int index = 0; index < delimitors.Length; ++index)
                if (stringer.Contains (delimitors [index]))
                    {
                    string [] delimitor = { delimitors [index] };
                    string [] stringers = stringer.Split (delimitor, System.StringSplitOptions.None);

                    stringer = stringers [0];
                    }

            stringer = stringer.Trim ();

            return stringer;
            }
        }
    }
