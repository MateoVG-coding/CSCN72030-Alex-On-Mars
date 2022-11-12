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

        public void changeUseLevel(int module)
        {
            // incomplete
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

        private void readEnergyUsed()
        {
            // incomplete
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

        string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Ibapo\OneDrive\Escritorio\School\Fall 2022\Software Development\Project\PowerPanel\SolarEnergy.txt");

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

        public void readSolarEnergy()
        {
            int numberLines = lines.GetLength(0);
            Random rnd = new Random();
            int num = rnd.Next(0, numberLines);

            float solarEnergy = Single.Parse(lines[num]);

            setSolarEnergy(solarEnergy);
        }
    }
}