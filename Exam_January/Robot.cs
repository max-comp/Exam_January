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
        public enum HouseholdSkill
        {
            Cooking,
            Cleaning,
            Laundry,
            Gardening,
            Childcare
        }

        public enum DeliveryMode
        {
            Walking,
            Driving,
            Flying
        }

        //properties
        public string Name { get; set; }

        public double PowerCapacity { get; set; }  

        public double CurrentPowerKWH { get; set; }

        public string RobotType { get; set; }

        //constructors
        public Robot(string name, string roboType, double powerCapacity, double currentPowerKWH)
        {
            Name = name;
            RobotType = roboType;
            PowerCapacity = powerCapacity;
            CurrentPowerKWH = currentPowerKWH;
        }

        //methods

        // method returns remaining power as a percentage
        public double GetBatteryPercentage()
        {
            return (CurrentPowerKWH / PowerCapacity) * 100;
        }
        // returns a formatted string for use in the display
        public string DisplayBatteryInformation()
        {
            return $"Battery Information\n Capacity: {PowerCapacity} KWH\n Current Power: {CurrentPowerKWH} KWH\n Battery Level: {GetBatteryPercentage():F2}%";
        }

        public abstract string DescribeRobot();

        public override string ToString() //used to give robot name and type of robot
        {
            return $"{Name} - [{RobotType}]";
        }
    }

    public class HouseholdRobot : Robot
    {
        //properties
        private List<HouseholdSkill> Skills;

        //constructor
        public HouseholdRobot(string name, string roboType, double powerCapacity, double currentPowerKWH, List<HouseholdSkill> skills)
            : base(name, roboType, powerCapacity, currentPowerKWH)
        {
            Skills = skills;
        }

        //methods
        public override string DescribeRobot()
        {
            string skillsList = string.Join(", ", Skills);
            return $"I am a {RobotType} robot.\nI can help with chores around the house\n\nSkills: {skillsList}\n{DisplayBatteryInformation()}";
        }

        public class DeliveryRobot : Robot
        {
            //properties
            public DeliveryMode ModeOfDelivery { get; set; }
            public double MaxLoadKG { get; set; }

            //constructor
            public DeliveryRobot(string name, string roboType, double powerCapacity, double currentPowerKWH, DeliveryMode mode, double maxLoadKG)
                : base(name, roboType, powerCapacity, currentPowerKWH)
            {
                ModeOfDelivery = mode;
                MaxLoadKG = maxLoadKG;
            }

            //methods
            public override string DescribeRobot()
            {

                return $"I am a {RobotType} robot.\n\nI specialise in delivery by {ModeOfDelivery}\nThe maximum load I can carry is {MaxLoadKG}{DisplayBatteryInformation()}";
            }

        }
    }



}
