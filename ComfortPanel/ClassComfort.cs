namespace ComfortPanel
{
    public class Temperature
    {
        public double cTemp;

        public Temperature()
        {
            cTemp = 24;
        }
        
        public Temperature(double CelciusTemp)
        {
            this.cTemp = CelciusTemp;
        }
           
       
        public double getTemperaturePlants(Temperature temp, string tempUnit)
        {
            double temperature;

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

        public void createFileTemperature(Temperature temp)
        {
            if (File.Exists("FileComfortTemperature.txt"))
            {
                File.Delete("FileComfortTemperature.txt");
            }

            Random random = new Random();

            double prefferedTemperature = temp.cTemp;

            int NValues = 5000;

            double max = prefferedTemperature + 0.1;

            double min = prefferedTemperature - 0.1;

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

        public void setTemperature(Temperature temperature, double CelciusTemp)
        {
            temperature.cTemp = CelciusTemp;
        }

    }

    public class Humidity
    {
        public double humidity;

        public Humidity()
        {
            humidity = 60;
        }

        public Humidity(double hum1dity)
        {
            this.humidity = hum1dity;
        }

        public double getHumidityPlants(Humidity humidity)
        {
            double hum1dity = humidity.humidity;

            return hum1dity;
        }

        public void setHumidity(Humidity humidity, double preferredHumidity)
        {
            humidity.humidity = preferredHumidity;
        }

        public void createFileHumidity(Humidity humidity)
        {
            if (File.Exists("FileComfortHumidity.txt"))
            {
                File.Delete("FileComfortHumidity.txt");
            }

            Random random = new Random();

            double prefferedHumidity = humidity.humidity;

            int NValues = 5000;

            double max = prefferedHumidity + 0.5;

            double min = prefferedHumidity - 0.5;

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