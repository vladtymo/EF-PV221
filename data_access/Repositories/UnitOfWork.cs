using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Repositories
{
    public interface IUoW
    {
        Repository<Employee> EmployeeRepo { get; }
        Repository<Position> PositionRepo { get; }
        Repository<Order> OrderRepo { get; }
        Repository<Dish> DishRepo { get; }

        void Save();
    }
    public class UnitOfWork : IUoW, IDisposable
    {
        private static RestaurantDbContext context = new RestaurantDbContext();
        private Repository<Employee> employeeRepo;
        private Repository<Position> positionRepo;
        private Repository<Order> orderRepo;
        private Repository<Dish> dishRepo;

        public Repository<Employee> EmployeeRepo
        {
            get
            {
                if (this.employeeRepo == null)
                {
                    this.employeeRepo = new Repository<Employee>(context);
                }
                return employeeRepo;
            }
        }

        public Repository<Position> PositionRepo
        {
            get
            {

                if (this.positionRepo == null)
                {
                    this.positionRepo = new Repository<Position>(context);
                }
                return positionRepo;
            }
        }

        public Repository<Order> OrderRepo
        {
            get
            {

                if (this.orderRepo == null)
                {
                    this.orderRepo = new Repository<Order>(context);
                }
                return orderRepo;
            }
        }

        public Repository<Dish> DishRepo
        {
            get
            {

                if (this.dishRepo == null)
                {
                    this.dishRepo = new Repository<Dish>(context);
                }
                return dishRepo;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
