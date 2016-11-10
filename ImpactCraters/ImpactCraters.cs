using System.Collections;

namespace ImpactCraters
    {
    public class Ages
        {
        public string Age;
        public string Youngest;
        public string Oldest;
        public string Best;
        public string Uncertain;
        public string UncertainType;

        public Ages ()
            {
            Age = string.Empty;
            Youngest = string.Empty;
            Oldest = string.Empty;
            Best = string.Empty;
            Uncertain = string.Empty;
            UncertainType = string.Empty;
            }
        }

    public class Diameters
        {
        public string FinalRim;
        public string PresentDay;
        public string OuterLimitOfDeformation;
        public string Diameter;
        public string SQL;

        public Diameters ()
            {
            FinalRim = string.Empty;
            PresentDay = string.Empty;
            OuterLimitOfDeformation = string.Empty;
            Diameter = string.Empty;
            SQL = string.Empty;
            }
        }

    public class ImpactCrater
        {
        public string Class;
        public string InheritedClass;
        public string StructureName;
        public string CraterField;
        public string Region;
        public string Country;
        public string Continent;
        public string Latitude;
        public string Longitude;
        public Diameters Diameter;
        public Ages Ages;
        public string Overburden;                 // m
        public string PresentWaterDepth;        // m
        public string Drilled;
        public string Target;
        public string TargetWaterDepth;         // m
        public string Impactor;
        public string UpdatedOn;
        public string CompiledBy;
        public ArrayList References;

        public ImpactCrater ()
            {
            Class = string.Empty;
            InheritedClass = string.Empty;
            StructureName = string.Empty;
            CraterField = string.Empty;
            Region = string.Empty;
            Country = string.Empty;
            Continent = string.Empty;
            Latitude = string.Empty;
            Longitude = string.Empty;
            Diameter = new Diameters ();
            Ages = new Ages ();
            Overburden = string.Empty;
            PresentWaterDepth = string.Empty;
            Drilled = string.Empty;
            Target = string.Empty;
            TargetWaterDepth = string.Empty;
            Impactor = string.Empty;
            UpdatedOn = string.Empty;
            CompiledBy = string.Empty;

            References = null;
            }

        public void AddReferences (string text)
            {
            if (References == null)
                References = new ArrayList ();

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

            CraterArray.Add (crater);
            }
        }
    }
