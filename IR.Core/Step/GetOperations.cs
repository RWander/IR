using IR.Core.Common;

namespace IR.Core.Step
{
    internal sealed class GetOperations : ApiMethodAsync<object, Payload>
    {
        protected override string Method => "operations";

        protected override EApiMethodType MethodType => EApiMethodType.GET;

        protected override bool EmptyResponsePayload { get; } = true; // TODO: false

        public GetOperations(ApiProxy proxy) : base(proxy) { }
    }
}
