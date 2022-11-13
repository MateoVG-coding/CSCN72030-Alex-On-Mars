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
              //print warning that oxygen level is below 25%
            }
           else if (water_level < 25)
            {
                //print warning that water level is below 25%
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

    //not complete
    public class essentials_Power
    {
        private double power;
        private int powerUseLevel;

        public int getpowerUseLevels()
        {
            return powerUseLevel;
        }

        public void setpowerUseLevels(int use_level)
        {

        }
    }
}