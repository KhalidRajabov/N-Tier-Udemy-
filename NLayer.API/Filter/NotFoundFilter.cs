﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Filter
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        //important: If a constructor of a filter has a service injected to it, it needs to be written in program cs.
        private readonly IService<T> _service;

        public NotFoundFilter(IService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue =context.ActionArguments.Values.FirstOrDefault();
            if (idValue == null)
            {
                await next.Invoke();
                return;
            }

            var id = (int)idValue;
            var anyEntity= await _service.AnyAsync(x=>x.Id==id);

            if (anyEntity)
            {
                await next.Invoke();
                return;
            }
            context.Result = new NotFoundObjectResult(
                CustomResponseDTO<NoContentDTO>.Fail(404, $"{typeof(T).Name} with {id} id is not found")
                );

        }
    }
}
