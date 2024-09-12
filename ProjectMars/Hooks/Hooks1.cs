using ProjectMars.Utilities;
using TechTalk.SpecFlow;

namespace ProjectMars.Hooks
{
    [Binding]
    public sealed class Hooks1:CommonDriver
    {
    

        [BeforeScenario]
        public void BeforeScenario()
        {

            Initialize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Close();
        }
    }
}