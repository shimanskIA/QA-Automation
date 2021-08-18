namespace TestProject.Model
{
    public class User
    {
        public string Login { get; set; }

        public User(string login)
        {
            Login = login;
        }

        public User()
        {

        }
    }
}
