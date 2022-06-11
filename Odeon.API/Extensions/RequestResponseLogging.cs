using Odeon.Application.Services.Logs;
using Odeon.Application.ViewModels.Logs;
using System.Text;

namespace Odeon.API.Extensions
{
    public class RequestResponseLogging
    {
        private readonly RequestDelegate next;
        public RequestResponseLogging(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context, ILogService logService)
        {
            try
            {
                context.Request.EnableBuffering();
                var model = await LogRequest(context.Request);
                await LogResponse(context, model, logService);
            }
            catch (Exception ex)
            {
                //Custom exception logging here
            }
        }
        public async Task<LogModel> LogRequest(HttpRequest request)
        {
            string requestBody = await new StreamReader(request.Body).ReadToEndAsync();
            var injectedRequestStream = new MemoryStream();
            byte[] bytesToWrite = Encoding.UTF8.GetBytes(requestBody);
            injectedRequestStream.Write(bytesToWrite, 0, bytesToWrite.Length);
            injectedRequestStream.Seek(0, SeekOrigin.Begin);
            request.Body = injectedRequestStream;

            return new LogModel
            {
                Url = $"{request.Scheme} {request.Host}{request.Path} {request.QueryString}",
                Method = $"{request.Path}",
                Request = requestBody,
                Message = ""
            };
        }
        public async Task LogResponse(HttpContext context, LogModel model, ILogService logService)
        {
            if (model == null)
            {
                await next(context);
                return;
            }
            Stream originalBody = context.Response.Body;
            try
            {
                using (var memStream = new MemoryStream())
                {
                    context.Response.Body = memStream;

                    await next(context);

                    memStream.Position = 0;
                    string responseBody = new StreamReader(memStream).ReadToEnd();

                    model.StatusCode = context.Response.StatusCode;
                    model.Response = responseBody;
                    await logService.WriteLog(model);
                    memStream.Position = 0;
                    await memStream.CopyToAsync(originalBody);
                }
            }
            catch (Exception e)
            {
                model.Message = e.Message;
                await logService.WriteLog(model);
            }
            finally
            {
                context.Response.Body = originalBody;
            }
        }
    }
}
