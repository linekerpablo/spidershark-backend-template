using Microsoft.AspNetCore.Mvc;

namespace SpiderShark.Api.Presenters
{
    public sealed class JsonContentResult : ContentResult
    {
        public JsonContentResult()
        {
            ContentType = "application/json";
        }
    }
}
