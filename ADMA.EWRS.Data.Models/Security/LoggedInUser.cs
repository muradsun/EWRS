using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Models.Security
{
    public class LoggedInUser
    {
        private int _userId;
        private string _eMail;
        private string _givenName;
        private string _gender;
        private List<string> _permissionsSet;
        private List<string> _groupSet;
        private List<int> _delegationSet;
        private int _ORGANIZATION_ID;

        public LoggedInUser(int userId, string eMail, string givenName, string gender,
                              List<string> permissionsSet, List<string> groupSet, List<int> delegationSet, int ORGANIZATION_ID)
        {
            _userId = userId;
            _eMail = eMail;
            _givenName = givenName;
            _gender = gender;
            _permissionsSet = permissionsSet;
            _groupSet = groupSet;
            _delegationSet = delegationSet;
            _ORGANIZATION_ID = ORGANIZATION_ID;
        }

        public int UserId { get { return _userId; } }
        public string EMail { get { return _eMail; } }
        public string GivenName { get { return _givenName; } }
        public string Gender { get { return _gender; } }
        public int ORGANIZATION_ID { get { return _ORGANIZATION_ID; } }
        public List<string> PermissionsSet { get { return _permissionsSet; } }
        public List<string> GroupSet { get { return _groupSet; } }
        public List<int> DelegationSet { get { return _delegationSet; } }

    }
}
