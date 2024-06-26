namespace Cadastro_de_Postos.Repositories.Scripts
{
    public class Script
    { 

        internal static string VerifyLote =>
            @"
            SELECT COUNT(*) FROM 
                dbo.Vacinas 
            WHERE 
                Lote = @Lote";

        internal static string VerifyVacina =>
    @"
            SELECT COUNT(*) FROM 
                dbo.Vacinas 
            WHERE 
                Id = @Id";

        internal static string VerifyPosto =>
            @"
            SELECT COUNT(*) FROM 
                dbo.PostoDeVacina
            WHERE 
                NomePosto = @NomePosto";

        internal static string DeletePosto =>
            @"
            DELETE
            FROM 
                dbo.PostosDeVacina 
            WHERE 
                Id = @Id";

        internal static string CreatePosto =>
            @"
            INSERT INTO dbo.PostoDeVacina
                (NomePosto)
            VALUES 
                (@NomePosto)
            ";

        internal static string CreateVacinas =>
            @"
            INSERT INTO dbo.Vacinas
                (NomeVacina, 
                Fabricante, 
                Quantidade, 
                DataValidade)
            VALUES 
                (@NomeVacina, 
                @Fabricante, 
                @Quantidade, 
                @DataValidade)
            ";
    }
}
