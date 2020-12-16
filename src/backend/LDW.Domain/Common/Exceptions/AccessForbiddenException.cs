using System;
using System.Collections.Generic;
using System.Text;

namespace LDW.Domain.Common.Exceptions
{
	public class AccessForbiddenException : Exception	
	{
		public AccessForbiddenException(string exceptionMessage)
			: base(exceptionMessage)
		{
		}

		public AccessForbiddenException(string entityName, object key) 
			: base($"Access to entity '{entityName}' ({key}) is forbidden.")
		{
		}
	}
}
