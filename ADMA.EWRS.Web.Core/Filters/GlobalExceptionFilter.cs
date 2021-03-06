﻿//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ADMA.EWRS.Web.Core.Filters
//{
//    public class GlobalExceptionFilter : IExceptionFilter, IDisposable
//    {
//        private readonly ILogger _logger;

//        public GlobalExceptionFilter(ILoggerFactory logger)
//        {
//            if (logger == null)
//            {
//                throw new ArgumentNullException(nameof(logger));
//            }

//            this._logger = logger.CreateLogger("EWRS Exception Filter");
//        }

//        public void Dispose()
//        {
//            throw new NotImplementedException();
//        }

//        public void OnException(ExceptionContext context)
//        {
//            var response = new ErrorResponse()
//            {
//                Message = context.Exception.Message,
//                StackTrace = context.Exception.StackTrace
//            };

//            context.Result = new ObjectResult(response)
//            {
//                StatusCode = 500,
//                DeclaredType = typeof(ErrorResponse)
//            };

//            this._logger.LogError("GlobalExceptionFilter", context.Exception);
//        }
//    }

//}
