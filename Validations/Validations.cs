using System;
using System.Collections.Generic;
using System.Globalization;

namespace Validations
{
    public class Validations
    {
        public bool IsValidPersonalNoFormat(string personalNoToCheck)
        {
            if (!IsDigitsOnly(personalNoToCheck) || personalNoToCheck.Length != 13 || !IsValidBirthdayInPersonalNo(personalNoToCheck))
                return false;
            return true;
        }

        public bool IsPersonalNoInDb(string personalNoToCheck, List<string> listOfPersonalNo)
        {
            return listOfPersonalNo.Contains(personalNoToCheck);
        }

        public bool IsDigitsOnly(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;

            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        private bool IsValidBirthdayInPersonalNo(string personalNoToCheck)
        {
            DateTime dateValue;
            string dateFromInput;
            if (personalNoToCheck[4] != '9' && personalNoToCheck[4] != '0')
                return false;
            if (personalNoToCheck[4] == '9')
                dateFromInput = "" + personalNoToCheck[2] + personalNoToCheck[3] + "/" + personalNoToCheck[0] + personalNoToCheck[1] + "/1" + personalNoToCheck[4] + personalNoToCheck[5] + personalNoToCheck[6] + " 00:00:00";
            else
                dateFromInput = "" + personalNoToCheck[2] + personalNoToCheck[3] + "/" + personalNoToCheck[0] + personalNoToCheck[1] + "/2" + personalNoToCheck[4] + personalNoToCheck[5] + personalNoToCheck[6] + " 00:00:00";
            var culture = CultureInfo.InvariantCulture;
            var styles = DateTimeStyles.None;
            if (!DateTime.TryParse(dateFromInput, culture, styles, out dateValue))
                return false;
            return true;
        }
    }
}
