using System;

namespace IR.Core.Common
{
    internal sealed class WorkflowAbortException: Exception
    {
        public WorkflowAbortException(string msg): base(msg) { }
        public WorkflowAbortException(string msg, Exception innerException) : base(msg, innerException) { }
    }
}
