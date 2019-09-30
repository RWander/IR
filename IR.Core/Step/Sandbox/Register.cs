using IR.Core.Common;

namespace IR.Core.Step.Sandbox
{
    internal sealed class Register: ApiMethodAsync
    {
        public override string Method => "sandbox/register";

        public override EApiMethodType MethodType => EApiMethodType.POST;

        public Register(ApiProxy proxy) : base(proxy) { }
    }
}
