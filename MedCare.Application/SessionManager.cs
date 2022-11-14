using MedCare.Application.Enums;
using MedCare.Application.Exceptions;
using MedCare.Commons.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.Application
{
    public static class SessionManager
    {
        private static SessionType _sessionType;

        public static SessionType SessionType
        {
            get { return _sessionType; }
            set 
            {
                if (_sessionType == SessionType.NULL)
                {
                    _sessionType = value;
                    return;
                }
                throw new SessionHasAlreadyBeenInitialized("You can not change the session props value at runtime!");
            }
        }

        private static AbstractUser _user;

        public static AbstractUser User
        {
            get { return _user; }
            set
            {
                if (_user == null)
                {
                    _user = value;
                    return;
                }
                throw new SessionHasAlreadyBeenInitialized("You can not change the session props value at runtime!");
            }
        }
    }
}
