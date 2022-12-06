using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using ComfortPanel;
using EssentialsPanel;
using PlantsPanel;
using PowerPanel;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Media;

namespace HMI
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource ctsOxygen;

        private CancellationTokenSource ctsTemperatureHome;

        private CancellationTokenSource ctsHumidityHome;

        private CancellationTokenSource ctsTemperature;

        private CancellationTokenSource ctsHumidity;

        private CancellationTokenSource ctsUseLevel;

        private CancellationTokenSource ctsEnergy;

        EssentialsPanel.EssentialsPanel essentialsPanel = new EssentialsPanel.EssentialsPanel();

        EssentialsPanel.powerConsumed essentialPower = new EssentialsPanel.powerConsumed(1);

        PlantsPanel.PlantsPanel plantsPanel = new PlantsPanel.PlantsPanel();

        ComfortPanel.Temperature temperatureHome = new ComfortPanel.Temperature();

        ComfortPanel.Humidity humidityHome = new ComfortPanel.Humidity();

        ComfortPanel.powerConsumed comfortPower = new ComfortPanel.powerConsumed(1);

        Energy power = new Energy();
        UseLevel uselevel = new UseLevel();

        Bitmap imgTurnOFF = Properties.Resources.switch_hoa_hand_OFF;
        Bitmap imgTurnON = Properties.Resources.switch_hoa_auto_ON;
        Bitmap lowEnergy = Properties.Resources.electricbolt_low;
        Bitmap MedEnergy = Properties.Resources.electricbolt_med;
        Bitmap HighEnergy = Properties.Resources.electricbolt_high;

        int start = 0;

        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            label9_Click(null, null);
            label8_Click(null, null);
            roundButtonTemperatureHome_Click(null, null);
            roundButtonHumidityHome_Click(null, null);
            roundButtonHumidityPlants_Click(null, null);
            roundButton4_Click(null, null);
            roundButtonLightIntensity_Click(null, null);
            roundButtonWaterPlants_Click(null, null);
            pictureBox46_Click(null, null);
            pictureBox45_Click_1(null, null);
            pictureBox44_Click_1(null, null);
            pictureBox47_Click(null, null);
            label14.Text = "Medium";

            this.pictureBox44.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox44_Click_1);
            this.pictureBox45.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox45_Click_1);
            this.pictureBox46.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox46_Click);
            this.pictureBox47.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox47_Click);

            SoundPlayer simpleSound = new SoundPlayer("intro.wav");
            simpleSound.Play();

            start++;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            double waterLevel = essentialsPanel.getWaterLevel();
            HomeWater.Text = Convert.ToString(waterLevel) + "L" + 't' + 's';
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private async void label8_Click(object sender, EventArgs e)
        {         
        
            if (ctsOxygen != null)
            {
                ctsOxygen.Cancel();
            }
            // Create a CTS for this request.
            ctsOxygen = new CancellationTokenSource();

            double oxygenLevel = essentialsPanel.getOxygenLevel();

            essentialsPanel.setOxygenLevel(oxygenLevel);

            Cursor.Current = Cursors.WaitCursor;

            essentialsPanel.createFileOxygen(essentialsPanel);
           
            Cursor.Current = Cursors.Default;

            try
            {
                await readFileOxygen(ctsOxygen.Token, 4000);
            }
            catch (OperationCanceledException)
            {
            }
        }

        private async Task readFileOxygen(CancellationToken token, int time)
        {
            string[] lines = File.ReadAllLines("FileOxygen.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                await Task.Delay(time, token);
                HomeOxygen.Text = lines[i] + '%' ;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private async void roundButton4_Click(object sender, EventArgs e)
        {
            if(start != 0)
            {
                SoundPlayer simpleSound = new SoundPlayer("pressButton.wav");
                simpleSound.Play();
            }

            if (ctsTemperature != null)
            {
                ctsTemperature.Cancel();
            }
            // Create a CTS for this request.
            ctsTemperature = new CancellationTokenSource();

            double desiredTemperature = Convert.ToDouble(numericUpDownTemperaturePlants.Text);

            plantsPanel.setTemperaturePlants(plantsPanel, desiredTemperature);

            Cursor.Current = Cursors.WaitCursor;

            plantsPanel.createFileTemperature(plantsPanel);

            Cursor.Current = Cursors.Default;

            try
            {
                await readFileTemperature(ctsTemperature.Token, 4000);
            }
            catch (OperationCanceledException)
            {
            }
        }

        private async Task readFileTemperature(CancellationToken token, int time)
        {
            string[] lines = File.ReadAllLines("FileTemperature.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                await Task.Delay(time, token);

                if(radioButton2.Checked == true)
                {
                    double fTemp = (Convert.ToDouble(lines[i]) * 9) / 5 + 32;
                    label11.Text = fTemp.ToString("0.0");
        }
                else
                {
                    label11.Text = lines[i];
                }
            }
        }

        private async void roundButtonHumidityPlants_Click(object sender, EventArgs e)
        {
            if (start != 0)
            {
                SoundPlayer simpleSound = new SoundPlayer("pressButton.wav");
                simpleSound.Play();
            }

            if (ctsHumidity != null)
            {
                ctsHumidity.Cancel();
            }
            // Create a CTS for this request.
            ctsHumidity = new CancellationTokenSource();

            double desiredHumdity = Convert.ToDouble(numericUpDownHumidityPlants.Text);

            plantsPanel.setHumidityPlants(plantsPanel, desiredHumdity);

            Cursor.Current = Cursors.WaitCursor;

            plantsPanel.createFileHumidity(plantsPanel);

            Cursor.Current = Cursors.Default;

            try
            {
                await readFileHumidity(ctsHumidity.Token, 2000);
            }
            catch (OperationCanceledException)
            {
            }
        }

        private async Task readFileHumidity(CancellationToken token, int time)
        {
            string[] lines = File.ReadAllLines("FileHumidity.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                await Task.Delay(time, token);
                label13.Text = lines[i] + '%';
            }
        }

        private void roundButtonWaterPlants_Click(object sender, EventArgs e)
        {
            if (start != 0)
            {
                SoundPlayer simpleSound = new SoundPlayer("pressButton.wav");
                simpleSound.Play();
            }

            double desiredWater = Convert.ToDouble(numericUpDownWaterPlants.Value);

            plantsPanel.setWaterPlants(plantsPanel, desiredWater, essentialsPanel);

            label12.Text = Convert.ToString(desiredWater) + 'L' + 't' + 's';

            label9_Click(null, null);
        }

        private void roundButtonLightIntensity_Click(object sender, EventArgs e)
        {
            if (start != 0)
            {
                SoundPlayer simpleSound = new SoundPlayer("pressButton.wav");
                simpleSound.Play();
            }

            string desiredLightIntensity = comboBoxLightIntensity.Text;

            if (desiredLightIntensity == "High")
            {
                plantsPanel.setLightIntensityPlants(plantsPanel, 2);
            }
            else if (desiredLightIntensity == "Medium")
            {
                plantsPanel.setLightIntensityPlants(plantsPanel, 1);
            }
            else
            {
                plantsPanel.setLightIntensityPlants(plantsPanel, 0);
            }

            label14.Text = desiredLightIntensity;
        }

        private void WaitNSeconds(int seconds)
        {
            if (seconds < 1) return;
            DateTime _desired = DateTime.Now.AddSeconds(seconds);
            while (DateTime.Now < _desired)
            {
                System.Windows.Forms.Application.DoEvents();
            }
        }
        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void process1_Exited(object sender, EventArgs e)
        {

        }

        private bool checkPanels()
        {
            int panelsOn = 0;

            for (int i = 0; i < 4; i++)
            {
                if (power.solar_Panel[i].getPanelState() == true)
                    panelsOn++;
            }

            if (panelsOn <= 1)
                return false;
            else
                return true;
        }

        private void newTotalEnergy()
        {
            float[] energy = new float[4];
            float totalEnergy = 0;
            for (int i = 0; i < 4; i++)
            {
                if (power.solar_Panel[i].getPanelState() == true)
                {
                    if (power.solar_Panel[i].readSolarEnergy() == 0)
                    {
                        energy[i] = energy[i] + power.solar_Panel[i].getSolarEnergy();
                    }
                }
            }

            totalEnergy = power.getTotalEnergy() + (energy[0] + energy[1] + energy[2] + energy[3]);

            if (totalEnergy > power.getMaxEnergy())
            {
                float x = totalEnergy - power.getMaxEnergy();
                totalEnergy = totalEnergy - x;
            }

            power.setTotalEnergy(totalEnergy);
            power.calculateEnergyPercentage(totalEnergy, power.getMaxEnergy());

            label26.Text = Convert.ToString(power.getEnergyPercentage()) + '%';
        }

        private async void pictureBox46_Click(object sender, EventArgs e)
        {
            power.checkEnergy();

            ctsEnergy = new CancellationTokenSource();

            if (ctsEnergy == null)
            {
                ctsEnergy.Cancel();
            }

            if (sender != null)
            {
                if (power.solar_Panel[2].getPanelState() == true)
                {
                    if (checkPanels() == false)
                    {
                        DialogResult ex = MessageBox.Show("Unable to turn panel OFF. At least one panel must be ON.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    DialogResult dr = MessageBox.Show("Do you want to turn this panel OFF?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        power.solar_Panel[2].changePanelState(2);
                        pictureBox46.Image = imgTurnOFF;
                    }
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Do you want to turn this panel ON?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        power.solar_Panel[2].changePanelState(1);
                        pictureBox46.Image = imgTurnON;
                    }
                }
            }

            

            if (power.solar_Panel[2].getPanelState() == true)
            {
                for (int i = 0; i < 15; i++)
                {
                    if (power.getEnergyPercentage() < 100)
                    {
                        await Task.Delay(4000, ctsEnergy.Token);
                        newTotalEnergy();
                    }
                    else
                    {
                        await Task.Delay(10000, ctsEnergy.Token);
                        continue;
                    }

                    if (i == 14)
                        i = 0;
                }
            }
        }

        private async void pictureBox47_Click(object sender, EventArgs e)
        {
            power.checkEnergy();

            ctsEnergy = new CancellationTokenSource();

            if (ctsEnergy == null)
            {
                ctsEnergy.Cancel();
            }

            if (sender != null)
            {
                if (power.solar_Panel[3].getPanelState() == true)
                {
                    if (checkPanels() == false)
                    {
                        DialogResult ex = MessageBox.Show("Unable to turn panel OFF. At least one panel must be ON.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    DialogResult dr = MessageBox.Show("Do you want to turn this panel OFF?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        power.solar_Panel[3].changePanelState(2);
                        pictureBox47.Image = imgTurnOFF;
                    }
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Do you want to turn this panel ON?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        power.solar_Panel[3].changePanelState(1);
                        pictureBox47.Image = imgTurnON;
                    }
                }
            }

            if (power.solar_Panel[3].getPanelState() == true)
            {
                for (int i = 0; i < 15; i++)
                {
                    if (power.getEnergyPercentage() < 100)
                    {
                        await Task.Delay(4000, ctsEnergy.Token);
                        newTotalEnergy();
                    }
                    else
                    {
                        await Task.Delay(10000, ctsEnergy.Token);
                        continue;
                    }

                    if (i == 14)
                        i = 0;
                }
            }
        }

        private void pictureBox40_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox43_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox41_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox42_Click(object sender, EventArgs e)
        {
            
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private async void roundButton7_Click(object sender, EventArgs e)
        {
            if (start != 0)
            {
                SoundPlayer simpleSound = new SoundPlayer("pressButton.wav");
                simpleSound.Play();
            }

            //comfort button energy

            ctsUseLevel = new CancellationTokenSource();

            if (ctsUseLevel == null)
            {
                ctsUseLevel.Cancel();
            }

            string level = comboBox1.Text;

            if (level == "Low")
            {
                comfortPower.setPower(1);

                pictureBox49.Image = lowEnergy;

                for (int i = 0; i < 15; i++)
                {
                    uselevel.readEnergyUsed(comfortPower.getPower());
                    uselevel.updateTotalEnergy(power, power.getTotalEnergy(), uselevel.getEnergyUsed());
                    power.checkEnergy();

                    if (power.getEnergyAvailable() == false)
                    {
                        power.setTotalEnergy(0);
                    }

                    power.calculateEnergyPercentage(power.getTotalEnergy(), power.getMaxEnergy());
                    await Task.Delay(8000, ctsUseLevel.Token);
                    label26.Text = Convert.ToString(power.getEnergyPercentage()) + '%';

                    if (i == 14)
                        i = 0;
                }
            }
            else if (level == "Medium")
            {
                comfortPower.setPower(2);

                pictureBox49.Image = MedEnergy;

                for (int i = 0; i < 15; i++)
                {
                    uselevel.readEnergyUsed(comfortPower.getPower());
                    uselevel.updateTotalEnergy(power, power.getTotalEnergy(), uselevel.getEnergyUsed());
                    power.checkEnergy();

                    if (power.getEnergyAvailable() == false)
                    {
                        power.setTotalEnergy(0);
                    }

                    power.calculateEnergyPercentage(power.getTotalEnergy(), power.getMaxEnergy());
                    await Task.Delay(8000, ctsUseLevel.Token);
                    label26.Text = Convert.ToString(power.getEnergyPercentage()) + '%';

                    if (i == 14)
                        i = 0;
                }
            }
            else if (level == "High")
            {
                comfortPower.setPower(3);

                pictureBox49.Image = HighEnergy;

                for (int i = 0; i < 15; i++)
                {
                    uselevel.readEnergyUsed(comfortPower.getPower());
                    uselevel.updateTotalEnergy(power, power.getTotalEnergy(), uselevel.getEnergyUsed());
                    power.checkEnergy();

                    if (power.getEnergyAvailable() == false)
                    {
                        power.setTotalEnergy(0);
                    }

                    power.calculateEnergyPercentage(power.getTotalEnergy(), power.getMaxEnergy());
                    await Task.Delay(8000, ctsUseLevel.Token);
                    label26.Text = Convert.ToString(power.getEnergyPercentage()) + '%';

                    if (i == 14)
                        i = 0;
                }
            }
            else
                return;
        }

        private async void roundButton8_Click(object sender, EventArgs e)
        {
            if (start != 0)
            {
                SoundPlayer simpleSound = new SoundPlayer("pressButton.wav");
                simpleSound.Play();
            }

            //Essentials button energy

            ctsUseLevel = new CancellationTokenSource();

            if (ctsUseLevel == null)
            {
                ctsUseLevel.Cancel();
            }

            string level = comboBox2.Text;

            if (level == "Low")
            {
                essentialPower.setPower(1);

                pictureBox48.Image = lowEnergy;

                for (int i = 0; i < 15; i++)
                {
                    uselevel.readEnergyUsed(essentialPower.getPower());
                    uselevel.updateTotalEnergy(power, power.getTotalEnergy(), uselevel.getEnergyUsed());
                    power.checkEnergy();

                    if (power.getEnergyAvailable() == false)
                    {
                        power.setTotalEnergy(0);
                    }

                    power.calculateEnergyPercentage(power.getTotalEnergy(), power.getMaxEnergy());
                    await Task.Delay(8000, ctsUseLevel.Token);
                    label26.Text = Convert.ToString(power.getEnergyPercentage()) + '%';

                    if (i == 14)
                        i = 0;
                }
            }
            else if (level == "Medium")
            {
                essentialPower.setPower(2);

                pictureBox48.Image = MedEnergy;

                for (int i = 0; i < 15; i++)
                {
                    uselevel.readEnergyUsed(essentialPower.getPower());
                    uselevel.updateTotalEnergy(power, power.getTotalEnergy(), uselevel.getEnergyUsed());
                    power.checkEnergy();

                    if (power.getEnergyAvailable() == false)
                    {
                        power.setTotalEnergy(0);
                    }

                    power.calculateEnergyPercentage(power.getTotalEnergy(), power.getMaxEnergy());
                    await Task.Delay(8000, ctsUseLevel.Token);
                    label26.Text = Convert.ToString(power.getEnergyPercentage()) + '%';

                    if (i == 14)
                        i = 0;
                }
            }
            else if (level == "High")
            {
                essentialPower.setPower(3);

                pictureBox48.Image = HighEnergy;

                for (int i = 0; i < 15; i++)
                {
                    uselevel.readEnergyUsed(essentialPower.getPower());
                    uselevel.updateTotalEnergy(power, power.getTotalEnergy(), uselevel.getEnergyUsed());
                    power.checkEnergy();

                    if (power.getEnergyAvailable() == false)
                    {
                        power.setTotalEnergy(0);
                    }

                    power.calculateEnergyPercentage(power.getTotalEnergy(), power.getMaxEnergy());
                    await Task.Delay(8000, ctsUseLevel.Token);
                    label26.Text = Convert.ToString(power.getEnergyPercentage()) + '%';

                    if (i == 14)
                        i = 0;
                }
            }
            else
                return;
        }

        private async void roundButton9_Click(object sender, EventArgs e)
        {
            if (start != 0)
            {
                SoundPlayer simpleSound = new SoundPlayer("pressButton.wav");
                simpleSound.Play();
            }
            //Plants button energy

            ctsUseLevel = new CancellationTokenSource();

            if (ctsUseLevel == null)
            {
                ctsUseLevel.Cancel();
            }

            string level = comboBox3.Text;

            if (level == "Low")
            {
                essentialPower.setPower(1);

                pictureBox50.Image = lowEnergy;

                for (int i = 0; i < 15; i++)
                {
                    uselevel.readEnergyUsed(essentialPower.getPower());
                    uselevel.updateTotalEnergy(power, power.getTotalEnergy(), uselevel.getEnergyUsed());
                    power.checkEnergy();

                    if (power.getEnergyAvailable() == false)
                    {
                        power.setTotalEnergy(0);
                    }

                    power.calculateEnergyPercentage(power.getTotalEnergy(), power.getMaxEnergy());
                    await Task.Delay(8000, ctsUseLevel.Token);
                    label26.Text = Convert.ToString(power.getEnergyPercentage()) + '%';

                    if (i == 14)
                        i = 0;
                }
            }
            else if (level == "Medium")
            {
                essentialPower.setPower(2);

                pictureBox50.Image = MedEnergy;

                for (int i = 0; i < 15; i++)
                {
                    uselevel.readEnergyUsed(essentialPower.getPower());
                    uselevel.updateTotalEnergy(power, power.getTotalEnergy(), uselevel.getEnergyUsed());
                    power.checkEnergy();

                    if (power.getEnergyAvailable() == false)
                    {
                        power.setTotalEnergy(0);
                    }

                    power.calculateEnergyPercentage(power.getTotalEnergy(), power.getMaxEnergy());
                    await Task.Delay(8000, ctsUseLevel.Token); 
                    label26.Text = Convert.ToString(power.getEnergyPercentage()) + '%';

                    if (i == 14)
                        i = 0;
                }
            }
            else if (level == "High")
            {
                essentialPower.setPower(3);

                pictureBox50.Image = HighEnergy;

                for (int i = 0; i < 15; i++)
                {
                    uselevel.readEnergyUsed(essentialPower.getPower());
                    uselevel.updateTotalEnergy(power, power.getTotalEnergy(), uselevel.getEnergyUsed());
                    power.checkEnergy();

                    if (power.getEnergyAvailable() == false)
                    {
                        power.setTotalEnergy(0);
                    }

                    power.calculateEnergyPercentage(power.getTotalEnergy(), power.getMaxEnergy());
                    await Task.Delay(2000, ctsUseLevel.Token);
                    label26.Text = Convert.ToString(power.getEnergyPercentage()) + '%';

                    if (i == 14)
                        i = 0;
                }
            }
            else
                return;
        }

        private async void roundButtonTemperatureHome_Click(object sender, EventArgs e)
        {
            if (start != 0)
            {
                SoundPlayer simpleSound = new SoundPlayer("pressButton.wav");
                simpleSound.Play();
            }

            if (ctsTemperatureHome != null)
            {
                ctsTemperatureHome.Cancel();
            }
            // Create a CTS for this request.
            ctsTemperatureHome = new CancellationTokenSource();

            double desiredTemperatureHome = Convert.ToDouble(numericUpDownTemperatureHome.Text);

            temperatureHome.setTemperature(temperatureHome, desiredTemperatureHome);

            Cursor.Current = Cursors.WaitCursor;

            temperatureHome.createFileTemperature(temperatureHome);

            Cursor.Current = Cursors.Default;

            try
            {
                await readFileTemperatureHome(ctsTemperatureHome.Token, 6500);
            }
            catch (OperationCanceledException)
            {
            }
        }

        private async Task readFileTemperatureHome(CancellationToken token, int time)
        {
            string[] lines = File.ReadAllLines("FileComfortTemperature.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                await Task.Delay(time, token);

                if (radioButton3.Checked == true)
                {
                    double fTemp = (Convert.ToDouble(lines[i]) * 9) / 5 + 32;
                    label22.Text = fTemp.ToString("0.0");
                }
                else
                {
                    label22.Text = lines[i];
                }
            }
        }

        private async void roundButtonHumidityHome_Click(object sender, EventArgs e)
        {
            if (start != 0)
            {
                SoundPlayer simpleSound = new SoundPlayer("pressButton.wav");
                simpleSound.Play();
            }

            if (ctsHumidityHome != null)
            {
                ctsHumidityHome.Cancel();
            }
            // Create a CTS for this request.
            ctsHumidityHome = new CancellationTokenSource();

            double desiredHumdityHome = Convert.ToDouble(numericUpDownHumidityHome.Text);

            humidityHome.setHumidity(humidityHome, desiredHumdityHome);

            Cursor.Current = Cursors.WaitCursor;

            humidityHome.createFileHumidity(humidityHome);

            Cursor.Current = Cursors.Default;

            try
            {
                await readFileHumidityHome(ctsHumidityHome.Token, 3000);
            }
            catch (OperationCanceledException)
            {
            }
        }

        private async Task readFileHumidityHome(CancellationToken token, int time)
        {
            string[] lines = File.ReadAllLines("FileComfortHumidity.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                await Task.Delay(time, token);
                label24.Text = lines[i] + '%';
            }
        }

        private async void pictureBox44_Click_1(object sender, EventArgs e)
        {
            power.checkEnergy();

            ctsEnergy = new CancellationTokenSource();

            if (ctsEnergy == null)
            {
                ctsEnergy.Cancel();
            }

            if (sender != null)
            {
                if (power.solar_Panel[0].getPanelState() == true)
                {
                    if (checkPanels() == false)
                    {
                        DialogResult ex = MessageBox.Show("Unable to turn panel OFF. At least one panel must be ON.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    DialogResult dr = MessageBox.Show("Do you want to turn this panel OFF?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        power.solar_Panel[0].changePanelState(2);
                        pictureBox44.Image = imgTurnOFF;
                    }
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Do you want to turn this panel ON?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        power.solar_Panel[0].changePanelState(1);
                        pictureBox44.Image = imgTurnON;
                    }
                }
            }

            if (power.solar_Panel[0].getPanelState() == true)
            {
                for (int i = 0; i < 15; i++)
                {
                    if (power.getEnergyPercentage() < 100)
                    {
                        await Task.Delay(4000, ctsEnergy.Token);
                        newTotalEnergy();
                    }
                    else
                    {
                        await Task.Delay(10000, ctsEnergy.Token);
                        continue;
                    }

                    if (i == 14)
                        i = 0;
                }
            }
        }

        private async void pictureBox45_Click_1(object sender, EventArgs e)
        {
            power.checkEnergy();

            ctsEnergy = new CancellationTokenSource();

            if (ctsEnergy == null)
            {
                ctsEnergy.Cancel();
            }

            if (sender != null)
            {
                if (power.solar_Panel[1].getPanelState() == true)
                {
                    if (checkPanels() == false)
                    {
                        DialogResult ex = MessageBox.Show("Unable to turn panel OFF. At least one panel must be ON.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    DialogResult dr = MessageBox.Show("Do you want to turn this panel OFF?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        power.solar_Panel[1].changePanelState(2);
                        pictureBox45.Image = imgTurnOFF;
                    }
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Do you want to turn this panel ON?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        power.solar_Panel[1].changePanelState(1);
                        pictureBox45.Image = imgTurnON;
                    }
                }
            }

            if (power.solar_Panel[1].getPanelState() == true)
            {
                for (int i = 0; i < 15; i++)
                {
                    if (power.getEnergyPercentage() < 100)
                    {
                        await Task.Delay(4000, ctsEnergy.Token);
                        newTotalEnergy();
                    }
                    else
                    {
                        await Task.Delay(4000, ctsEnergy.Token);
                        continue;
                    }

                    if (i == 14)
                        i = 0;
                }
            }
        }
    }

    public class RoundButton : Button
    {
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            GraphicsPath grPath = new GraphicsPath();
            grPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(grPath);
            base.OnPaint(e);
        }
    }
}