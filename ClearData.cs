using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverWebElement
{
    public class ClearData : BaseTest
    {
        [Test]
        [Description("Clear already populated user info using the button")]

        public void ClearUserInfo()
        {
            IWebElement firstName = Driver.FindElement(By.Id("fname"));
            firstName.SendKeys("Anna");

            IWebElement lastName = Driver.FindElement(By.Id("lname"));
            lastName.SendKeys("Smith");

            IWebElement femaleRadioButton = Driver.FindElement(By.CssSelector("input[id='female']"));
            femaleRadioButton.Click();

            List<IWebElement> checkBoxes = Driver.FindElements(By.Name("checkBox")).ToList();

            foreach (var chB in checkBoxes)
            {
                string checkBoxValue = chB.GetAttribute("value");
                if ( checkBoxValue == "HTML" || checkBoxValue == "CSS" || checkBoxValue == "JavaScript")
                {
                    chB.Click();
                }
            }

            IWebElement clearButton = Driver.FindElement(By.Id("clear"));
            clearButton.Click();

            IWebElement firstNameFieldAfterClear = Driver.FindElement(By.Id("fname"));
            string firstNameFieldAfterClearValue = firstNameFieldAfterClear.GetAttribute("value");

            IWebElement lastNameFieldAfterClear = Driver.FindElement(By.Id("lname"));
            string lastNameFieldAfterClearValue = lastNameFieldAfterClear.GetAttribute("value");

            Assert.That(firstNameFieldAfterClearValue, Is.EqualTo(""));
            Assert.That(lastNameFieldAfterClearValue, Is.EqualTo(""));

            IWebElement maleRadioInput = Driver.FindElement(By.CssSelector("input[id='male']"));
            Assert.IsTrue(maleRadioInput.Selected);

            List<IWebElement> checkBoxesAfterClear = Driver.FindElements(By.Name("checkBox")).ToList();

            foreach (var checkbox in checkBoxesAfterClear)
            {
                Assert.IsFalse(checkbox.Selected);
            }

            IWebElement submitButtongAfterClear = Driver.FindElement(By.Id("submit"));
            IWebElement clearButtongAfterClear = Driver.FindElement(By.Id("clear"));
            Assert.IsFalse(submitButtongAfterClear.Enabled);
            Assert.IsFalse(clearButtongAfterClear.Enabled);

        }

        [Test]
        [Description("Clear already populated user info via page refresh")]

        public void RefreshPage()
        {
            IWebElement firstName = Driver.FindElement(By.Id("fname"));
            firstName.SendKeys("Anna");

            IWebElement lastName = Driver.FindElement(By.Id("lname"));
            lastName.SendKeys("Smith");

            IWebElement femaleRadioButton = Driver.FindElement(By.CssSelector("input[id='female']"));
            femaleRadioButton.Click();

            List<IWebElement> checkBoxes = Driver.FindElements(By.Name("checkBox")).ToList();

            foreach (var chB in checkBoxes)
            {
                string checkBoxValue = chB.GetAttribute("value");
                if (checkBoxValue == "HTML" || checkBoxValue == "CSS" || checkBoxValue == "JavaScript")
                {
                    chB.Click();
                }
            }

            Driver.Navigate().Refresh();
            
            IWebElement firstNameFieldAfterRefresh = Driver.FindElement(By.Id("fname"));
            string firstNameFieldAfterRefreshValue = firstNameFieldAfterRefresh.GetAttribute("value");

            IWebElement lastNameFieldAfterRefresh = Driver.FindElement(By.Id("lname"));
            string lastNameFieldAfterRefreshValue = lastNameFieldAfterRefresh.GetAttribute("value");

            Assert.That(firstNameFieldAfterRefreshValue, Is.EqualTo(""));
            Assert.That(lastNameFieldAfterRefreshValue, Is.EqualTo(""));

            IWebElement maleRadioInput = Driver.FindElement(By.CssSelector("input[id='male']"));
            Assert.IsTrue(maleRadioInput.Selected);

            List<IWebElement> checkBoxesAfterRefresh = Driver.FindElements(By.Name("checkBox")).ToList();

            foreach (var checkbox in checkBoxesAfterRefresh)
            {
                Assert.IsFalse(checkbox.Selected);
            }

            IWebElement submitButtongAfterRefresh = Driver.FindElement(By.Id("submit"));
            IWebElement clearButtongAfterRefresh = Driver.FindElement(By.Id("clear"));
            Assert.IsFalse(submitButtongAfterRefresh.Enabled);
            Assert.IsFalse(clearButtongAfterRefresh.Enabled);
        }

    }
}
