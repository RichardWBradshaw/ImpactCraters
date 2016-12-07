using Microsoft.Win32;
using System.Collections;

namespace ImpactCraters
    {
    public enum QueryTypes
        {
        Name = 1,
        Location = 2,
        Diameter = 3,
        Age = 4,
        Period = 5,
        Exposed = 6,
        Drilled = 7,
        TargetRock = 8,
        BolideType = 9,
        }

    public enum QuerySubtypes
        {
        StartsWith = 0,
        Contains = 1,
        EndsWith = 2,
        GreaterThan = 3,
        LessThan = 4
        }

    public class ClassQuery
        {
        public string Value;

        private QueryTypes QueryType_ = QueryTypes.Name;
        public QueryTypes QueryType
            {
            get { return QueryType_; }
            set { QueryType_ = value; }
            }

        private QuerySubtypes QuerySubtype_ = QuerySubtypes.StartsWith;
        public QuerySubtypes QuerySubtype
            {
            get { return QuerySubtype_; }
            set { QuerySubtype_ = value; }
            }

        public ClassQuery ()
            {
            }

        public ClassQuery (string value, QueryTypes queryType, QuerySubtypes querySubtype)
            {
            Value = value;
            QueryType = queryType;
            QuerySubtype = querySubtype;
            }
        }

    public class Queries
        {
        static public Queries CurrentQueries = new Queries ();

        private ArrayList AllQueries = new ArrayList ();

        static public string [] Name = new string [30];
        static public string [] WhereClause = new string [30];

        public Queries ()
            {
            }

        public Queries (string text) : this ()
            {
            char [] delimiterChars = { '\r' };
            string query = text.Replace ('\n', ' ');
            query = query.ToLower ();
            string [] queries = query.Split (delimiterChars);

            for (int index = 0; index < queries.Length; ++index)
                {
                char [] delimiter2Chars = { ' ' };
                string [] strings = queries [index].Trim ().Split (delimiter2Chars);

                string name = string.Empty;
                QueryTypes queryType = QueryTypes.Name;
                QuerySubtypes querySubtype = QuerySubtypes.StartsWith;

                if (Parse (strings, ref name, ref queryType, ref querySubtype) == true)
                    {
                    Add (name, queryType, querySubtype);
                    }
                }
            }

        private bool Parse (string [] strings, ref string value, ref QueryTypes queryType, ref QuerySubtypes querySubtype)
            {
            querySubtype = QuerySubtypes.StartsWith;

            if (strings [0] == "where")
                {
                switch (strings [1])
                    {
                    case "name":
                        queryType = QueryTypes.Name;
                        break;

                    case "location":
                        queryType = QueryTypes.Location;
                        break;

                    case "diameter":
                        queryType = QueryTypes.Diameter;
                        break;

                    case "age":
                        queryType = QueryTypes.Age;
                        break;

                    case "period":
                        queryType = QueryTypes.Period;
                        break;

                    case "exposed":
                        queryType = QueryTypes.Exposed;
                        break;

                    case "drilled":
                        queryType = QueryTypes.Drilled;
                        break;

                    case "targetrock":
                    case "target":
                        queryType = QueryTypes.TargetRock;
                        break;

                    case "bolidetype":
                    case "bolide":
                        queryType = QueryTypes.BolideType;
                        break;

                    default:
                        return false;
                    }

                if (strings.Length == 3)
                    {
                    value = strings [2].ToLower ();

                    return true;
                    }
                else if (strings.Length >= 4)
                    {
                    string query = strings [2].ToLower ();

                    if (query.StartsWith ("starts") || query.StartsWith ("startswith"))
                        querySubtype = QuerySubtypes.StartsWith;
                    else if (query.StartsWith ("contains"))
                        querySubtype = QuerySubtypes.Contains;
                    else if (query.StartsWith ("ends") || query.StartsWith ("endswith"))
                        querySubtype = QuerySubtypes.EndsWith;
                    else if (query.StartsWith ("greaterthan") || query.StartsWith (">"))
                        querySubtype = QuerySubtypes.GreaterThan;
                    else if (query.StartsWith ("lessthan") || query.StartsWith ("<"))
                        querySubtype = QuerySubtypes.LessThan;

                    value = strings [3].ToLower ();

                    if (strings.Length == 5)
                        value += " " + strings [4].ToLower ();

                    return true;
                    }
                }

            return false;
            }

        private void Initialize ()
            {
            AllQueries = new ArrayList ();
            }

        private void Add (string value, QueryTypes queryType, QuerySubtypes querySubtype)
            {
            AllQueries.Add (new ClassQuery (value.ToLower (), queryType, querySubtype));
            }

        public bool MatchesQuery (object obj)
            {
            if (AllQueries.Count > 0)
                {
                ImpactCrater crater = obj as ImpactCrater;

                foreach (ClassQuery query in AllQueries)
                    {
                    string value = string.Empty;

                    switch (query.QueryType)
                        {
                        case QueryTypes.Name:
                            value = crater.Name;
                            break;

                        case QueryTypes.Location:
                            value = crater.Location;
                            break;

                        case QueryTypes.Diameter:
                            value = crater.Diameter;
                            break;

                        case QueryTypes.Age:
                            value = Helper.RemoveUnwantedChars (crater.Age);
                            break;

                        case QueryTypes.Period:
                            value = Period.Get (crater);
                            break;

                        case QueryTypes.Exposed:
                            value = crater.Exposed;
                            break;

                        case QueryTypes.Drilled:
                            value = crater.Drilled;
                            break;

                        case QueryTypes.TargetRock:
                            value = crater.TargetRock;
                            break;

                        case QueryTypes.BolideType:
                            value = crater.BolideType;
                            break;
                        }

                    value = value.ToLower ();

                    if (query.QuerySubtype == QuerySubtypes.StartsWith)
                        {
                        if (!value.StartsWith (query.Value))
                            return false;
                        }
                    else if (query.QuerySubtype == QuerySubtypes.EndsWith)
                        {
                        if (!value.EndsWith (query.Value))
                            return false;
                        }
                    else if (query.QuerySubtype == QuerySubtypes.Contains)
                        {
                        if (!value.Contains (query.Value))
                            return false;
                        }
                    else if (query.QuerySubtype == QuerySubtypes.GreaterThan)
                        {
                        double numericValue = 0.0, numericQueryValue = 0.0;

                        if (double.TryParse (value, out numericValue))
                            if (double.TryParse (query.Value, out numericQueryValue))
                                if (numericValue >= numericQueryValue)
                                    return true;

                        return false;
                        }
                    else if (query.QuerySubtype == QuerySubtypes.LessThan)
                        {
                        double numericValue = 0.0, numericQueryValue = 0.0;

                        if (double.TryParse (value, out numericValue))
                            if (double.TryParse (query.Value, out numericQueryValue))
                                if (numericValue <= numericQueryValue)
                                    return true;

                        return false;
                        }
                    }
                }

            return true;
            }

        public static void WriteQueries ()
            {
            RegistryKey key = RegistryKey.OpenRemoteBaseKey (RegistryHive.CurrentUser, string.Empty);
            RegistryKey subkey = ( key != null ) ? key.CreateSubKey ("Software\\ImpactCraters\\Queries") : null;

            if (subkey != null)
                for (int index = 0; index < Name.Length; ++index)
                    {
                    subkey.SetValue ("Name" + index.ToString (), Name [index], RegistryValueKind.String);
                    subkey.SetValue ("WhereClause" + index.ToString (), WhereClause [index], RegistryValueKind.String);
                    }

            if (key != null)
                key.Close ();
            }

        public static void ReadQueries ()
            {
            RegistryKey key = RegistryKey.OpenRemoteBaseKey (RegistryHive.CurrentUser, string.Empty);
            RegistryKey subkey = ( key != null ) ? key.CreateSubKey ("Software\\ImpactCraters\\Queries") : null;

            if (subkey != null)
                for (int index = 0; index < Name.Length; ++index)
                    {
                    object obj = subkey.GetValue ("Name" + index.ToString ());
                    Name [index] = obj != null ? obj as string : "query" + ( index + 1 ).ToString ();

                    obj = subkey.GetValue ("WhereClause" + index.ToString ());
                    WhereClause [index] = obj != null ? obj as string : string.Empty;
                    }

            if (key != null)
                key.Close ();
            }
        }
    }
