
using SQLite;

namespace BeakonMvvm.Core.Interfaces
{
    public interface ISqlite
    {
            SQLiteConnection GetConnection();
    }
}
