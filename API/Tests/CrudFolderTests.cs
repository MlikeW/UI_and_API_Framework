using System;
using System.Collections.Generic;
using API.Endpoints;
using NUnit.Framework;
using System.Linq;
using System.Threading;

namespace API.Tests
{
    [TestFixture]
    internal class CrudFolderTests : BaseTest
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
            Thread.Sleep(1000);
            Assert.IsFalse(_user.GetAllFolders()
                .Any(folder => folder.name.Equals(_folderName)));
        }

        [Test]
        public void CreateAndDeleteFolder()
        {
            _user.CreateFolder(_folderName);
            Assert.IsTrue(_user.GetAllFolders()
                .Any(folder => folder.name.Equals(_folderName)));
            _folder.DeleteCurrentFolder(_user.GetCurrentUserInfo().login, _folderName);
            Thread.Sleep(1000);
            Assert.IsFalse(_user.GetAllFolders()
                .Any(folder => folder.name.Equals(_folderName)));
        }
    }
}