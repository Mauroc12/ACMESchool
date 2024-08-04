using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Application.Model
{
    public abstract class ResponseBase
    {
        public bool IsSuccess { get; set; }
        public string Message { get; private set; }

        public T Success<T>() where T : ResponseBase, new()
        {
            return new T
            {
                IsSuccess = true,
                Message = "Operacion Realizada con Exito"
            }; 
        } 
    }
}
