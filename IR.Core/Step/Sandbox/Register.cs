using IR.Core.Common;

namespace IR.Core.Step.Sandbox
{
    internal sealed class Register: ApiMethodAsync<object, object>
    {
        protected override string Method => "sandbox/register";

        protected override EApiMethodType MethodType => EApiMethodType.POST;

        public Register(ApiProxy proxy) : base(proxy) { }
    }
}
