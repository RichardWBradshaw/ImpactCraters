using System.Collections;
using System.IO;

namespace ImpactCraters
    {
    public class ImpactCrater
        {
        public string Name;
        public string Location;
        public string Latitude;
        public string Longitude;
        public string Diameter;
        public string Age;
        public string Exposed;
        public string Drilled;
        public string TargetRock;
        public string BolideType;
        public ArrayList References;

        public ImpactCrater ()
            {
            Name = string.Empty;
            Location = string.Empty;
            Latitude = string.Empty;
            Longitude = string.Empty;
            Diameter = string.Empty;
            Age = string.Empty;
            Exposed = string.Empty;
            Drilled = string.Empty;
            TargetRock = string.Empty;
            BolideType = string.Empty;
            References = null;
            }

        public void AddReferences (string text)
            {
            if (References == null)
                References = new ArrayList ();

            if (text.StartsWith ("\""))
                text = text.Substring (1);

            if (text.EndsWith ("\""))
                text = text.Substring (0, text.Length - 1);

            References.Add (text);
            }
        }

    public class ImpactCraters
        {
        static public ArrayList CraterArray;

        public ImpactCraters ()
            {
            CraterArray = null;
            }

        static public void Add (ImpactCrater crater)
            {
            if (CraterArray == null)
                CraterArray = new ArrayList ();

            crater.Latitude = crater.Latitude.Replace ("°", "^");
            crater.Latitude = crater.Latitude.Replace ("�", "^");

            crater.Longitude = crater.Longitude.Replace ("°", "^");
            crater.Longitude = crater.Longitude.Replace ("�", "^");

            if(crater.Age != "-")
                {
                crater.Age = crater.Age.Replace (" ", "");
                crater.Age = crater.Age.Replace ("-", " to ");
                crater.Age = crater.Age.Replace (" ± ", " +/- ");
                crater.Age = crater.Age.Replace ("�", " +/- ");
                crater.Age = crater.Age.Replace ("Ma", "");
                crater.Age = crater.Age.Replace ("*", "");
                }

            crater.Drilled = Helper.AssignYesNo (crater.Drilled);
            crater.Exposed = Helper.AssignYesNo (crater.Exposed);

            CraterArray.Add (crater);
            }

        static public int Read (string txtFileName)
            {
            if (File.Exists (txtFileName))
                {
                TextReader reader = null;

                using (reader = File.OpenText (txtFileName))
                    {
                    ImpactCrater crater = new ImpactCrater ();

                    crater.Name = reader.ReadLine ();
                    crater.Location = reader.ReadLine ();
                    crater.Latitude = reader.ReadLine ();
                    crater.Longitude = reader.ReadLine ();
                    crater.Diameter = reader.ReadLine ();
                    crater.Age = reader.ReadLine ();
                    crater.Exposed = reader.ReadLine ();
                    crater.Drilled = reader.ReadLine ();
                    crater.TargetRock = reader.ReadLine ();
                    crater.BolideType = reader.ReadLine ();

                    string line = null;

                    for (;;)
                        {
                        if (( line = reader.ReadLine () ) != null)
                            crater.AddReferences (line);
                        else
                            break;
                        }

                    ImpactCraters.Add (crater);
                    }
                }

            return 0;
            }
        }
    }

