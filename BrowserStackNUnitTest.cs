
using NUnit.Framework;
using System;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using qw.Page;
using System.Collections.Generic;
using LumenWorks.Framework.IO.Csv;
using System.IO;
using NUnit.Framework.Internal;



namespace qw
{

	[TestFixture]
	public class BrowserStackNUnitTest
	{
		Uri uri = new Uri("http://localhost:4723/wd/hub");
		private static TimeSpan INIT_TIMEOUT_SEC = TimeSpan.FromSeconds(180);

		protected AndroidDriver<AndroidElement> driver;
		protected AppiumOptions options;
		private LoginAndRegistration loginAndRegistration;


		private static IEnumerable<String[]> GetDataFromCSV()
        {
			using (var csv = new CsvReader(new StreamReader("data.csv"), true))
            {
				while (csv.ReadNextRecord())
				{
					String username = csv[0];
					String password = csv[1];
					String invalidUsername = csv[2];
					String invalidPassword = csv[3];
					yield return new String[] { username, password, invalidUsername, invalidPassword };
				}
			}


		}
		[SetUp]
		public void Init()
		{

			options = new AppiumOptions();
			options.AddAdditionalCapability("deviceName", "Pixel 4");
			options.AddAdditionalCapability("platformName", "Android");
			options.AddAdditionalCapability("app", "/Users/natalia/ApkProjects/app-debug/app-debug.apk");



			driver = new AndroidDriver<AndroidElement>(uri, options, INIT_TIMEOUT_SEC);

			loginAndRegistration = new LoginAndRegistration(driver);
		}



        [Test, TestCaseSource("GetDataFromCSV")]
		public void InvalidData(string invalidUsername, string invalidPassword)
		{
			loginAndRegistration.EnterUserName(invalidUsername).ClickUserName();

			Assert.AreEqual("not a valid username", loginAndRegistration.GetPopUpEmail().ToLower());

			loginAndRegistration.EnterPassword(invalidPassword);
			Assert.AreEqual("password must be >5 characters", loginAndRegistration.GetPopPassword().ToLower());

			Assert.AreEqual(false, loginAndRegistration.LoginOrRegisterButtonIsActive());

		}





			[Test, TestCaseSource("GetDataFromCSV")]
			public void ValidImput(string username, string password)
			{
				loginAndRegistration.EnterUserName(username)
					.EnterPassword(Environment.GetEnvironmentVariable(password));

				Assert.AreEqual(true, loginAndRegistration.LoginOrRegisterButtonIsActive());

				loginAndRegistration.ClickLoginOrRegisterButton();

			}

		}
	} 
