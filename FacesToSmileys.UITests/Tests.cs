using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace FacesToSmileys.UITests
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
        public void TakeAPictureButton_Portait_IsDisplayed()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Take a picture"));
            Assert.IsTrue(results.Any());
            app.Screenshot("Take a picture button in portrait mode");
        }

        [Test]
        public void TakeAPictureButton_Landscape_IsDisplayed()
        {
            app.SetOrientationLandscape();
            AppResult[] results = app.WaitForElement(c => c.Marked("Take a picture"));
            Assert.IsTrue(results.Any());
            app.Screenshot("Take a picture button in landscape mode");
        }

        [Test]
        public void Camera_IsDiplayed()
        {
            app.Tap(c => c.Marked("Take a picture"));
            app.Screenshot("Camera");
        }

        [Test]
        public void Camera_TapToTakeAPicture()
        {
            app.Tap(c => c.Marked("Take a picture"));
            app.TapCoordinates(300, 1195);
            AppResult[] results = app.WaitForElement(c => c.Marked("Take a picture"));
            Assert.IsTrue(results.Any());
            app.Screenshot("Displaying analyzed picture");

        }



    }
}
