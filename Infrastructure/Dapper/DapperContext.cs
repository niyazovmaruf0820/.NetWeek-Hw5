using Npgsql;
namespace Infrastructure.Dapper;

public class DapperContext
{
    private readonly string _connectionString =
    "Host=localhost;Port=5432;Database=.NetWeek2Hw5;User Id=postgres;Password=20080820;";

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}
