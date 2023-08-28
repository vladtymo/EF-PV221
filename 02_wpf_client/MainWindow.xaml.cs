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
        // 1 - using DbContext
        //private RestaurantDbContext db = null;

        // 2 - using Repositories
        //private IRepository<Employee> empRepo = null;
        //private IRepository<Position> posRepo = null;
        // ... others repositories

        // 3 - using Unit of Work
        private IUoW uow = new UnitOfWork();

        public MainWindow()
        {
            InitializeComponent();

            //var ctx = new RestaurantDbContext();
            //empRepo = new Repository<Employee>(ctx);
            //posRepo = new Repository<Position>(ctx);

            var p = uow.EmployeeRepo.GetByID(1);
            var e = uow.PositionRepo.GetByID(1);

            var result = uow.EmployeeRepo.Get(x => x.Salary > 1000, x => x.OrderBy(e => e.Salary), nameof(Employee.Position));

            tableView.ItemsSource = uow.EmployeeRepo.Get(includeProperties: "Position").Select(x => new
            {
                x.Id,
                x.FullName,
                x.Salary,
                x.Birthdate,
                PositionName = x.Position.Name
            });

            uow.Save();
        }
    }
}
