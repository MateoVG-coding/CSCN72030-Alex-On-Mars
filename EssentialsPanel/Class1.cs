using System.Reflection.Emit;
using System.Reflection.Metadata;
using System;

namespace EssentialsPanel
{
    public class essentials_Oxygen_Water
    {
        private double oxygen_level;
        private double water_level;
 
       public double oxygenLevel()
        {
            Random rand = new Random();
            double oxyLevel = rand.Next(0, 101); //returns random number between 0-100
            return oxyLevel;
        }

        public double waterLevel()
        {
            Random rand = new Random();
            double waterLevel = rand.Next(0, 101); //returns random number between 0-100
            return waterLevel;
        }

        public int CheckLevels()
        {
           if (oxygen_level < 25)
            {
                Console.WriteLine("Warning!! fOxygen Level is below 25%");
            }
           else if (water_level < 25)
            {
                Console.WriteLine("Warning!! Water Level is below 25%");
            }

            return 0;
        }

        public double getOxygenLevel()
        {
            return oxygen_level;
        }

        public double getWaterLevel()
        {
            return water_level;
        }
        
        public void setOxygenLevel(double oxyLevel)
        {
            this.oxygen_level = oxyLevel;
        }

        public void setWaterLevel(double waterLevel)
        {
            this.water_level = waterLevel;
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