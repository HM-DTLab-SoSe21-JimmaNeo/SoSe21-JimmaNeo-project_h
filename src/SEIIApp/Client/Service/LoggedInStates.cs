using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Client.Service
{
    public enum _userStatus
    {
        LOGGED_OUT,
        LOGGED_IN,
        REGISTRATION,
        REGISTRATION_SUCCESSFUL
    }

    public class LoggedInStates {

        public _userStatus CurrentState { get; set; } = _userStatus.LOGGED_OUT;

        public SEIIApp.Shared.DomainTdo.ProfilDefinitionDto Profile { get; set; }
    }
}
