using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LDW.Domain.Common
{
    public class ServiceBase
    {
        [DebuggerStepThrough]
        public async Task<OperationResult<T>> Result<T>(Func<Task<T>> func)
        {
            try
            {
                var result = await func.Invoke();
                return new OperationResult<T>(result);
            }
            catch (Exception ex)
            {
                return new OperationResult<T>(ex);
            }
        }

        [DebuggerStepThrough]
        public async Task<OperationResult> Result(Func<Task> func)
        {
            try
            {
                await func.Invoke();
                return new OperationResult(true);
            }
            catch (Exception ex)
            {
                return new OperationResult(ex);
            }
        }

        [DebuggerStepThrough]
        public OperationResult Result(Action action)
        {
            try
            {
                action.Invoke();
                return new OperationResult(true);
            }
            catch (Exception ex)
            {
                return new OperationResult(ex);
            }
        }
    }
}
