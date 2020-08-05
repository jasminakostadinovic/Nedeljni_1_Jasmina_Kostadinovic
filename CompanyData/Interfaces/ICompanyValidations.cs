using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyData.Interfaces
{
    interface ICompanyValidations
    {
        bool IsCorrectUser(string userName, string password);
        bool IsUniqueUsername(string username);
        bool IsUniquePersonalNo(string personalNo);
        bool IsCorrectPasswordHint(string passwordHint);
        bool IsLevelOfResponsibilityAssigned(int managerId);
    }
}
