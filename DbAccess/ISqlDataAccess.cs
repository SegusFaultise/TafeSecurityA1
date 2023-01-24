namespace SQL_WEB_APPLICATION.DbAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "Defualt");
        Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "Defualt");
    }
}