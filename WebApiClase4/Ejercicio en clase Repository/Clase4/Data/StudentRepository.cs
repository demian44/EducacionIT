using Clase4.Models;

namespace Clase4.Data
{
    public class StudentRepository : Repository<Student, MyContext>
    {
        public StudentRepository(MyContext context)
            : base(context)
        { }
    }
}
