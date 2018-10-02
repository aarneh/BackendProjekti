
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
            if (context.Exception is NotAdminException){
               
			    context.Result = new ForbidResult("You are not admin!");
            }

            if(context.Exception is NoKeyException){
                context.Result = new BadRequestObjectResult("No admin key!");
            }
            
        }
    }
}


