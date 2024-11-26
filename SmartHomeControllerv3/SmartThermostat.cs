using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeController
{
    public class SmartThermostat : SmartDevice
    {

        // Private fields
        private double currentTemperature;
        private double targetTemperature;

        // Public properties
        public double CurrentTemperature
        { 
            get { return currentTemperature; } 
            set { currentTemperature = value; } 
        }

        public double TargetTemperature
            { 
            get { return targetTemperature; } 
            set { targetTemperature = value; } 
        }

        // Constructor
        public SmartThermostat(int thermostatDeviceID, string thermostatDeviceName, double thermostatCurrentTemperature, double thermostatTargetTemperature) : base(thermostatDeviceID, thermostatDeviceName)
        {
            this.CurrentTemperature = thermostatCurrentTemperature;
            this.TargetTemperature = thermostatTargetTemperature;

        }

        public override GetStatus()
        {
            base.GetStatus();
            Console.WriteLine("This is a thermostat");
            Console.WriteLine($"Current Tempature: {CurrentTemperature}");
            Console.WriteLine($"Target Tempature: {TargetTemperature}");
        }
    }
}
