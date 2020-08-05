using CompanyData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyData.Validations
{
    public class CompanyValidations : ICompanyValidations
    {
        public bool IsCorrectPasswordHint(string passwordHint)
        {
            throw new NotImplementedException();
        }

        public bool IsCorrectUser(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public bool IsLevelOfResponsibilityAssigned(int managerId)
        {
            throw new NotImplementedException();
        }

        public bool IsUniquePersonalNo(string personalNo)
        {
            throw new NotImplementedException();
        }

        public bool IsUniqueUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
