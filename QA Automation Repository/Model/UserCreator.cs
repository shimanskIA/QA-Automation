using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;
using TestProject.Utils;

namespace TestProject.Model
{
    public class UserCreator
    {
        private static readonly string _pathToRootDirectory = @"..\..\..\";


        public static User CreateUser(string login)
        {
            return new User(login);
        }

        public static User CreateUser()
        {
            XmlSerializer reader = new XmlSerializer(typeof(User));
            string fileName = TestContext.Parameters["UserData"];
            string filePath = _pathToRootDirectory + fileName;

            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                try
                {
                    User user = (User)reader.Deserialize(fileStream);
                    LoggerWrapper.LogInfo($"User data was successfully read from file {fileName}");
                    return user;
                }
                catch
                {
                    LoggerWrapper.LogError($"{fileName}: unable to read user data from this file.");
                    throw;
                }
            }
        }

    }
}
