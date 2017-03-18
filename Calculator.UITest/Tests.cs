using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Calculator.UITest
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
            app.Repl();
        }

        [Test]
        public void SimpleCalculation()
        {
            app.Tap(x => x.Text("9"));
            app.Screenshot("9 entered");
            app.Tap(x => x.Text("+"));
            app.Tap(x => x.Text("1"));
            app.Screenshot("1 entered");
            app.Tap(x => x.Text("="));

            app.WaitForElement(x => x.Class("FormsTextView").Text("10"));
            app.Screenshot("Result shown");
        }
    }
}

