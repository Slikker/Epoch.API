using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.EPOCH.BACKEND
{
	public static class CustomObjectResult
	{
		public static ObjectResult ErrorObjectResult(ResponseType responseType)
		{
			ObjectResult objectResult = new ObjectResult(Constants.ResponseDictionary[responseType]);
			objectResult.StatusCode = StatusCodes.Status500InternalServerError;
			return objectResult;
		}

		public static NotFoundObjectResult NotFoundObjectResult(ResponseType responseType)
		{
			NotFoundObjectResult notFoundResult = new NotFoundObjectResult(Constants.ResponseDictionary[responseType]);
			notFoundResult.StatusCode = StatusCodes.Status404NotFound;
			return notFoundResult;
		}

		public static BadRequestObjectResult BadRequestObjectResult(ResponseType responseType)
		{
			BadRequestObjectResult badRequestResult = new BadRequestObjectResult(Constants.ResponseDictionary[responseType]);
			badRequestResult.StatusCode = StatusCodes.Status400BadRequest;
			return badRequestResult;
		}

		public static OkObjectResult OkRequestObjectResult(object data)
		{
			OkObjectResult okRequestResult = new OkObjectResult(data);
			okRequestResult.StatusCode = StatusCodes.Status200OK;
			return okRequestResult;
		}

        public static CreatedResult CreatedObjectResult(object data)
        {
            CreatedResult createdObjectResult = new CreatedResult("",data);
            createdObjectResult.StatusCode = StatusCodes.Status201Created;
            return createdObjectResult;
        }
	}
}
