using EssentialsPanel;
using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO;

namespace PlantsPanel
{
    public class PlantsPanel
    {
        public int FieldNum { get; private set; }
        public double WaterConsumption { get; private set; }
        public double OxygenConsumption { get; private set; }
        public int PowerConsumption { get; private set; }
        public int LightIntensity { get; private set; }
        public double ActualTemperature { get; private set; }
        public double ActualHumidity { get; private set; }

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

        public PlantsPanel(int fieldNum, double waterLt, double temperatureCelsius, int lightIntensity, double humidity, double oxygenConsumption, int powerConsumption)
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

        public double getWaterPlants(PlantsPanel plantsPanel)
        {
            double waterConsumption = plantsPanel.WaterConsumption;

            return waterConsumption;
        }

        public double getOxygenPlants(PlantsPanel plantsPanel)
        {
            double oxygen = plantsPanel.OxygenConsumption;

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

        public double getTemperaturePlants(PlantsPanel plantsPanel, string measurementUnit)
        {
            double temperature;

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

        public double getHumidityPlants(PlantsPanel plantsPanel)
        {
            double humidity = plantsPanel.ActualHumidity;

            return humidity;
        }

        public void setFieldNum(PlantsPanel plantsPanel, int fieldNum)
        {
            plantsPanel.FieldNum = fieldNum;
        }

        public int setWaterPlants(PlantsPanel plantsPanel, double DesiredwaterLt, EssentialsPanel.EssentialsPanel essentialsPanel)
        {
            
            if(essentialsPanel.setWaterLevel(DesiredwaterLt) == 0)
            {
                plantsPanel.WaterConsumption = DesiredwaterLt;
                return 0;
            }

            return 1;
        }

        public void setOxygenPlants(PlantsPanel plantsPanel, EssentialsPanel.EssentialsPanel essentialsPanel)
        {
            plantsPanel.OxygenConsumption = essentialsPanel.getOxygenLevel();
        }

        public void setPlantPowerConsumption(PlantsPanel plantsPanel, int powerLevel)
        {
            plantsPanel.PowerConsumption = powerLevel;
        }

        public void setLightIntensityPlants(PlantsPanel plantsPanel, int DesiredlightIntensity)
        {
            plantsPanel.LightIntensity = DesiredlightIntensity;
        }

        public void setTemperaturePlants(PlantsPanel plantsPanel, double Desiredtemperature)
        {
            plantsPanel.ActualTemperature = Desiredtemperature;
        }

        public void setHumidityPlants(PlantsPanel plantsPanel, double Desiredhumidity)
        {
            plantsPanel.ActualHumidity = Desiredhumidity;        
        }

        public void createFileHumidity(PlantsPanel plantsPanel)
        {
            if (File.Exists("FileHumidity.txt"))
            {
                File.Delete("FileHumidity.txt");
            }

            double DesiredHumidity = plantsPanel.ActualHumidity;

            Random random = new Random();

            int NValues = 5000;

            double max = DesiredHumidity + 2;

            double min = DesiredHumidity - 2;

            for (int i = 0; i < NValues; i++)
            {
                double val = random.NextDouble() * (max - min) + min;

                File.AppendAllText("FileHumidity.txt", val.ToString("0.00") + Environment.NewLine);
            }
        }

        public void createFileTemperature(PlantsPanel plantsPanel)
        {
            if (File.Exists("FileTemperature.txt"))
            {
                File.Delete("FileTemperature.txt");
            }

            Random random = new Random();

            double DesiredTemperature = plantsPanel.ActualTemperature;

            int NValues = 5000;

            double max = DesiredTemperature + 0.2;

            double min = DesiredTemperature - 0.2;

            for (int i = 0; i < NValues; i++)
            {
                double val = random.NextDouble() * (max - min) + min;

                File.AppendAllText("FileTemperature.txt", val.ToString("0.0") + Environment.NewLine);
            }
        }

        public string readFileTemperature(string measurementUnit)
        {
            if (File.Exists("FileHumidity.txt"))
            {
                int counter = 0;

                foreach (string line in System.IO.File.ReadLines("FileHumidity.txt"))
                {
                    if(measurementUnit == "F")
                    {
                        double temp = Convert.ToDouble(line);
                        temp = (temp - 32) * 5 / 9;
                        return (Convert.ToString(temp));
                    }
                    else
                    {
                        counter++;
                        return (line);
                    }
                }
            }
            return String.Empty;
        }

        public string readFileHumidity()
        {
            if (File.Exists("FileHumidity.txt"))
            {
                int counter = 0;

                foreach (string line in System.IO.File.ReadLines("FileHumidity.txt"))
                {
                    counter++;
                    return (line);
                }
            }

            return String.Empty;
        }
    }
}