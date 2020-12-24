using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;

namespace BDDTraining.Feature.Test.Helper
{
    [Binding]
    class ReportHelper
    {
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        private readonly IObjectContainer objectContainer;
        private readonly FeatureContext featureContext;
        private  ScenarioContext scenarioContext;
        
        public ReportHelper(IObjectContainer _objectContainer, ScenarioContext _scenarioContext, FeatureContext _featureContext)
        {
            this.objectContainer = _objectContainer;
            this.scenarioContext = _scenarioContext;
            this.featureContext = _featureContext;
           

        }
        [BeforeTestRun]
        public static void InitializeReport()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            var reportPath = Path.Combine(@"C:\Users\ustdn18\source\repos\BDDTraining.Feature.Test\BDDTraining.Feature.Test", "Reports", "Index.html");
            var htmlreporter = new ExtentHtmlReporter(reportPath);
            htmlreporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            htmlreporter.Config.DocumentTitle = "Test Title";
            htmlreporter.Config.ReportName = "Automation Report";
            extent = new ExtentReports();
            extent.AttachReporter(htmlreporter);

        }
        [AfterTestRun]
        public static void AfterTestRun()
        {

            //Flush report once test completes
            extent.Flush();
        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            featureName = extent.CreateTest<AventStack.ExtentReports.Gherkin.Model.Feature>(featureContext.FeatureInfo.Title);
            Console.WriteLine("BeforeFeature");
        }
        [AfterStep]
        public void InsertReportingSteps(ScenarioContext scenarioContext)
        {
            
            this.scenarioContext = scenarioContext;
            ScenarioStepContext scenarioStepContext = scenarioContext.StepContext;
            var stepType = scenarioStepContext.StepInfo.StepDefinitionType.ToString();
          
           
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(scenarioStepContext.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(scenarioStepContext.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(scenarioStepContext.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(scenarioStepContext.StepInfo.Text);
            }
            else if (scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(scenarioStepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(scenarioStepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(scenarioStepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                }
                else if (stepType == "And")
                {
                    scenario.CreateNode<And>(scenarioStepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                }
            }
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Console.WriteLine("BeforeScenario");
            scenario = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

    }
}
