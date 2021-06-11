using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.Core.Tools;
using FlaUI.UIA3;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace UIAutomation
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //var app = FlaUI.Core.Application.Launch(@"%ProgramFiles%\Windows NT\Accessories\wordpad.exe");
            using (var automation = new UIA3Automation())
            {
                var app = FlaUI.Core.Application.Launch(@"C:\WINDOWS\system32\notepad.exe");
                var window = app.GetMainWindow(automation);
                window.Title.Should().Be("Lab Notepad");

                var controls = window.FindAllDescendants();
                var plane = controls.Single(x => x.Name == "UIRibbonDockTop");
                var ribbon = plane.FindAllChildren();
                var elements = ribbon[0].FindAllChildren();
                app.Close();
                Retry.WhileException(() => app.ExitCode.Should().Be(0));
            }
        }

        [Test]
        public void Test2()
        {
            var app = FlaUI.Core.Application.Launch(@"C:\WINDOWS\system32\notepad.exe");
            var timeOut = TimeSpan.FromSeconds(20);
            Retry.DefaultTimeout = timeOut;
            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                window.Title.Should().Be("Без імені: Блокнот");
                var fileTab = window.FindAllByXPath("/MenuBar/MenuItem[1]")[0];
                fileTab.WaitUntilClickable();
                fileTab.Click();
                var openElement = window.FindAllDescendants().Single(x => x.Name == "Відкрити..." && x.ControlType == ControlType.MenuItem).AsMenuItem();
                openElement.WaitUntilClickable(timeOut);
                openElement.Invoke();
                Retry.WhileTrue(() => window.ModalWindows.Length == 1);
                var openFile = window.ModalWindows[0].AsWindow();
                openFile.Name.Should().Be("Відкриття");
                var edit = openFile.FindFirstChild("1148");
                
                edit.Click();
                Retry.WhileTrue(() => edit.FrameworkAutomationElement.HasKeyboardFocus);
                Keyboard.Type(@"C:\Users\111\Desktop\lab6.rtf");
                var fileOpen = openFile.FindFirstChild("1");
                fileOpen.WaitUntilClickable(timeOut);
                fileOpen.Click();

                Retry.WhileTrue(() => window.Title.Equals("lab6: Блокнот"));

                var editText = window.FindFirstChild("59648").AsTextBox();
                editText.Text.Should().Be("Automation\r");
                editText.Enter("New Text");
                fileTab.Click();
                var saveElement = window.FindAllDescendants().First(x => x.Name == "Save as" && x.ControlType == ControlType.SplitButton).AsMenuItem();
                saveElement.WaitUntilClickable(timeOut);
                saveElement.Invoke();
                Retry.WhileTrue(() => window.ModalWindows.Length == 1);
                var saveFile = window.ModalWindows[0].AsWindow();
                var dynamicPart = DateTime.Now.ToShortDateString().Replace("/", string.Empty);
                var path = $"C:\\Users\\melny\\Desktop\\Document12{dynamicPart}.txt";
                Keyboard.Type(path);
                var fileTypeDropDown = saveFile.FindAllDescendants(x => x.ByClassName("AppControlHost")).First(x => x.Name == "Save as type:").AsComboBox();
                fileTypeDropDown.Expand();
                fileTypeDropDown.Select("Tetx Document");
                saveFile.FindFirstChild("1").AsButton().Invoke();
                Retry.WhileTrue(() => window.Title.Equals($"Document12{dynamicPart} - WordPad"));
                Retry.WhileTrue(() => window.ModalWindows.Length == 1 && window.ModalWindows[0].Title == "WordPad" && window.ClassName == "#32770");
                var windowModalWarning = window.ModalWindows[0];
                var okButton = windowModalWarning.FindFirstChild("6").AsButton();
                okButton.Click();
                File.ReadAllText(path).Should().Be("New Text");
                app.Close();
                File.Delete(path);
            }
        }
    }
}
