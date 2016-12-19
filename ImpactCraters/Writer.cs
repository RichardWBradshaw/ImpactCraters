using System.IO;

namespace ImpactCraters
    {
    class Writer
        {
        static public void CSV (string csvFileName)
            {
            TextWriter writer = null;

            using (writer = File.CreateText (csvFileName))
                {
                if (ImpactCraters.CraterArray != null)
                    {
                    writer.Write ("longitude,latitude,name\r\n");

                    foreach (ImpactCrater crater in ImpactCraters.CraterArray)
                        {
                        if (Queries.CurrentQueries != null)
                            if (!Queries.CurrentQueries.MatchesQuery (crater))
                                continue;

                        if (crater.Longitude.Length > 0 && crater.Latitude.Length > 0)
                            {
                            writer.Write (ConvertToDecimal (crater.Longitude) + "," + ConvertToDecimal (crater.Latitude) + "," + crater.Name + "\r\n");
                            }
                        }
                    }
                }

            writer.Close ();
            }

        static public void KML (string kmlFileName)
            {
            TextWriter writer = null;

            using (writer = File.CreateText (kmlFileName))
                {
                if (ImpactCraters.CraterArray != null)
                    {
                    writer.Write ("<?xml version='1.0' encoding='UTF-8'?>\r\n");
                    writer.Write ("<kml xmlns='http://www.opengis.net/kml/2.2'>\r\n");
                    writer.Write ("<Document>\r\n");
                    writer.Write ("    <name>Impact Craters</name>\r\n");
                    writer.Write ("    <description><![CDATA[]]></description>\r\n");
                    writer.Write ("    <Folder>\r\n");

                    foreach (ImpactCrater crater in ImpactCraters.CraterArray)
                        {
                        if (Queries.CurrentQueries != null)
                            if (!Queries.CurrentQueries.MatchesQuery (crater))
                                continue;

                        if (crater.Longitude.Length > 0 && crater.Latitude.Length > 0)
                            {
                            writer.Write ("    <Placemark>\r\n");
                            writer.Write ("        <name>" + crater.Name + "</name>\r\n");
                            writer.Write ("        <description><![CDATA[" +
                                                            "Age " + crater.Age + " mya" + "(" + Period.Get (crater) + ")" +
                                                            "\rDiameter " + crater.Diameter + " km" +
                                                            "\rExposed " + crater.Exposed +
                                                            "\rDrilled " + crater.Drilled +
                                                            "\rTarget Rock " + crater.TargetRock +
                                                            "\rBolide Type " + crater.BolideType +
                                                         "]]></description>\r\n");
                            writer.Write ("        <Point>\r\n");
                            writer.Write ("            <coordinates>" + ConvertToDecimal (crater.Longitude) + "," + ConvertToDecimal (crater.Latitude) + "," + "0.0</coordinates>\r\n");
                            writer.Write ("        </Point>\r\n");
                            writer.Write ("    </Placemark>\r\n");
                            }
                        }

                    writer.Write ("    </Folder>\r\n");
                    writer.Write ("</Document>\r\n");
                    writer.Write ("</kml>\r\n");
                    }
                }

            writer.Close ();
            }

        private static string ConvertToDecimal (string stringer)
            {
            double value = 0.0, degree = 0.0;
            double signage = ( stringer.StartsWith ("W") || stringer.StartsWith ("S") ) ? -1.0 : 1.0;

            string [] from = { "N", "S", "E", "W", "°", "'", "\"", "  " };
            string [] to = { "", "", "", "", " ", " ", " ", " " };

            for (int index = 0; index < from.Length; ++index)
                stringer = stringer.Replace (from [index], to [index]);

            stringer = stringer.Trim ();

            string [] delimitor = { " " };

            string [] stringers = stringer.Split (delimitor, System.StringSplitOptions.None);

            if (stringers.Length > 2)
                if (double.TryParse (stringers [2], out value))
                    degree += value / 3600.0;

            if (stringers.Length > 1)
                if (double.TryParse (stringers [1], out value))
                    degree += value / 60.0;

            if (stringers.Length > 0)
                if (double.TryParse (stringers [0], out value))
                    degree += value;

            degree *= signage;

            return degree.ToString ();
            }
        }
    }
