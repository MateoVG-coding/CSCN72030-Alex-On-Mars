using System.Reflection.Emit;
using System.Reflection.Metadata;

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

//public getOxygenLevel(double oxyLevel); (This is the getter for the oxygen level parameter)
//    public getWaterLevel(double waterLevel); (This is the getter for the water level parameter)
//    public getUseLevels(int useLevel); (This is a the getter for power usage level parameter)
//    public setOxygenLevel(double oxygenLevel); (This is the setter for the oxygen level parameter)
//    public setWaterLevel(double water_Level); (This is the setter for the water level parameter)
//    public setUseLevels(int use_level); (This is a the setter for power usage level parameter)
//    public checkPower(); (This is a Boolean which checks if power is on or off)
//public checkLevels(); (This function checks for the levels of water and oxygen before displaying
//    it to user to make sure levels are not below a certain point.)