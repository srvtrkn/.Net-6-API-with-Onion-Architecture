using Odeon.Application.ViewModels.Logs;

namespace Odeon.Application.Services.Logs
{
    public interface ILogService
    {
        Task<int> WriteLog(LogModel model);
    }
}
