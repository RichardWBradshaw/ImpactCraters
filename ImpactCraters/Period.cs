namespace ImpactCraters
    {
    class Period
        {
        static public string Get (ImpactCrater crater)
            {
            string period = string.Empty;

            if (crater != null)
                {
                double age = 0.0;

                //
                // http://www.ucmp.berkeley.edu/help/timeform.php
                //

                if (double.TryParse (Helper.RemoveUnwantedChars (crater.Age), out age))
                    {
                    if (age <= 65.5)
                        {
                        if (age <= 2.588)
                            period = "Quaternary";
                        else if (age > 2.588 && age <= 23.03)
                            period = "Neogene";
                        else if (age > 23.03 && age <= 65.5)
                            period = "Paleogene";
                        }
                    else if (age > 65.5 && age <= 251.0)
                        {
                        if (age > 65.5 && age <= 145.5)
                            period = "Cretaceous";
                        else if (age > 145.5 && age <= 199.6)
                            period = "Jurassic";
                        else if (age > 199.6 && age <= 251.0)
                            period = "Triassic";
                        }
                    else if (age > 251.0 && age <= 542.0)
                        {
                        if (age > 251.0 && age <= 299.0)
                            period = "Permian";
                        else if (age > 299.0 && age <= 359.2)
                            period = "Carboniferous";
                        else if (age > 359.2 && age <= 416.0)
                            period = "Devonian";
                        else if (age > 416.0 && age <= 443.7)
                            period = "Silurian";
                        else if (age > 443.7 && age <= 488.3)
                            period = "Ordovician";
                        else if (age > 488.3 && age <= 542.0)
                            period = "Cambrian";
                        }
                    else
                        {
                        if (age > 542.0 && age <= 1000)
                            period = "Neoproterozoic";
                        else if (age > 1000 && age <= 1600)
                            period = "Mesoproterozoic";
                        else if (age > 1600 && age <= 2500)
                            period = "Paleoproterozoic";
                        else if (age > 2500 && age <= 2800)
                            period = "Neoarchean";
                        else if (age > 2800 && age <= 3200)
                            period = "Mesoarchean";
                        else if (age > 3200 && age <= 3600)
                            period = "Paleoarchean";
                        else if (age > 3600 && age <= 4000)
                            period = "Eoarchean";
                        }
                    }
                }

            return period;
            }
        }
    }
