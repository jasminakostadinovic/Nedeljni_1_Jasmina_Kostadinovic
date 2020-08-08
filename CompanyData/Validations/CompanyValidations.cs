using CompanyData.Interfaces;
using CompanyData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataValidations;

namespace CompanyData.Validations
{
    public class CompanyValidations : ICompanyValidations
    {
        public bool IsCorrectUser(string userName, string password)
        {
            try
            {
                using (var conn = new CompanyManagementEntities())
                {
                    var user = conn.tblUserDatas.FirstOrDefault(x => x.Username == userName);

                    if (user != null)
                    {
                        var passwordFromDb = conn.tblUserDatas.First(x => x.Username == userName).Password;
                        return SecurePasswordHasher.Verify(password, passwordFromDb);
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsLevelOfResponsibilityAssigned(int managerId)
        {
            try
            {
                using (var conn = new CompanyManagementEntities())
                {
                    var manager = conn.tblManagers.FirstOrDefault(x => x.ManagerID == managerId);
                    if(manager != null)
                    {
                        if (manager.LevelOfResponsibility == null)
                            return false;
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsUniquePersonalNo(string personalNo)
        {
            try
            {
                using (var conn = new CompanyManagementEntities())
                {
                    return !conn.tblUserDatas.Any(x => x.PersonalNo == personalNo);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GetUserType(int userDataId)
        {
            try
            {
                using (var conn = new CompanyManagementEntities())
                {
                    if (conn.tblManagers.Any(x => x.UserDataID == userDataId))
                        return nameof(tblManager);
                    if (conn.tblEmployees.Any(x => x.UserDataID == userDataId))
                        return nameof(tblEmployee);
                    if (conn.tblAdministrators.Any(x => x.UserDataID == userDataId))
                        return nameof(tblAdministrator);
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool IsUniqueUsername(string username)
        {
            try
            {
                using (var conn = new CompanyManagementEntities())
                {
                    return !conn.tblUserDatas.Any(x => x.Username == username);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
