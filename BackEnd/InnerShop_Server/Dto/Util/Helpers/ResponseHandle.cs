using DTO.DTO;
using Microsoft.Extensions.Logging;
using System.Net;

namespace DAL.Util.Helpers
{
    public class ResponseHandler
    {
        private ILogger _logger;

        public ResponseHandler(ILogger logger)
        {
            _logger = logger;
        }

        public ResponseDTO CreateReponse(string message, int statusCode, bool success = false, object? result = null)
        {
            return new ResponseDTO(message, statusCode, success, result);
        }

        //Success responses
        public ResponseDTO GetSuccessResponse(string message, object result)
        {
            _logger.LogInformation(message);
            return CreateReponse(message,(int)HttpStatusCode.OK, true, result);
        }

        public ResponseDTO CreateSuccessResponse(string message, object result)
        {
            _logger.LogInformation(message);
            return CreateReponse(message,(int)HttpStatusCode.Created, true, result);
        }

        public ResponseDTO UpdateSuccessResponse(string message, object result)
        {
            _logger.LogInformation(message);
            return CreateReponse(message,(int)HttpStatusCode.NoContent, true, result);
        }

        public ResponseDTO DeleteSuccessResponse(string message, object result)
        {
            _logger.LogInformation(message);
            return CreateReponse(message,(int)HttpStatusCode.NoContent, true, result);
        }
    }
}
