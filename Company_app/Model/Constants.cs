using Validations;

namespace Company_app.Model
{
    class Constants
    {
        private const string passwordMaster = "WPFAccess";
        internal const string usernamedMaster = "WPFMaster";
        internal readonly string passwordEmployeeHashed = SecurePasswordHasher.Hash(passwordMaster);
    }
}
