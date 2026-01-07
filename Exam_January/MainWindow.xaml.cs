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
            // create robots and add them to the listbox
            HouseholdRobot robo1 = new HouseholdRobot("HouseBot", "Household", 10.0, 7.5, new List<Robot.HouseholdSkill> {});
            HouseholdRobot robo2 = new HouseholdRobot("GardenMate", "Household", 12.0, 9.0, new List<Robot.HouseholdSkill> { });
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

            // bind the list to the ListBox
            lbxRobots.ItemsSource = robots;




        }



    }
}
