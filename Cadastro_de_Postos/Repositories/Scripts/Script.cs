namespace Cadastro_de_Postos.Repositories.Scripts
{
    public class Script
    {
        internal static string GetAll =>
            @"
			 SELECT
	            pv.NomePosto AS NomePosto,
	            v.NomeVacina AS NomeVacina,
                v.fabricante AS fabricante,
                v.lote AS lote,
                v.quantidade AS quantidade,
                v.DataValidade AS data_validade
            FROM 
	            PostoDeVacinas pv
            INNER JOIN PostoDeVacinas pvac ON pv.Id = pvac.Id
            INNER JOIN Vacinas v ON pvac.Id = v.Id
            WHERE 
	            pv.Id = v.Id
            ";

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
                dbo.PostoDeVacinas
            WHERE 
                NomePosto = @NomePosto";

        internal static string DeletePosto =>
            @"
            DELETE
            FROM 
                dbo.PostoDeVacinas
            WHERE 
                Id = @Id";

        internal static string CreatePosto =>
            @"
            INSERT INTO dbo.PostoDeVacinas
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
