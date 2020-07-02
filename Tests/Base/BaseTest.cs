using System;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace Tests.Base
{
    internal abstract class BaseTest
    {
        //todo: Context
        private const string Type = " Suite";
        protected readonly Stopwatch TestStopwatch = new Stopwatch();
        protected readonly Stopwatch TestSuiteStopwatch = new Stopwatch();

        protected string Name => TestContext.CurrentContext.Test.FullName.Split('.').Last();
        protected string Result => TestContext.CurrentContext.Result.Outcome.Status.ToString();

        [OneTimeSetUp]
        public void SetUpTestSuite()
            => StartTimer(TestSuiteStopwatch, Type);

        [OneTimeTearDown]
        public void TearDownTestSuite()
            => StopTimer(TestSuiteStopwatch, Type);

        [SetUp]
        public void SetUp() => StartTimer(TestStopwatch);

        [TearDown]
        public void TearDown() => StopTimer(TestStopwatch);

        private void StartTimer(Stopwatch sw, string type = "")
        {
            sw.Reset();
            Console.WriteLine($"Test{type} '{Name}' is running...");
            sw.Start();
        }

        private void StopTimer(Stopwatch sw, string type = "")
        {
            sw.Stop();
            Console.WriteLine($"Test{type} '{Name}' done in {sw.ElapsedMilliseconds} ms.\nResult: {Result}");
        }
    }
}