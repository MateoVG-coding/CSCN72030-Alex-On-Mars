using System.Reflection.Emit;
using System;
using System.IO;


namespace PowerPanel
{
    public class Energy
    {
        private float energy_watts;
        private bool energy_available;
        private float max_energy;
        private int energy_percentage;
        SolarPanel[] solar_Panel;


        public Energy()
        {
            energy_watts = 0;
            max_energy = 0;
            energy_percentage = 0;
            energy_available = true;
            this.solar_Panel = new SolarPanel[10];
        }

        public Energy(float energyWatts, float maxEnergy, int energyPercentage, bool energyAvailable)
        {
            this.energy_watts = energyWatts;
            this.max_energy = maxEnergy;
            this.energy_percentage = energyPercentage;
            this.energy_available = energyAvailable;
            this.solar_Panel = new SolarPanel[10];
        }

        public void calculateEnergyPercentage(float energyWatts, float maxEnergy)
        {
            int newEnergyPercentage;

            newEnergyPercentage = Convert.ToInt32((energyWatts * 100) / maxEnergy);

            setEnergyPercentage(newEnergyPercentage);
        }

        public void checkEnergy()
        {
            if (energy_watts > 0)
                energy_available = true;
            else
                energy_available = false;
        }

        public void setEnergyAvailable(bool energyAvailable)
        {
            this.energy_available = energyAvailable;
        }

        public bool getEnergyAvailable()
        {
            return energy_available;
        }

        public int changeUseLevel(int useLevel)
        {
            if (useLevel == 1)
            {
                return 1;
            }
            else if (useLevel == 2)
            {
                return 2;
            }
            else if (useLevel == 3)
            {
                return 3;
            }
            else
                return -1;
        }

        public float getTotalEnergy()
        {
            return energy_watts;
        }

        public float getMaxEnergy()
        {
            return max_energy;
        }

        public int getEnergyPercentage()
        {
            return energy_percentage;
        }

        public void setTotalEnergy(float energyWatts)
        {
            this.energy_watts = energyWatts;
        }

        public void setMaxEnergy(float maxEnergy)
        {
            this.max_energy = maxEnergy;
        }

        public void setEnergyPercentage(int energyPercentage)
        {
            this.energy_percentage = energyPercentage;
        }
    }

    public class UseLevel
    {
        private float energy_used;
        private string[] lines1 = new string[14];
        private string[] lines2 = new string[14];
        private string[] lines3 = new string[14];

        public void readEnergyUsed(int useLevel)
        {
            StreamReader reader;
            float energyUsed;

            if (useLevel == 1)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "UseLevel1.txt");
                reader = new StreamReader(path);
                string line = reader.ReadLine();
                int i = 0;

                while (i < 3 && line == lines1[i])
                {
                    line = reader.ReadLine();
                    i++;
                }

                if (line != null)
                {
                    lines1[i] = line;
                    energyUsed = float.Parse(line);
                    setEnergyUsed(energyUsed);
                }
                else
                {
                    reader.Close();
                    Array.Clear(lines1, 0, lines1.Length);
                }

                reader.Close();
            }
            else if (useLevel == 2)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "UseLevel2.txt");
                reader = new StreamReader(path);
                string line = reader.ReadLine();
                int i = 0;

                while (i < 3 && line == lines2[i])
                {
                    line = reader.ReadLine();
                    i++;
                }

                if (line != null)
                {
                    lines2[i] = line;
                    energyUsed = float.Parse(line);
                    setEnergyUsed(energyUsed);
                }
                else
                {
                    reader.Close();
                    Array.Clear(lines2, 0, lines2.Length);
                }

                reader.Close();
            }
            else if (useLevel == 3)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "UseLevel3.txt");
                reader = new StreamReader(path);
                string line = reader.ReadLine();
                int i = 0;

                while (i < 3 && line == lines3[i])
                {
                    line = reader.ReadLine();
                    i++;
                }

                if (line != null)
                {
                    lines3[i] = line;
                    energyUsed = float.Parse(line);
                    setEnergyUsed(energyUsed);
                }
                else
                {
                    reader.Close();
                    Array.Clear(lines3, 0, lines3.Length);
                }

                reader.Close();
            }
            else
                return;
        }

        private void setEnergyUsed(float energyUsed)
        {
            this.energy_used = energyUsed;
        }
                
        public float getEnergyUsed()
        {
            return energy_used;
        }

        public void updateTotalEnergy(Energy energy, float energyWatts, float energyUsed)
        {
            float newEnergy = energyWatts - energyUsed;

            energy.setTotalEnergy(newEnergy);
        }
    }

    public class SolarPanel
    {
        private float solar_energy;
        private bool panel_state;
        private string[] lines = new string[14];

        public float getSolarEnergy()
        {
            return solar_energy;
        }

        public bool getPanelState()
        {
            return panel_state;
        }

        private void setSolarEnergy(float solarEnergy)
        {
            this.solar_energy = solarEnergy;
        }

        private void setPanelState(bool panelState)
        {
            this.panel_state = panelState;
        }

        public void changePanelState(int state)
        {
            if (state == 1)
                setPanelState(true);
            else if (state == 2)
                setPanelState(false);
            else
                return;
        }

        public int readSolarEnergy()
        {
            StreamReader reader;
            var dir = Directory.GetCurrentDirectory();
            string fileName = "SolarEnergy.txt";
            var path = Path.Combine(dir, fileName);
            reader = new StreamReader(path);

            string line = reader.ReadLine();
            int i = 0;
            float solarEnergy = 0;
            float newSolar = 0;

            while (i < 3 && line == lines[i])
            {
                line = reader.ReadLine();
                i++;
            }

            if (line != null)
            {
                lines[i] = line;
                solarEnergy = float.Parse(line);
                newSolar = solarEnergy + getSolarEnergy();
                setSolarEnergy(newSolar);
            }
            else
            {
                reader.Close();
                Array.Clear(lines, 0, lines.Length);
                return 1;
            }

            reader.Close();


            return 0;
        }
    }
}