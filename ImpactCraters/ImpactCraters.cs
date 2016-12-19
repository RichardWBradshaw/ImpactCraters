using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace ImpactCraters
    {
    public class ImpactCrater
        {
        private string Name_ = string.Empty;
        public string Name
            {
            get { return Name_; }
            set { Name_ = value; }
            }

        private string Location_ = string.Empty;
        public string Location
            {
            get { return Location_; }
            set { Location_ = value; }
            }

        private string Latitude_ = string.Empty;
        public string Latitude
            {
            get { return Latitude_; }
            set { Latitude_ = value; }
            }

        private string Longitude_ = string.Empty;
        public string Longitude
            {
            get { return Longitude_; }
            set { Longitude_ = value; }
            }

        private string Diameter_ = string.Empty;
        public string Diameter
            {
            get { return Diameter_; }
            set { Diameter_ = value; }
            }

        private string Age_ = string.Empty;
        public string Age
            {
            get { return Age_; }
            set { Age_ = value; }
            }

        private string Exposed_ = string.Empty;
        public string Exposed
            {
            get { return Exposed_; }
            set { Exposed_ = value; }
            }

        private string Drilled_ = string.Empty;
        public string Drilled
            {
            get { return Drilled_; }
            set { Drilled_ = value; }
            }

        private string TargetRock_ = string.Empty;
        public string TargetRock
            {
            get { return TargetRock_; }
            set { TargetRock_ = value; }
            }

        private string BolideType_ = string.Empty;
        public string BolideType
            {
            get { return BolideType_; }
            set { BolideType_ = value; }
            }

        private ArrayList References_ = null;
        public ArrayList References
            {
            get { return References_; }
            set { References_ = value; }
            }

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
        static private ArrayList CraterArray_ = null;
        static public ArrayList CraterArray
            {
            get { return CraterArray_; }
            set { CraterArray_ = value; }
            }

        public ImpactCraters ()
            {
            CraterArray = null;
            }

        static public void Add (ImpactCrater crater)
            {
            if (CraterArray == null)
                CraterArray = new ArrayList ();

            if (crater.Age != "-")
                {
                crater.Age = crater.Age.Replace (" ", "");
                crater.Age = crater.Age.Replace ("-", " to ");
                crater.Age = crater.Age.Replace ("Ma", "");
                crater.Age = crater.Age.Replace ("*", "");
                }

            crater.Drilled = Helper.AssignYesNo (crater.Drilled);
            crater.Exposed = Helper.AssignYesNo (crater.Exposed);

            crater.TargetRock = Helper.AssignTarget (crater.TargetRock);

            CraterArray.Add (crater);
            }

        static public void Read (string txtFileName)
            {
            if (File.Exists (txtFileName))
                {
                try
                    {
                    FileStream stream = new FileStream (txtFileName, FileMode.Open, FileAccess.Read);
                    StreamReader reader = new StreamReader (stream, System.Text.Encoding.Unicode);
                    ImpactCrater crater = new ImpactCrater ();

                    if (crater != null)
                        {
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

                    reader.Close ();
                    stream.Close ();
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show ("Error: " + ex.Message);
                    }
                }
            }

        static public void Write (string txtFileName, ImpactCrater crater)
            {
            if (crater == null)
                return;
            else if (File.Exists (txtFileName))
                {
                try
                    {
                    FileStream stream = new FileStream (txtFileName, FileMode.Open, FileAccess.Write);
                    StreamWriter writer = new StreamWriter (stream, System.Text.Encoding.Unicode);

                    writer.WriteLine (crater.Name);
                    writer.WriteLine (crater.Location);
                    writer.WriteLine (crater.Latitude);
                    writer.WriteLine (crater.Longitude);
                    writer.WriteLine (crater.Diameter);
                    writer.WriteLine (crater.Age);
                    writer.WriteLine (crater.Exposed);
                    writer.WriteLine (crater.Drilled);
                    writer.WriteLine (crater.TargetRock);
                    writer.WriteLine (crater.BolideType);

                    if (crater.References != null)
                        for (int index = 0; index < crater.References.Count; ++index)
                            writer.WriteLine (crater.References [index]);

                    writer.Close ();
                    stream.Close ();
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show ("Error: " + ex.Message);
                    }
                }
            }

        static public void Update (string folder, string name, string latitude, string longitude)
            {
            if (CraterArray != null)
                for (int index = 0; index < CraterArray.Count; ++index)
                    {
                    ImpactCrater crater = ( ImpactCrater )CraterArray [index];

                    if (crater != null)
                        if (crater.Name == name)
                            if (!( latitude == crater.Latitude && longitude == crater.Longitude ))
                                {
                                crater.Latitude = latitude;
                                crater.Longitude = longitude;

                                string fileName = Path.Combine (folder, name + ".txt");

                                Write (fileName, crater);
                                break;
                                }
                    }
            }
        }
    }

