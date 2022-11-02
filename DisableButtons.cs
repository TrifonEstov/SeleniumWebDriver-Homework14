using OpenQA.Selenium;
using WebDriverWebElement;

namespace Homework14
{
    public class ButtonsState : BaseTest
    {
        [Test]
        [Description("Validate buttons get disabled after clearing info from input fields")]
        public void DisableButtons()
        {
            IWebElement firstName = Driver.FindElement(By.Id("fname"));
            firstName.SendKeys("Anna");

            IWebElement lastName = Driver.FindElement(By.Id("lname"));
            lastName.SendKeys("Smith");

            IWebElement submitButton = Driver.FindElement(By.Id("submit"));
            IWebElement clearButton = Driver.FindElement(By.Id("clear"));
            Driver.FindElement(By.TagName("body")).Click(); //focus
            Assert.IsTrue(submitButton.Enabled);
            Assert.IsTrue(clearButton.Enabled);

            firstName.Clear();
            Assert.IsFalse(submitButton.Enabled);
            Assert.IsTrue(clearButton.Enabled);

            lastName.Clear();
            Assert.IsFalse(submitButton.Enabled);
            Assert.IsFalse(clearButton.Enabled);
        }
    }
}