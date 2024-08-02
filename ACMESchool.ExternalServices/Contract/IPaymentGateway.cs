using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.ExternalServices.Contract
{
    public interface IPaymentGateway
    {
        public Task<bool> Process();
    }
}
