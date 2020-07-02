using API.Endpoints;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
using Tests.Base;

namespace Tests.API
{
    [TestFixture]
    internal class CrudFolderTests : BaseApiTest
    {
        private readonly string _folderName = $"TestFolder{Guid.NewGuid()}";
        private readonly User _user = new User(Send);
        private readonly Folder _folder = new Folder(Send);

        [Test]
        public void CheckLoginOfTheCurrentUser()
        {
            var user = _user.GetCurrentUserInfo();
            Assert.AreEqual(user.login, "MlikeW");
        }

        [Test]
        public void CheckNameOfTheCurrentUser()
        {
            var user = _user.GetCurrentUserInfo();
            Assert.AreEqual(user.name, "Marina");
        }

        [Test]
        public void CreateFolder()
        {
            _user.CreateFolder(_folderName);
            Assert.IsTrue(_user.GetAllFolders()
                .Any(folder => folder.name.Equals(_folderName)));
        }

        [Test]
        public void DeleteFolder()
        {
            _user.CreateFolder(_folderName);
            _folder.DeleteCurrentFolder(_user.GetCurrentUserInfo().login, _folderName);
            Thread.Sleep(1000);//avoid (try catch)
            Assert.IsFalse(_user.GetAllFolders()
                .Any(folder => folder.name.Equals(_folderName)));
        }
    }
}