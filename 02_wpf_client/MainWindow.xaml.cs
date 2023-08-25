using data_access;
using data_access.Interfaces;
using data_access.Repositories;
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
        //private RestaurantDbContext db = null;
        private IRepository<Employee> repo = null;

        public MainWindow()
        {
            InitializeComponent();

            repo = new Repository<Employee>(new RestaurantDbContext());

            var e = repo.GetByID(1);

            var result = repo.Get(x => x.Salary > 1000, x => x.OrderBy(e => e.Salary), nameof(Employee.Position));

            tableView.ItemsSource = repo.Get(includeProperties: "Position").Select(x => new
            {
                x.Id,
                x.FullName,
                x.Salary,
                x.Birthdate,
                PositionName = x.Position.Name
            });
        }
    }
}
