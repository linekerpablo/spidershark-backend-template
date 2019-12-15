namespace SpiderShark.Domain.Dto
{
    public sealed class Error
    {
        protected string Code { get; private set; }
        protected string Description { get; private set; }

        public static Error Create(string code, string description) => new Error
        {
            Code = code,
            Description = description
        };
    }
}
