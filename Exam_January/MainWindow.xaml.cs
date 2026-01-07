using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Exam_January
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Robot> robots = new List<Robot>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            #region Creating AND Adding Robots to the List
            // create robots and add them to the listbox
            HouseholdRobot robo1 = new HouseholdRobot("HouseBot", "Household", 10.0, 7.5, new List<Robot.HouseholdSkill> {});
            HouseholdRobot robo2 = new HouseholdRobot("GardenMate", "Household", 12.0, 9.0, new List<Robot.HouseholdSkill> {});
            HouseholdRobot robo3 = new HouseholdRobot("Housemate 3000", "Household", 15.0, 15.0, new List<Robot.HouseholdSkill> {});

            // create delivery robots
            DeliveryRobot robo4 = new DeliveryRobot("DeliverBot", "Delivery", 20.0, 18.0, Robot.DeliveryMode.Walking, 100.0);
            DeliveryRobot robo5 = new DeliveryRobot("FlyBot", "Delivery", 25.0, 17.0, Robot.DeliveryMode.Walking, 50.0);
            DeliveryRobot robo6 = new DeliveryRobot("Driver", "Delivery", 30.0, 25.0, Robot.DeliveryMode.Driving, 20.0);

            // add robots to the list
            robots.Add(robo1);
            robots.Add(robo2);
            robots.Add(robo3);
            robots.Add(robo4);
            robots.Add(robo5);
            robots.Add(robo6);
            #endregion

            // bind the list to the ListBox
            lbxRobots.ItemsSource = robots;

            //display robots info in the textbox when selected
            lbxRobots.SelectionChanged += (s, ev) =>
            {
                if (lbxRobots.SelectedItem is Robot selectedRobot)
                {
                    tbxDetails.Text = selectedRobot.DescribeRobot();
                }
            };

            // Add Gardening to GardenMate and Add Cooking and Laundry to Housemate 3000
            robo2.AddSkill(Robot.HouseholdSkill.Gardening);
            robo3.AddSkill(Robot.HouseholdSkill.Cooking);
            robo3.AddSkill(Robot.HouseholdSkill.Laundry);

        }
        //radio button selected - display only chosen type of robot
        private void rbRobot_Checked(object sender, RoutedEventArgs e)
        {
            if (rbAllRobots.IsChecked == true)
            {
                lbxRobots.ItemsSource = robots;
            }
            else if (rbHousehold.IsChecked == true)
            {
                lbxRobots.ItemsSource = robots.OfType<HouseholdRobot>().ToList();
            }
            else if (rbDelivery.IsChecked == true)
            {
                lbxRobots.ItemsSource = robots.OfType<DeliveryRobot>().ToList();
            }


        }
    }
}
