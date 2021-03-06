﻿using CompanyData.Interfaces;
using CompanyData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CompanyData.Repositories
{
    public class CompanyDBRepository : ICompanyRepository
    {
        public tblAdministrator LoadAdministrator(int administratorID)
        {
            try
            {
                using (var conn = new CompanyManagementEntities())
                {
                    return conn.tblAdministrators.FirstOrDefault(x => x.AdministratorID == administratorID);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<vwAdministrator> LoadAdministrators()
        {
            try
            {
                using (var conn = new CompanyManagementEntities())
                {
                    var administrators = new List<vwAdministrator>();
                    if (conn.vwAdministrators.Any())
                    {
                        foreach (var item in conn.vwAdministrators)
                        {
                            administrators.Add(item);
                        }
                    }
                    return administrators;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public tblEmployee LoadEmployee(int employeeID)
        {
            try
            {
                using (var conn = new CompanyManagementEntities())
                {
                    return conn.tblEmployees.FirstOrDefault(x => x.EmployeeID == employeeID);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int GetUserDataId(string userName)
        {
            try
            {
                using (var conn = new CompanyManagementEntities())
                {
                    var user = conn.tblUserDatas.FirstOrDefault(x => x.Username == userName);
                    if (user != null)
                        return user.UserDataID;
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<vwEmployee> LoadEmployees()
        {
            try
            {
                using (var conn = new CompanyManagementEntities())
                {
                    var employees = new List<vwEmployee>();
                    if (conn.vwEmployees.Any())
                    {
                        foreach (var item in conn.vwEmployees)
                        {
                            employees.Add(item);
                        }
                    }
                    return employees;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public tblManager LoadManager(int managerID)
        {
            try
            {
                using (var conn = new CompanyManagementEntities())
                {
                    return conn.tblManagers.FirstOrDefault(x => x.ManagerID == managerID);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool TryAddNewSector(tblSector sector)
        {
            try
            {
                using (var conn = new CompanyManagementEntities())
                {
                    conn.tblSectors.Add(sector);
                    conn.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TryDeleteSector(int sectorID)
        {
            try
            {
                using (var conn = new CompanyManagementEntities())
                {
                    var sectorToRemove = conn.tblSectors.FirstOrDefault(x => x.SectorID == sectorID);

                    if (sectorToRemove != null)
                    {
                        if(conn.tblEmployees.Any(x => x.SectorID == sectorID))
                        {
                            ChangeEmployeesSectorToDefault(sectorID);
                            conn.tblSectors.Remove(sectorToRemove);
                            conn.SaveChanges();
                            return true;
                        }
                        else
                        {
                            conn.tblSectors.Remove(sectorToRemove);
                            conn.SaveChanges();
                            return true;
                        }
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool ChangeEmployeesSectorToDefault(int sectorID)
        {
            try
            {
                using (var conn = new CompanyManagementEntities())
                {
                    var employees = conn.tblEmployees.Where(x => x.SectorID == sectorID).ToList();
                    int id = GetIdofDefaultSector();
                    foreach (var item in employees)
                    {
                        item.SectorID = id;
                    }
                    conn.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private int GetIdofDefaultSector()
        {
            try
            {
                using (var conn = new CompanyManagementEntities())
                {
                    var sector = conn.tblSectors.FirstOrDefault(x => x.SectorName == "Default");
                    if (sector != null)
                        return sector.SectorID;
                    conn.tblSectors.Add(new tblSector() { SectorName = "Default" });
                    conn.SaveChanges();
                    return 1;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<vwManager> LoadManagers()
        {
            try
            {
                using (var conn = new CompanyManagementEntities())
                {
                    var managers = new List<vwManager>();
                    if (conn.vwManagers.Any())
                    {
                        foreach (var item in conn.vwManagers)
                        {
                            managers.Add(item);
                        }
                    }
                    return managers;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool TryAddNewAdministrator(tblAdministrator administrator)
        {
            try
            {
                using (var conn = new CompanyManagementEntities())
                {
                    conn.tblAdministrators.Add(administrator);
                    conn.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TryAddNewEmployee(tblEmployee employee)
        {
            try
            {
                using (var conn = new CompanyManagementEntities())
                {
                    conn.tblEmployees.Add(employee);
                    conn.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TryAddNewManager(tblManager manager)
        {
            try
            {
                using (var conn = new CompanyManagementEntities())
                {
                    conn.tblManagers.Add(manager);
                    conn.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TryAddNewUserData(tblUserData userData)
        {
            try
            {
                using (var conn = new CompanyManagementEntities())
                {
                    conn.tblUserDatas.Add(userData);
                    conn.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TryDeleteAdministrator(int administratorID)
        {
            try
            {
                using (var conn = new CompanyManagementEntities())
                {
                    var adminToRemove = conn.tblAdministrators.FirstOrDefault(x => x.AdministratorID == administratorID);
                    if(adminToRemove != null)
                    {
                        var userDataToRemove = conn.tblUserDatas.FirstOrDefault(x => x.UserDataID == adminToRemove.UserDataID);
                        conn.tblAdministrators.Remove(adminToRemove);
                        conn.SaveChanges();
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

        public bool TryDeleteEmployee(int employeeID)
        {
            try
            {
                using (var conn = new CompanyManagementEntities())
                {
                    var employeeToRemove = conn.tblEmployees.FirstOrDefault(x => x.EmployeeID == employeeID);
                    if(employeeToRemove != null)
                    {
                        var userDataToRemove = conn.tblUserDatas.FirstOrDefault(x => x.UserDataID == employeeToRemove.UserDataID);
                        conn.tblEmployees.Remove(employeeToRemove);
                        conn.SaveChanges();
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

        public List<tblSector> LoadSectors()
        {
            try
            {
                using (var conn = new CompanyManagementEntities())
                {
                    var sectors = new List<tblSector>();
                    if (conn.tblSectors.Any())
                    {
                        if (conn.tblSectors.Any(x => x.SectorName != "Default"))
                        {
                            foreach (var item in conn.tblSectors)
                            {
                                if (item.SectorName == "Default")
                                    continue;
                                sectors.Add(item);
                            }
                        }
                    }
                    else
                    {
                        conn.tblSectors.Add(new tblSector() { SectorName = "Default" });
                    }
                    return sectors;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool TryDeleteManager(int managerID)
        {
            try
            {
                using (var conn = new CompanyManagementEntities())
                {
                    var managerToDelete = conn.tblManagers.FirstOrDefault(x => x.ManagerID == managerID);
                
                    if(managerToDelete != null)
                    {
                        var userDataToRemove = conn.tblUserDatas.FirstOrDefault(x => x.UserDataID == managerToDelete.UserDataID);
                        conn.tblManagers.Remove(managerToDelete);
                        conn.tblUserDatas.Remove(userDataToRemove);
                        conn.SaveChanges();
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

        public bool TryUpdateAdministrator(int administratorID, tblAdministrator administrator)
        {
            try
            {
                using (var conn = new CompanyManagementEntities())
                {
                    var adminToUpdate = conn.tblAdministrators.FirstOrDefault(x => x.AdministratorID == administratorID);
                    if (adminToUpdate != null)
                    {
                        adminToUpdate.AdministratorTeam = administrator.AdministratorTeam;
                        adminToUpdate.ExpirationAccountDate = administrator.ExpirationAccountDate;

                        conn.SaveChanges();
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

        public bool TryUpdateEmployee(int employeeID, tblEmployee employee)
        {
            try
            {
                using (var conn = new CompanyManagementEntities())
                {
                    var employeeToUpdate = conn.tblEmployees.FirstOrDefault(x => x.EmployeeID == employeeID);
                    if(employeeToUpdate != null)
                    {
                        employeeToUpdate.Position = employee.Position;
                        employeeToUpdate.ProfessionalQualificationsLevel = employee.ProfessionalQualificationsLevel;
                        employeeToUpdate.Salary = employee.Salary;
                        employeeToUpdate.SectorID = employee.SectorID;
                        employeeToUpdate.YearsOfService = employee.YearsOfService;
                        conn.SaveChanges();
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

        public bool TryUpdateManager(int managerID, tblManager manager)
        {
            try
            {
                using (var conn = new CompanyManagementEntities())
                {
                    var managerToUpdate = conn.tblManagers.FirstOrDefault(x => x.ManagerID == managerID);
                    if(managerToUpdate != null)
                    {
                        managerToUpdate.LevelOfResponsibility = manager.LevelOfResponsibility;
                        managerToUpdate.OfficeNumber = manager.OfficeNumber;
                        managerToUpdate.PasswordHint = manager.PasswordHint;
                        managerToUpdate.ProjectsCount = manager.ProjectsCount;
                        managerToUpdate.Salary = manager.Salary;

                        conn.SaveChanges();
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

        public bool TryUpdateUserData(int userDataID, tblUserData userData)
        {
            try
            {
                using (var conn = new CompanyManagementEntities())
                {
                    var userDataToUpdate = conn.tblUserDatas.FirstOrDefault(x => x.UserDataID == userDataID);
                    if (userDataToUpdate != null)
                    {
                        userDataToUpdate.Username = userData.Username;
                        userDataToUpdate.GivenName = userData.GivenName;
                        userDataToUpdate.MaritalStatus = userData.MaritalStatus;
                        userDataToUpdate.PersonalNo = userData.PersonalNo;
                        userDataToUpdate.PlaceOfResidence = userData.PlaceOfResidence;
                        userDataToUpdate.Sex = userData.Sex;
                        userDataToUpdate.Surname = userData.Surname;
                       
                        conn.SaveChanges();
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

        public bool TryAddNewEmployee(tblManager manager)
        {
            throw new NotImplementedException();
        }
    }
}
