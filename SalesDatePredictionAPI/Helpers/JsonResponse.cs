using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionAPI.Helpers.DTO;

namespace SalesDatePredictionAPI.Helpers
{
    public class JsonResponse : ControllerBase
    {
        private static JsonResponse instance;
        private static readonly object lockObject = new object();

        private JsonResponse() { }

        public static JsonResponse Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new JsonResponse();
                        }
                    }
                }
                return instance;
            }
        }

        public ActionResult<T> successResponse<T>(T data, string message = null)
        {
            return Ok(new JsonResponseDTO<T>
            {
                Success = true,
                Error = null,
                Message = message ?? "Solicitud exitosa",
                Data = data
            });
        }

        public ActionResult<T> badResponse<T>(string message = null)
        {
            return BadRequest(new JsonResponseDTO<T>
            {
                Success = false,
                Error = null,
                Message = message ?? "No se obtuvo una respuesta exitosa",
                Data = default(T)
            });
        }

        public ActionResult<T> errorResponse<T>(string errorMessage)
        {
            return BadRequest(new JsonResponseDTO<T>
            {
                Success = false,
                Error = errorMessage,
                Message = "Se produjo un error en la solicitud",
                Data = default(T)
            });
        }
    }
}
