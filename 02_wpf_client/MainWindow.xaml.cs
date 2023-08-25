using data_access;
using Microsoft.EntityFrameworkCore;
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

namespace _02_wpf_client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RestaurantDbContext db = null;

        public MainWindow()
        {
            InitializeComponent();

            db = new RestaurantDbContext();

            tableView.ItemsSource = db.Employees.Include(x => x.Position).Select(x => new
            {
                x.Id,
                x.FullName,
                x.Salary,
                x.Birthdate,
                PositionName = x.Position.Name
            }).ToList();
        }
    }
}
