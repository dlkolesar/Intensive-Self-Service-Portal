using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Intensive.API.Global
{
    public class ServerError : ObjectResult
    {
        public ServerError(object value)
            : base(value)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
