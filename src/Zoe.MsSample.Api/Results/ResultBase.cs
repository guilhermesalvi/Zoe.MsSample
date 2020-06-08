using System;
using System.Collections.Generic;

namespace Zoe.MsSample.Api.Results
{
    public class ResultBase<T> where T : class
    {
        public bool Succeeded { get; set; }
        public T Data { get; set; }
        public IEnumerable<ApplicationError> Errors { get; set; }

        public ResultBase() { }

        public ResultBase(T data)
        {
            this.Succeeded = true;
            this.Data = data;
            this.Errors = null;
        }

        public ResultBase(IEnumerable<ApplicationError> errors)
        {
            this.Succeeded = false;
            this.Data = null;
            this.Errors = errors;
        }
    }

    public class ApplicationError
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
