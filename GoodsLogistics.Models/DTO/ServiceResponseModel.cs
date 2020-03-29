using System;
using System.Collections.Generic;
using System.Text;

namespace GoodsLogistics.Models.DTO
{
    public class ServiceResponseModel<T> where T : class
    {
        public ServiceResponseModel() { }

        public ServiceResponseModel(T data)
        {
            Data = data;
            IsSuccess = true;
        }

        public ServiceResponseModel(Dictionary<string, string> errors)
        {
            Errors = errors;
            IsSuccess = false;
        }

        public T Data { get; }

        public Dictionary<string, string> Errors { get; }

        public bool IsSuccess { get; }
    }
}
