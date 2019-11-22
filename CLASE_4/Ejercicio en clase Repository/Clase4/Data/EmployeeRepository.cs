using Clase4.Models;

namespace Clase4.Data
{
    public class EmployeeRepository : Repository<Employee, MyContext>
    {
        public EmployeeRepository(MyContext context)
            : base(context)
        { }
    }
}
