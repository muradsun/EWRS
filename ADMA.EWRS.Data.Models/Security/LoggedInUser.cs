using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Models.Security
{
    public class LoggedInUser
    {
        int _userId;
        string _eMail;
        string _givenName;
        string _gender;
        List<string> _permissionsSet;
        List<string> _groupSet;
        List<int> _delegationSet;


        public LoggedInUser(int userId, string eMail, string givenName, string gender,
                              List<string> permissionsSet, List<string> groupSet, List<int> delegationSet)
        {
            _userId = userId;
            _eMail = eMail;
            _givenName = givenName;
            _gender = gender;
            _permissionsSet = permissionsSet;
            _groupSet = groupSet;
            _delegationSet = delegationSet;
        }

        public int UserId { get { return _userId; } }
        public string EMail { get { return _eMail; } }
        public string GivenName { get { return _givenName; } }
        public string Gender { get { return _gender; } }
        public List<string> PermissionsSet { get { return _permissionsSet; } }
        public List<string> GroupSet { get { return _groupSet; } }
        public List<int> DelegationSet { get { return _delegationSet; } }

    }
}
