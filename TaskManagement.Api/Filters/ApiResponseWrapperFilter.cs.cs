using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TaskManagement.Business.ResponseModels;
namespace TaskManagement.Api.Filters
{
    public class ApiResponseWrapperFilter:IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception!=null)
            return;
            switch (context.Result)
            {

                    case ObjectResult objectResult:
                    var wrappedSuccess=ApiResponseFactory.Success(objectResult.Value);
                    context.Result=new ObjectResult(wrappedSuccess)
                    {
                        StatusCode=200
                    };
                    break;
              
                case NotFoundResult:
                    var wrappedNotFound=ApiResponseFactory.NotFound<string>(
                        new List<string> {"The requested resource was not there"});
                    context.Result = new ObjectResult(wrappedNotFound)
                    {
                        StatusCode = 404
                    };
                    break;
                  case BadRequestResult:
                    var wrappedBadRequest=ApiResponseFactory.BadRequest<string>(
                        new List<string>{"Bad request.Please check your input."});
                    context.Result=new ObjectResult(wrappedBadRequest)
                    {
                        StatusCode=400
                    };
                    break;
                //case ObjectResult createdResult when createdResult.StatusCode == 201:
                //    var wrappedCreated = ApiResponseFactory.Created(createdResult.Value);
                //    context.Result = new ObjectResult(wrappedCreated)
                //    {
                //        StatusCode = 201
                //    };
                //    break;
            }
        }
    }
}
