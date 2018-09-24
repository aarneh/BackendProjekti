
    using System;
    using System.Net;
    using System.Net.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    namespace BackendProjekti{
    public class ExceptionFilter : ExceptionFilterAttribute 
    {
        

        public override void OnException(ExceptionContext context)
        {   
            if (context.Exception is LevelRequirementException){
               // context.Result = new BadRequestResult();
			    context.Result = new BadRequestObjectResult("Too low level!");
            }
            
        }
    }
}


