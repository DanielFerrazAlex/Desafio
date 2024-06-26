namespace Cadastro_de_Postos.Data
{
    public class Env
    {
        //Conexões
        private static readonly string APPLICATION_NAME = Environment.GetEnvironmentVariable("APPLICATION_NAME");
        private static readonly string DATABASE_HOST = Environment.GetEnvironmentVariable("DATABASE_HOST");
        private static readonly string DATABASE_NAME = Environment.GetEnvironmentVariable("DATABASE_NAME");
        private static readonly string DATABASE_USER = Environment.GetEnvironmentVariable("DATABASE_USER");
        private static readonly string DATABASE_PASS = Environment.GetEnvironmentVariable("DATABASE_PASS");
        private static readonly string DATABASE_TIMEOUT = Environment.GetEnvironmentVariable("DATABASE_TIMEOUT");
        private static readonly string DATABASE_MAX_CONNECTIONS = Environment.GetEnvironmentVariable("DATABASE_MAX_CONNECTIONS");

        public static string GetConnectionDataBase()
        {
            return $"Application Name={APPLICATION_NAME}; Server={DATABASE_HOST}; Database={DATABASE_NAME}; "
                 + $"User Id={DATABASE_USER}; Password={DATABASE_PASS}; MultipleActiveResultSets=true; "
                 + $"Connection Timeout={DATABASE_TIMEOUT}; Max Pool Size={DATABASE_MAX_CONNECTIONS}; "
                 + $"TrustServerCertificate=True";
        }
    }
}
