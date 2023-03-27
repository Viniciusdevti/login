namespace Login.Domain
{
    public class User 
    {
        public User(string email, string name, string password)
        {
            Email = email;
            Name = name;
            Password = password;
        }

        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}