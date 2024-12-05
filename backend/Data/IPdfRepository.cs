namespace inv.Data
{
    public interface IPdfRepository
    {
        IEnumerable<Student> GetAllStudents();
    }
}