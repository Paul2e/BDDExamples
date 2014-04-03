using System;
using TechTalk.SpecFlow;
using AUTOpilot.WAUI;
using AUTOpilot.SystemCtrl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Automation;
using System.Diagnostics;

namespace CalculatorTest.StepDefinitions
{
    [Binding]
    public class CalculatorSteps
    {
        public static Process calculatorProcess;

        [Scope(Feature="Calculator")]
        [BeforeFeature()]
        public static void OpenCalculator()
        {
            string strCalcDirectory = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86) + @"\calc.exe";
            calculatorProcess = new Process();
            calculatorProcess = Application.StartApplication(strCalcDirectory);
        }

        [Scope(Feature = "Calculator")]
        [AfterFeature()]
        public static void CloseCalculator()
        {
            calculatorProcess.Kill();
        }

        [Scope(Feature = "Calculator")]
        [BeforeScenario()]
        public void SetupCalculator()
        {
            Scope.ApplicationScope = Application.Find.ByName("Calculator");

            Button btnReset = new Button(Button.Find.byAutomationId(Scope.ApplicationScope,"81"));
            btnReset.ClickButton();
        }

        [Given(@"I have entered (.*)")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            char [] number = p0.ToString().ToCharArray();

            foreach (char c in number)
            {
                Button btnNumber = new Button(Button.Find.byName(c.ToString()));

                btnNumber.ClickButton();
            }
        }
        
        [Given(@"an addition is required")]
        public void GivenIPressAdd()
        {
            Button btnAdd = new Button(Button.Find.byAutomationId(Scope.ApplicationScope,"93"));
            btnAdd.ClickButton();
        }

        [Given(@"a deduction is required")]
        public void GivenADeductionIsRequired()
        {
            Button btnMinus = new Button(Button.Find.byAutomationId(Scope.ApplicationScope, "94"));
            btnMinus.ClickButton();
        }

        [Given(@"a multiplication is required")]
        public void GivenAMultiplicationIsRequired()
        {
            Button btnMultiply = new Button(Button.Find.byAutomationId(Scope.ApplicationScope, "92"));
            btnMultiply.ClickButton();
        }
                
        [When(@"total is calculated")]
        public void WhenIPressEnter()
        {
            Button btnEquals = new Button(Button.Find.byAutomationId(Scope.ApplicationScope, "121"));
            btnEquals.ClickButton();
        }
        
        [Then(@"the result will be (.*)")]
        public void ThenTheResultWillBe(int p0)
        {
            string expectedResult = p0.ToString();
            TextBox txtResult = new TextBox(TextBox.Find.byAutomationId(Scope.ApplicationScope, "158"));

            string strResult = txtResult.Properties.Name.ToString();

            Assert.AreEqual(expectedResult, strResult);
        }
    }
}
