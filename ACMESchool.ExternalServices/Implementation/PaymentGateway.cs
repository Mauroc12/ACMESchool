using ACMESchool.ExternalServices.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.ExternalServices.Implementation
{
    public class PaymentGateway : IPaymentGateway
    {
        public async Task<bool> Process()
        {
            return true;
        }
    }
}
