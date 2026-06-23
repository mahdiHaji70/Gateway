namespace TDM.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        public string? UserId { get; }
        public string? NationalId { get; }
        public string? Email { get; }
        public string? FirstName { get; }
        public bool IsAuthenticated { get; }
    }
}
