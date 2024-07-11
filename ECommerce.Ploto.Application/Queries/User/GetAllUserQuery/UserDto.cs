namespace ECommerce.Ploto.Application.Queries.User.GetAllUserQuery
{
    public class UserDto
    {
        public string FullName { get;  set; }
        public string PhoneNumber { get;  set; }
        public string HomeNumber { get;  set; }
        public string Address { get;  set; }
        public string[]? Roles { get; set; }

    }
}
