using Microsoft.AspNetCore.Mvc;
using SkyApm.Tracing;
using SkyApm.Tracing.Segments;

namespace SkywalkingWeb2.Controllers
{
    public class UserInfoController : Controller
    {
        private readonly IEntrySegmentContextAccessor _segContext;
        public UserInfoController(IEntrySegmentContextAccessor segContext)
        {
            _segContext = segContext;
        }
        [HttpGet]
        public string GetUserInfo(string userId)
        {
            string result = $"userId:{userId},userName:张三";
            _segContext.Context.Span.AddLog(LogEvent.Message(result));

            return result;
        }
    }
}
