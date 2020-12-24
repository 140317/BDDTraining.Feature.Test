using System;
using TechTalk.SpecFlow;
using Xunit;

namespace BDDTraining.Feature.Test.StepDefinitions
{
    [Binding]
    public class CalculatorSteps
    {
        private int num1;
        private int num2;
        private int total;
        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number1)
        {
            num1 = number1;
        }
        
        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number2)
        {
            num2 = number2;
        }
        
        [When(@"the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            //Action/Function
            total = num1 + num2;
        }
        
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int sum)
        {
            Assert.Equal(sum, total);
        }
    }
}
