using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsApi.Models
{
    public class ServiceResult<T> where T : class
    {
        public bool Ok { get; set; }
        public IList<string> Errors { get; set; }
        public T Data { get; set; }

        public ServiceResult(bool ok, IList<string> errors = null, T data = null)
        {
            if (errors == null)
            {
                errors = new List<string>();
            }
            Ok = ok;
            Errors = errors;
            Data = data;
        }
    }
}