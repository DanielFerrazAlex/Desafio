namespace Cadastro_de_Postos.Repositories.Scripts
{
    public class Script
    {
        internal static string GetAll =>
            @"
			SELECT 
                pv.id AS id, 
                pv.nome AS nome_posto,
                v.id AS id,
                v.nome_vacina AS nome_vacina,
                v.fabricante AS fabricante,
                v.lote AS lote,
                v.quantidade AS quantidade,
                v.data_aprovacao AS data_validade
            FROM
                dbo.PostosVacinacao pv
            INNER JOIN dbo.PostosVacinacao_Vacina pvv ON pv.id = pvv.id_posto
            INNER JOIN dbo.Vacina v ON pvv.id_vacina = v.id
            ORDER BY
                pv.id, v.id;
            ";

        internal static string VerifyLote =>
            @"
            SELECT COUNT(*) FROM 
                dbo.Vacinas 
            WHERE 
                Lote = @Lote";

        internal static string VerifyPosto =>
            @"
            SELECT COUNT(*) FROM 
                dbo.Vacinas 
            WHERE 
                Nome_Posto = @Nome_Posto";

        internal static string VerifyEstoque =>
            @"
            SELECT 
                quantidade 
            FROM 
                dbo.EstoqueVacinas 
            WHERE 
                IdPosto = @IdPosto";

        internal static string DeletePosto =>
            @"
            DELETE
            FROM 
                dbo.PostosDeVacina 
            WHERE 
                Id = @Id";

        internal static string CreatePosto =>
            @"
            INSERT INTO PostosDeVacina
                (Nome_Posto)
            VALUES 
                (@Nome_Posto)
            ";

        internal static string CreateVacinas =>
            @"
            INSERT INTO PostosDeVacina
                (Nome_Vacina, 
                Fabricante, 
                QuantidadeDisponivel, 
                DataValidade)
            VALUES 
                (@Nome_Vacina, 
                @Fabricante, 
                @QuantidadeDisponivel, 
                @DataValidade)
            ";
    }
}
