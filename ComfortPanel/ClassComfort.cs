namespace ComfortPanel
{
    public class Temperature
    {
        public float cTemp;
        
        public Temperature(float CelciusTemp)
        {
            this.cTemp = CelciusTemp;
        }

      //  public float getCelciusTemp(Temperature temperature)
      //  {
      //      float CelciusTemp = temperature.cTemp;
      //
      //      return CelciusTemp;
      //  }

        public void setCelciusTemp(Temperature temperature, float CelciusTemp)
        {
            temperature.cTemp = CelciusTemp;
        }

        public float getTemperaturePlants(Temperature temp, string tempUnit)
        {
            float temperature;

            if (tempUnit == "C")
            {
                temperature = temp.cTemp;

                return temperature;
            }
            else if (tempUnit == "F")
            {
                temperature = (temp.cTemp * 9) / 5 + 32;

                return temperature;
            }
            else
            {
                return 0;
            }
        }

        public void createFileTemperature(Temperature temp, string tempUnit)
        {
            if (File.Exists("FileComfortTemperature.txt"))
            {
                File.Delete("FileComfortTemperature.txt");
            }

            Random random = new Random();

            double prefferedTemperature = temp.cTemp;

            int NValues = 100;

            double max = prefferedTemperature + 0.5;

            double min = prefferedTemperature - 0.5;

            for (int i = 0; i < NValues; i++)
            {
                double val = random.NextDouble() * (max - min) + min;

                File.AppendAllText("FileComfortTemperature.txt", val.ToString("0.0") + Environment.NewLine);
            }
        }

        public string readFileTemperature(string tempUnit)
        {
            if (File.Exists("FileComfortTemperature.txt"))
            {
                int counter = 0;

                foreach (string line in System.IO.File.ReadLines("FileComfortTemperature.txt"))
                {
                    if (tempUnit == "F")
                    {
                        double temp = Convert.ToDouble(line);
                        temp = (temp - 32) * 5 / 9;
                        return (Convert.ToString(temp));
                    }
                    else
                    {
                        return (line);
                    }

                    counter++;
                }
            }

            return String.Empty;
        }


    }

    public class Humidity
    {
        public float humidity;

        public Humidity(float hum1dity)
        {
            this.humidity = hum1dity;
        }

        public float getHumidityPlants(Humidity humidity)
        {
            float hum1dity = humidity.humidity;

            return hum1dity;
        }

        public void setHumidity(Humidity humidity, float preferredHumidity)
        {
            humidity.humidity = preferredHumidity;
        }

        public void createFileHumidity(float prefferedHumidity)
        {
            Random random = new Random();

            int NValues = 100;

            float max = prefferedHumidity + 4;

            float min = prefferedHumidity - 4;

            for (int i = 0; i < NValues; i++)
            {
                double val = random.NextDouble() * (max - min) + min;

                File.AppendAllText("FileComfortHumidity.txt", val.ToString("0.00") + Environment.NewLine);
            }
        }

        public string readFileHumidity()
        {
            if (File.Exists("FileComfortHumidity.txt"))
            {
                int counter = 0;

                foreach (string line in System.IO.File.ReadLines("FileComfortHumidity.txt"))
                {
                    return (line);
                    counter++;
                }
            }

            return String.Empty;
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