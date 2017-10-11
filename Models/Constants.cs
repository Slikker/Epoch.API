using System.Collections.Generic;

namespace API.EPOCH.BACKEND
{
	public static partial class Constants
	{	
		public static Dictionary<ResponseType, string> ResponseDictionary = new Dictionary<ResponseType, string>
		{
			{ ResponseType.Error , "Error" },
			{ ResponseType.NotFound , "Not found" },
			{ ResponseType.BadRequest , "Bad request" },
			{ ResponseType.OkResponse , "Success" }
		};
	}

	public enum ResponseType
	{
		Error,
		NotFound,
		BadRequest,
		OkResponse
	}
}
