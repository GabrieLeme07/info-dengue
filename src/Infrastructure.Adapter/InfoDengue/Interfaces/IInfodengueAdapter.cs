using Infrastructure.Adapter.InfoDengue.DTOs;

namespace Infrastructure.Adapter.InfoDengue.Interfaces;

public interface IInfodengueAdapter
{
    Task<InfodengueResponseItemDto> GetReportAsync(InfodengueRequestDto parameters);
}
