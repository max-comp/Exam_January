using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_January
{
    public abstract class Robot
    {

        //properties
        public string Name { get; set; }

        public double PowerCapacity { get; set; }  

        public double CurrentPowerKWH { get; set; }

        public string RobotType { get; set; }

        //constructors
        public Robot(string name, string type, double powerCapacity, double currentPowerKWH)
        {
            Name = name;
            RobotType = type;
            PowerCapacity = powerCapacity;
            CurrentPowerKWH = currentPowerKWH;
        }

        //methods

        public double GetBatteryPercentage()
        {
            return (CurrentPowerKWH / PowerCapacity) * 100;
        }

        public string DisplayBatteryInformation()
        {
            return $"Battery Information\n Capacity: {PowerCapacity} KWH\n Current Power: {CurrentPowerKWH} KWH\n Battery Level: {GetBatteryPercentage():F2}%";
        }

        public abstract string DescribeRobot();

        public override string ToString()
        {
            return $"{Name} - [{RobotType}]";
        }
    }
}
