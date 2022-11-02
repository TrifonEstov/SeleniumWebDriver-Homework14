using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverWebElement;

namespace Homework14
{
    internal class ButtonPosition : BaseTest
    {
        [Test]
        [Description("Validate that male radio button is located left of the female")]

        public void MaleButtonPosition()
        {
            IWebElement maleRadioButton = Driver.FindElement(By.CssSelector("input[id='male']"));
            IWebElement femaleRadioButton = Driver.FindElement(RelativeBy.WithLocator(By.CssSelector("input[id='female']")).RightOf(maleRadioButton));
            Assert.That(femaleRadioButton.GetAttribute("value"), Is.EqualTo("Female"));
        }

        [Test]

        public void UniqueElement()
        {
            List<IWebElement> elements = Driver.FindElements(By.CssSelector("button[onclick='submitData()']")).ToList();
            Assert.That(elements.Count(), Is.EqualTo(1));
        }
    }
}
