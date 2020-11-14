using System;
using System.Collections.Generic;
using System.Text;

namespace LDW.Domain.Constants
{
    public static class ValidationConstants
    {

        public const string EmailRegex = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

        public const int PasswordMinLength = 8;
        public const int PasswordMaxLength = 64;

    }
}
