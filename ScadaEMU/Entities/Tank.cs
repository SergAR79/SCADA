using ScadaBLL.Models;
using ScadaCore.Entities;
using ScadaEMU.Entities.Pumps;
using ScadaEMU.Entities.Sensors;
using ScadaEMU.Entities.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ScadaEMU.Entities
{
    public class Tank:TankModel
    {
        public List<TheLevelSensor> Sensors { get; set; }
        public ThePump Pump { get; set; }
        public TheValve Valve { get; set;}

        private CheckBox checkAlarm;
        private CheckBox checkAlarmbackup;
        private CheckBox checkThreshold;
        private CheckBox checkHighlevel;
        private System.Windows.Forms.Timer timerTank;
        private PictureBox picWaste;
        private PictureBox picPump;
        private PictureBox picTank;
        private Label labelTank;
        private Button buttonPump;
        private TextBox textEcho;


        public Tank(Guid tankId, CheckBox checkAlarm, CheckBox checkAlarmbackup, 
            CheckBox checkThreshold, CheckBox checkHighlevel, System.Windows.Forms.Timer timerTank, 
            PictureBox picWaste, PictureBox picPump, PictureBox picTank,
            Label labeltank, Button buttonPump, TextBox textEcho)
        {
            this.checkAlarm = checkAlarm;
            this.checkAlarmbackup = checkAlarmbackup;
            this.checkThreshold = checkThreshold;
            this.checkHighlevel = checkHighlevel;
            this.timerTank = timerTank;
            this.picWaste = picWaste;
            this.picTank = picTank;
            this.picPump = picPump;
            this.labelTank = labeltank;
            this.buttonPump = buttonPump;
            this.textEcho = textEcho;
        }

        public void echo(String msg)
        {
            textEcho.AppendText(Environment.NewLine + System.DateTime.Now + "  :"
                + "   Waste Level: "+WasteLevel.ToString("F2")
                + " Liters    -    "+msg);
        }

        public void PumpingOn()
        {
            Pumping = true;
            echo("Pumping Enabled");
            picPump.Image = ScadaEMU.Properties.Resources.pumpR;
            picPump.Update();
        }

        public void PumpingOff()
        {
            Pumping = false; picPump.Image = null;
            echo("Pumping Disabled");
            picPump.Update();
        }

        public void Monitor()
        {
            foreach (var sensor in Sensors)
            {
                sensor.CheckLevel(Level);
            }

            TheLevelSensor sThreshold = Sensors.FirstOrDefault(s => s.Name == "EmptyLevel");
            TheLevelSensor sHigh = Sensors.FirstOrDefault(s => s.Name == "HighLevel");
            TheLevelSensor sAlarm = Sensors.FirstOrDefault(s => s.Name == "AlarmLevel");

            if (sHigh.Engaged)
            {
                Pump.TurnOn();
            }

            if (Pump.IsOn)
            {
                if (sThreshold.Engaged) Level -= ScadaCore.Constants.OptionsConstants.PumpingSpeed;
                else
                {
                    Pump.TurnOff();
                    Valve.TurnOn();
                }
            }

            if (Valve.IsOn)
            {
                if (!sAlarm.Engaged) Level += ScadaCore.Constants.OptionsConstants.FillingSpeed;
                else
                {
                    Valve.TurnOff();
                    Pump.TurnOn();
                }
            }

        }
        public void updateLevel()
            {
               if(Level >= ThresholdLevel)       //защелка
                    {
                        checkThreshold.Checked=true;
                    }
               if (Level >= HighLevel) checkHighlevel.Checked = true; //верхний уровень
               if (Pumping)                     //отбор
                   {
                   if (Level >= ThresholdLevel)
                         Level -= PumpingSpeed;
                   else                         //ниже защелки
                        {
                            checkAlarm.Checked = false;
                            checkAlarmbackup.Checked = false;
                            checkHighlevel.Checked = false;
                            checkThreshold.Checked = false;
                            if(Pumping) PumpingOff();
                        }
                   }
               else
                   if (checkHighlevel.Checked) PumpingOn();
               if (Filling)                                     //кран
                   {
                   if (Level < AlarmLevel)
                       Level += FillingSpeed;
                   }
               if (checkAlarm.Checked || checkAlarmbackup.Checked || Level >= AlarmLevel) //авария 
                   {
                      if(Filling) Filling = false;
                      checkAlarm.Checked = true;
                      checkAlarmbackup.Checked = true;
                      if(!Pumping) PumpingOn();
                   }

                labelTank.Text = Level.ToString("F2");  
                picWaste.Height = (int)(Level*((double)(0.83*picTank.Height)/Capacity));
                picWaste.Top = picTank.Top+picTank.Height-picWaste.Height-1;
                picWaste.Update();
            }
    }
}
