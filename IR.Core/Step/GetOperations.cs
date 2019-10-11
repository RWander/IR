using IR.Core.Common;

namespace IR.Core.Step
{
    internal sealed class GetOperations : RestMethodAsync<object, Payload>
    {
        protected override string Method => "operations";

        protected override ERestMethodType MethodType => ERestMethodType.GET;

        protected override bool EmptyResponsePayload { get; } = true; // TODO: false

        public GetOperations(RestProxy proxy) : base(proxy) { }
    }
}
