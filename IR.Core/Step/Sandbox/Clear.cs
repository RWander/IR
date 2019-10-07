using IR.Core.Common;

namespace IR.Core.Step.Sandbox
{
    internal sealed class Clear: ApiMethodAsync<object>
    {
        protected override string Method => "sandbox/clear";

        protected override EApiMethodType MethodType => EApiMethodType.POST;

        public Clear(ApiProxy proxy) : base(proxy) { }
    }
}
