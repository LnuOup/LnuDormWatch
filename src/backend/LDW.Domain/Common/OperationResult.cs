using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LDW.Domain.Common
{
    public class OperationResult
    {
        public bool IsSuccess { get; set; }
        public Exception Exception { get; set; }

        public OperationResult(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public OperationResult(Exception ex)
        {
            Exception = ex;
            IsSuccess = false;
        }
    }

    [DebuggerStepThrough]
    public class OperationResult<T> : OperationResult
    {
        public T Value { get; set; }

        public OperationResult(T value) : this(true)
        {
            Value = value;
        }

        public OperationResult(bool isSuccess) : base(isSuccess)
        {

        }

        public OperationResult(Exception ex) : base(ex)
        {

        }
    }
}
