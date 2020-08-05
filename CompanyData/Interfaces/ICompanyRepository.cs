using CompanyData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyData.Interfaces
{
    public interface ICompanyRepository
    {
        bool TryAddNewEmployee(tblEmployee employee);
        List<vwEmployee> LoadEmployees();
        tblEmployee LoadEmployee(int employeeID);
        bool TryDeleteEmployee(int employeeID);
        bool TryUpdateEmployee(int employeeID, tblEmployee employee);

        bool TryAddNewManager(tblManager manager);
        List<vwManager> LoadManagers();
        tblManager LoadManager(int managerID);
        bool TryDeleteManager(int managerID);
        bool TryUpdateManager(int managerID, tblManager manager);

        bool TryAddNewAdministrator(tblAdministrator administrator);
        List<vwAdministrator> LoadAdministrators();
        tblAdministrator LoadAdministrator(int administratorID);
        bool TryDeleteAdministrator(int administratorID);
        bool TryUpdateAdministrator(int administratorID, tblAdministrator administrator);
        bool TryAddNewUserData(tblUserData userData);
        bool TryUpdateUserData(int userDataID, tblUserData userData);



    }
}
