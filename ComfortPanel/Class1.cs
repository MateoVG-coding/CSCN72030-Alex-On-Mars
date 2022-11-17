namespace ComfortPanel
{
    public class Temperature
    {
        public float cTemp;
        
        public Temperature(float CelciusTemp)
        {
            this.cTemp = CelciusTemp;
        }

        public float getCelciusTemp(Temperature temperature)
        {
            float CelciusTemp = temperature.cTemp;

            return CelciusTemp;
        }

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
    }
}