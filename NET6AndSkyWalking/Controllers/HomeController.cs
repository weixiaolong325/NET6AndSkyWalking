using Microsoft.AspNetCore.Mvc;
using NET6AndSkyWalking.Models;
using SkyApm.Tracing;
using SkyApm.Tracing.Segments;
using System.Net;

namespace NET6AndSkyWalking.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEntrySegmentContextAccessor _segContext;
        public HomeController(IEntrySegmentContextAccessor segContext)
        {
            _segContext = segContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult HelloWorld()
        {
            return Json("Hello World!");
        }
        /// <summary>
        /// 获取链路追踪ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetSkywalkingTracedId()
        {
            string tracedId = _segContext.Context.TraceId;
            return tracedId;
        }
        /// <summary>
        /// 自定义日志
        /// </summary>
        /// <returns></returns>
        public string SkywalkingLog()
        {
            //获取全局traceId
            var traceId = _segContext.Context.TraceId;
            _segContext.Context.Span.AddLog(LogEvent.Message("自定义日志1"));
            Thread.Sleep(1000);
            _segContext.Context.Span.AddLog(LogEvent.Message("自定义日志2"));
            return traceId;
        }
        public async Task<string> GetUser()
        {
            var client = new HttpClient();
            //调用Service2
           var response=await client.GetAsync("http://localhost:5199/UserInfo/GetUserInfo");
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
        /// <summary>
        /// 故意报错测试告警
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public  string Error()
        {

            //故意报错
            throw new Exception($"出错啦:{DateTime.Now}");
        }
        /// <summary>
        /// 告警
        /// </summary>
        /// <param name="msgs"></param>
        [HttpPost]
        public void AlarmMsg([FromBody]List<AlarmMsg> msgs)
        {
            string msg = $"{DateTime.Now},触发告警：";
            msg += msgs.FirstOrDefault()?.alarmMessage;
            Console.WriteLine(msg);
           //todo 发邮件或发短信
        }
    }
}
