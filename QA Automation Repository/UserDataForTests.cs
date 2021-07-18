namespace Task13
{
    class UserDataForTests
    {
        public static string UserCorrectLogin { get; set; } = "epamfake1@gmail.com";

        public static string UserIncorrectLogin { get; set; } = "epamfake";

        public static string UserCorrectPassword { get; set; } = "fakepassword1";

        public static string UserIncorrectPassword { get; set; } = "fakepassword";

        public static string UserMessage { get; set; } = "Hello epamfake2@mail.ru";

        public static string Destination { get; set; } = "epamfake2@mail.ru";

        public static string DestinationPassword { get; set; } = "fakepassword2";
    }
}
