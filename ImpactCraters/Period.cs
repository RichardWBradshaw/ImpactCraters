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
                // http://www.geosociety.org/science/timescale
                //

                if (double.TryParse (Helper.RemoveUnwantedChars (crater.Age), out age))
                    {
                    if (age <= 66.0)
                        {
                        if (age <= 2.6)
                            period = "Quaternary";
                        else if (age > 2.6 && age <= 23.0)
                            period = "Neogene";
                        else if (age > 23.03 && age <= 66.0)
                            period = "Paleogene";
                        }
                    else if (age > 66.0 && age <= 251.0)
                        {
                        if (age > 66.0 && age <= 145.0)
                            period = "Cretaceous";
                        else if (age > 145.0 && age <= 201.0)
                            period = "Jurassic";
                        else if (age > 201.0 && age <= 252.0)
                            period = "Triassic";
                        }
                    else if (age > 252.0 && age <= 541.0)
                        {
                        if (age > 251.0 && age <= 299.0)
                            period = "Permian";
                        else if (age > 299.0 && age <= 359.0)
                            period = "Carboniferous";
                        else if (age > 359.0 && age <= 419.0)
                            period = "Devonian";
                        else if (age > 419.0 && age <= 444.0)
                            period = "Silurian";
                        else if (age > 444.0 && age <= 485.0)
                            period = "Ordovician";
                        else if (age > 485.0 && age <= 541.0)
                            period = "Cambrian";
                        }
                    else
                        {
                        if (age > 541.0 && age <= 635.0)
                            period = "Ediacaran";
                        else if (age > 635.0 && age <= 850.0)
                            period = "Cryogenian";
                        else if (age > 850.0 && age <= 1000.0)
                            period = "Tonian";
                        else if (age > 1000.0 && age <= 1200.0)
                            period = "Stenian";
                        else if (age > 1200.0 && age <= 1400.0)
                            period = "Ectasian";
                        else if (age > 1400.0 && age <= 1600.0)
                            period = "Calymmian";
                        else if (age > 1600.0 && age <= 1800.0)
                            period = "Statherian";
                        else if (age > 1600.0 && age <= 2050.0)
                            period = "Orosirian";
                        else if (age > 2050.0 && age <= 2300.0)
                            period = "Rhyacian";
                        else if (age > 2300.0 && age <= 2500.0)
                            period = "Siderian";
                        }
                    }
                }

            return period;
            }
        }
    }
