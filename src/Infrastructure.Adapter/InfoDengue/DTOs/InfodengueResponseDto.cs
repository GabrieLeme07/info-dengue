using System.Text.Json.Serialization;

namespace Infrastructure.Adapter.InfoDengue.DTOs;

public class InfodengueResponseDto
{
    public string Arbovirus { get; init; }
    public int StartWeek { get; init; }
    public int EndWeek { get; init; }
    public string IBGECode { get; init; }
    public string City { get; init; }
    public int TotalCases { get; init; }
}

public class InfodengueResponseItemDto
{
    [JsonPropertyName("data_iniSE")]
    public long DataIniSE { get; set; }

    [JsonPropertyName("SE")]
    public int SE { get; set; }

    [JsonPropertyName("casos_est")]
    public double CasosEst { get; set; }

    [JsonPropertyName("casos_est_min")]
    public int CasosEstMin { get; set; }

    [JsonPropertyName("casos_est_max")]
    public int CasosEstMax { get; set; }

    [JsonPropertyName("casos")]
    public int Casos { get; set; }

    [JsonPropertyName("p_rt1")]
    public double PRt1 { get; set; }

    [JsonPropertyName("p_inc100k")]
    public double PInc100k { get; set; }

    [JsonPropertyName("Localidade_id")]
    public int LocalidadeId { get; set; }

    [JsonPropertyName("nivel")]
    public int Nivel { get; set; }

    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("versao_modelo")]
    public string VersaoModelo { get; set; }

    [JsonPropertyName("tweet")]
    public string Tweet { get; set; }

    [JsonPropertyName("Rt")]
    public double Rt { get; set; }

    [JsonPropertyName("pop")]
    public double Pop { get; set; }

    [JsonPropertyName("tempmin")]
    public double? TempMin { get; set; }

    [JsonPropertyName("umidmax")]
    public double? UmidMax { get; set; }

    [JsonPropertyName("receptivo")]
    public int Receptivo { get; set; }

    [JsonPropertyName("transmissao")]
    public int Transmissao { get; set; }

    [JsonPropertyName("nivel_inc")]
    public int NivelInc { get; set; }

    [JsonPropertyName("umidmed")]
    public double? UmidMed { get; set; }

    [JsonPropertyName("umidmin")]
    public double? UmidMin { get; set; }

    [JsonPropertyName("tempmed")]
    public double? TempMed { get; set; }

    [JsonPropertyName("tempmax")]
    public double? TempMax { get; set; }

    [JsonPropertyName("casprov")]
    public int Casprov { get; set; }

    [JsonPropertyName("casprov_est")]
    public int? CasprovEst { get; set; }

    [JsonPropertyName("casprov_est_min")]
    public int? CasprovEstMin { get; set; }

    [JsonPropertyName("casprov_est_max")]
    public int? CasprovEstMax { get; set; }

    [JsonPropertyName("casconf")]
    public int? Casconf { get; set; }

    [JsonPropertyName("notif_accum_year")]
    public int NotifAccumYear { get; set; }
}