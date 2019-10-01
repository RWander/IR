using IR.Core.Common;

namespace IR.Core.Step
{
    internal sealed class GetOperations : ApiMethodAsync
    {
        protected override string Method => "operations";

        protected override EApiMethodType MethodType => EApiMethodType.GET;

        public GetOperations(ApiProxy proxy) : base(proxy) { }
    }
}
