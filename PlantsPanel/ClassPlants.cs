using System;

namespace PlantsPanel
{
    public class PlantsPanel
    {
        public int FieldNum { get; private set; }
        public float WaterConsumption { get; private set; }
        public float OxygenConsumption { get; private set; }
        public int PowerConsumption { get; private set; }
        public int LightIntensity { get; private set; }
        public float ActualTemperature { get; private set; }
        public float ActualHumidity { get; private set; }

        public PlantsPanel()
        {
            FieldNum = 0;
            WaterConsumption = 0;
            OxygenConsumption = 0;
            PowerConsumption = 0;
            LightIntensity = 0;
            ActualTemperature = 0;
            ActualHumidity = 0;
        }

        public PlantsPanel(int fieldNum, float waterLt, float temperatureCelsius, int lightIntensity, float humidity, float oxygenConsumption, int powerConsumption)
        {
            this.FieldNum = fieldNum;
            this.WaterConsumption = waterLt;
            this.OxygenConsumption = oxygenConsumption;
            this.PowerConsumption = powerConsumption;
            this.LightIntensity = lightIntensity;
            this.ActualTemperature = temperatureCelsius;
            this.ActualHumidity = humidity;
        }

        public int getFieldNum(PlantsPanel plantsPanel)
        {
            int fieldNum = plantsPanel.FieldNum;

            return fieldNum;
        }

        public float getWaterPlants(PlantsPanel plantsPanel)
        {
            float waterConsumption = plantsPanel.WaterConsumption;

            return waterConsumption;
        }

        public float getOxygenPlants(PlantsPanel plantsPanel)
        {
            float oxygen = plantsPanel.OxygenConsumption;

            return oxygen;
        }

        public int getPlantPowerConsumption(PlantsPanel plantsPanel)
        {
            int power = plantsPanel.PowerConsumption;

            return power;
        }

        public string getLightIntensityPlants(PlantsPanel plantsPanel)
        {
            if (plantsPanel.LightIntensity == 0)
            {
                return "Low";
            }
            else if (plantsPanel.LightIntensity == 1)
            {
                return "Medium";
            }
            else if (plantsPanel.LightIntensity == 2)
            {
                return "High";
            }
            else
            {
                return String.Empty;
            }
        }

        public float getTemperaturePlants(PlantsPanel plantsPanel, string measurementUnit)
        {
            float temperature;

            if (measurementUnit == "C")
            {
                temperature = plantsPanel.ActualTemperature;

                return temperature;
            }
            else if(measurementUnit == "F")
            {
                temperature = (plantsPanel.ActualTemperature * 9) / 5 + 32;

                return temperature;
            }
            else
            {
                return 0;
            }
        }

        public float getHumidityPlants(PlantsPanel plantsPanel)
        {
            float humidity = plantsPanel.ActualHumidity;

            return humidity;
        }

        public void setFieldNum(PlantsPanel plantsPanel, int fieldNum)
        {
            plantsPanel.FieldNum = fieldNum;
        }

        public void setWaterPlants(PlantsPanel plantsPanel, float DesiredwaterLt)
        {
            plantsPanel.WaterConsumption = DesiredwaterLt;
        }

        public void setOxygenPlants(PlantsPanel plantsPanel, float DesiredOxygen)
        {
            plantsPanel.OxygenConsumption = DesiredOxygen;
        }

        public void setPlantPowerConsumption(PlantsPanel plantsPanel, int powerLevel)
        {
            plantsPanel.PowerConsumption = powerLevel;
        }

        public void setLightIntensityPlants(PlantsPanel plantsPanel, int DesiredlightIntensity)
        {
            plantsPanel.LightIntensity = DesiredlightIntensity;
        }

        public void setTemperaturePlants(PlantsPanel plantsPanel, float Desiredtemperature)
        {
            plantsPanel.ActualTemperature = Desiredtemperature;
        }

        public void setHumidityPlants(PlantsPanel plantsPanel, float Desiredhumidity)
        {
            plantsPanel.ActualHumidity = Desiredhumidity;
        }

        public void createFileHumidity(float DesiredHumidity)
        {
            if (File.Exists("FileHumidity.txt"))
            {
                File.Delete("FileHumidity.txt");
            }

            Random random = new Random();

            int NValues = 200;

            float max = DesiredHumidity + 2;

            float min = DesiredHumidity - 2;

            for (int i = 0; i < NValues; i++)
            {
                double val = random.NextDouble() * (max - min) + min;

                File.AppendAllText("FileHumidity.txt", val.ToString("0.00") + Environment.NewLine);
            }
        }
    }
}