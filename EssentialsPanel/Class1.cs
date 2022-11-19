using System.Reflection.Emit;
using System.Reflection.Metadata;
using System;

namespace EssentialsPanel
{
    public class essentials_Oxygen_Water
    {
        private double oxygen_level;
        private double water_level = 20000;
        public double desiredWater;
        private double newWaterLevel;
        private string[] oxygenUseLevel = new string[6];
        private string[] waterUseLevel = new string[6];

        public double oxygenLevel()
        {
            Random rand = new Random();
            double oxyLevel = rand.Next(0, 101); //returns random number between 0-100
            return oxyLevel;
        }

        //public double waterLevel()
        //{
        //    Random rand = new Random();
        //    double waterLevel = rand.Next(0, 101); //returns random number between 0-100
        //    return waterLevel;
        //}

        /// ///////////////////////////
        public int CheckLevels()
        {
           if (oxygen_level < 25)
            {
                Console.WriteLine("Warning!! Oxygen Level is below 25%");
            }
           else if (water_level < 25)
            {
                Console.WriteLine("Warning!! Water Level is below 25%");
            }

            return 0;
        }

        public void oxygenUsed(double usedOxygen)
        {
            StreamReader reader;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Oxygen Used.txt");
            reader = new StreamReader(path);
            string line = reader.ReadLine();
            int i = 0;

            while (i < 7 && line == oxygenUseLevel[i])
            {
                line = reader.ReadLine();
                i++;
            }

            if (line != null)
            {
                oxygenUseLevel[i] = line;
                usedOxygen = double.Parse(line);
                double newOxygenLevel = getOxygenLevel() - usedOxygen;

                setOxygenLevel(newOxygenLevel);
            }
            else
            {
                reader.Close();
            }
        }

        public double WaterUsed(double desiredWater)
        {
            if (water_level < desiredWater)
            {
                return 0;
            }
            else
            {
                double newWaterLevel = desiredWater - water_level;
                return newWaterLevel;
            }
        }



        public double getOxygenLevel()
        {
            return oxygen_level;
        }

        public double getWaterLevel()
        {
            return desiredWater;
        }
        
        public void setOxygenLevel(double oxyLevel)
        {
            this.oxygen_level = oxyLevel;
        }

        public void setWaterLevel()
        {
            double newWater_level = water_level - desiredWater;
            if (newWaterLevel > 50)
            {
                this.water_level = newWaterLevel;
            }
        }
    }

    public class powerConsumed
    {
        private int powerconsumed;

        public powerConsumed(int power)
        {
            this.powerconsumed = power;
        }

        public int getPower()
        {
            return this.powerconsumed;
        }

        public int setPower(int power)
        {
            this.powerconsumed = power;
            return this.powerconsumed;
        } 
    }
}