using System.Xml;

namespace ImpactCraters
    {
    public class Updater
        {
        //
        // reference: http://stackoverflow.com/questions/7119806/reading-data-from-xml
        //

        static public void Read (string folder, string xmlFileName)
            {
            XmlReader reader = null;
            string name = string.Empty, latitude = string.Empty, longitude = string.Empty;

            using (reader = XmlReader.Create (xmlFileName))
                {
                reader.MoveToContent ();

                while (reader.Read ())
                    {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Placemark")
                        {
                        while (reader.Read ())
                            {
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "name")
                                {
                                name = reader.ReadString ();
                                break;
                                }
                            }

                        while (reader.Read ())
                            {
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "description")
                                {
                                string stringer = reader.ReadString ();
                                string [] delimitor = { "<br>" };
                                string [] stringers = stringer.Split (delimitor, System.StringSplitOptions.None);

                                latitude = stringers [1];
                                latitude = latitude.Replace ("Latitude: ", "");
                                longitude = stringers [2];
                                longitude = longitude.Replace ("Longitude: ", "");

                                break;
                                }
                            }

                        if (name != string.Empty)
                            if (latitude != string.Empty)
                                if (longitude != string.Empty)
                                    ImpactCraters.Update (folder, name, Helper.SwapQuadrant (latitude), Helper.SwapQuadrant (longitude));
                        }
                    }
                }

            reader.Close ();
            }
        }
    }
