using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SampleNLayerProject.API.DTOs;
using SampleNLayerProject.Core.Services;

namespace SampleNLayerProject.API.Filters
{
    public class NotFoundFilter<TEntity> : IAsyncActionFilter where TEntity : class
    {
        private readonly IService<TEntity> _service;

        public NotFoundFilter(IService<TEntity> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();
            var entity = await _service.GetByIdAsync(id);

            if (entity != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 404;
                errorDto.Errors.Add($"The entity that has '{id}' id, is not found!");
                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}
