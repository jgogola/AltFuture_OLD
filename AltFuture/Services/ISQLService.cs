using System.Data;

namespace AltFuture.Services
{
    public interface ISQLService
    {
        DataTable GetDT(string storedProcName, List<Object>? parameters = null, string connectionStringName = "");
        int GetRetVal(string storedProcName, List<Object>? parameters = null, string connectionStringName = "");
    }
}