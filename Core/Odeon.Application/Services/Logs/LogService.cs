using Odeon.Application.Repositories;
using Odeon.Application.ViewModels.Logs;

namespace Odeon.Application.Services.Logs
{
    public class LogService : ILogService
    {
        private readonly ILogWriteRepository logWriteRepository;
        public LogService(ILogWriteRepository logWriteRepository)
        {
            this.logWriteRepository = logWriteRepository;
        }
        public async Task<int> WriteLog(LogModel model)
        {
            try
            {
                _ = await logWriteRepository.AddAsync(new()
                {
                    Id = Guid.NewGuid(),
                    Url = model.Url,
                    Method = model.Method,
                    Request = model.Request,
                    Response = model.Response,
                    StatusCode = model.StatusCode,
                    Message = model.Message
                });
                return await logWriteRepository.SaveAsync();
            }
            catch (Exception e)
            {
                return -1;
            }
        }
    }
}
