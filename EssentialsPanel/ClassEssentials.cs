using System.Reflection.Emit;
using System.Reflection.Metadata;
using System;

namespace EssentialsPanel
{
    public class EssentialsPanel
    {
        private double oxygen_level = 100;
        private double water_level = 20000;
       // private string[] oxygenUseLevel = new string[7];
       // private string[] waterUseLevel = new string[7];
       
        //public void oxygenUsed(double usedOxygen)
        //{
        //    StreamReader reader;
        //    var path = Path.Combine(Directory.GetCurrentDirectory(), "Oxygen Used.txt");
        //    reader = new StreamReader(path);
        //    string line = reader.ReadLine();
        //    int i = 0;

        //    while (i < 7 && line == oxygenUseLevel[i])
        //    {
        //        line = reader.ReadLine();
        //        i++;
        //    }

        //    if (line != null)
        //    {
        //        oxygenUseLevel[i] = line;
        //        usedOxygen = double.Parse(line);
        //        double newOxygenLevel = getOxygenLevel() - usedOxygen;

        //        setOxygenLevel(newOxygenLevel);
        //    }
        //    else
        //    {
        //        reader.Close();
        //    }
        //}

        public EssentialsPanel(double availableOxygen)
        {
            this.oxygen_level = availableOxygen;
        }
        public void createFileOxygen(EssentialsPanel essentialsPanel)
        {
            if (File.Exists("FileOxygen.txt"))
            {
                File.Delete("FileOxygen.txt");
            }

            double oxygenAvailable = essentialsPanel.oxygen_level;

            Random random = new Random();

            int NValues = 1000;

            double max = oxygenAvailable ;

            double min = oxygenAvailable - 1.5;

            for (int i = 0; i < NValues; i++)
            {
                double val = random.NextDouble() * (max - min) + min;

                File.AppendAllText("FileOxygen.txt", val.ToString("0.00") + Environment.NewLine);
            }
        }

        public string readFileOxygen()
        {
            if (File.Exists("FileOxygen.txt"))
            {
                int counter = 0;

                foreach (string line in System.IO.File.ReadLines("FileOxygen.txt"))
                {
                    return (line);
                    counter++;
                }
            }

            return String.Empty;
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

        public int setWaterLevel(double desiredWaterLt)
        {
            double newWaterLevel = getWaterLevel() - desiredWaterLt;

            if(newWaterLevel > 50)
            {
                this.water_level = newWaterLevel;

                return 0;
            }

            return 1;
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