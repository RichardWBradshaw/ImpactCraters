using Microsoft.Win32;
using System.Collections;

namespace ImpactCraters
    {
    public enum QueryTypes
        {
        Class = 0,
        Region = 1,
        Country = 2,
        Continent = 3,
        Diameter = 4,
        Age = 5,
        Impactor = 6,
        }

    public enum QuerySubtypes
        {
        StartsWith = 0,
        Contains = 1,
        EndsWith = 2,
        }

    public class ClassQuery
        {
        public string Value;

        private QueryTypes QueryType_ = QueryTypes.Class;
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
                QueryTypes queryType = QueryTypes.Class;
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
                    case "class": queryType = QueryTypes.Class; break;
                    case "region": queryType = QueryTypes.Region; break;
                    case "country": queryType = QueryTypes.Country; break;
                    case "continent": queryType = QueryTypes.Continent; break;
                    case "diameter": queryType = QueryTypes.Diameter; break;
                    case "age": queryType = QueryTypes.Age; break;
                    case "impactor": queryType = QueryTypes.Impactor; break;
                    default:
                        return false;
                    }

                if (strings.Length == 3)
                    {
                    value = strings [2].ToLower ();

                    return true;
                    }
                else if (strings.Length == 4)
                    {
                    string query = strings [2].ToLower ();

                    if (query.StartsWith ("starts") || query.StartsWith ("startswith"))
                        querySubtype = QuerySubtypes.StartsWith;
                    else if (query.StartsWith ("contains"))
                        querySubtype = QuerySubtypes.Contains;
                    else if (query.StartsWith ("ends") || query.StartsWith ("endswith"))
                        querySubtype = QuerySubtypes.EndsWith;

                    value = strings [3].ToLower ();

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

        public bool MatchesQuery (ImpactCrater crater)
            {
            if (AllQueries.Count > 0)
                {
                foreach (ClassQuery query in AllQueries)
                    {
                    string value = string.Empty;

                    switch (query.QueryType)
                        {
                        case QueryTypes.Class: value = crater.Class; break;
                        case QueryTypes.Region: value = crater.Region; break;
                        case QueryTypes.Country: value = crater.Country; break;
                        case QueryTypes.Continent: value = crater.Continent; break;
                        case QueryTypes.Diameter: value = crater.Diameter.Diameter; break;
                        case QueryTypes.Age: value = crater.Ages.Age; break;
                        case QueryTypes.Impactor: value = crater.Impactor; break;
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
