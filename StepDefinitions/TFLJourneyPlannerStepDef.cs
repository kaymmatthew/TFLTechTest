using TFLTechTest.PageObject;

namespace TFLTechTest.StepDefinitions
{
    [Binding]
    public sealed class TFLJourneyPlannerStepDef
    {
        ScenarioContext _scenarioContext;
        TFLHomePage tFLHomePage;
        public TFLJourneyPlannerStepDef(IObjectContainer _container)
        {
            _scenarioContext = _container.Resolve<ScenarioContext>();
            tFLHomePage = _container.Resolve<TFLHomePage>();
        }

        [Given(@"User is on tfl\.gov\.uk home page")]
        public void GivenIAmTfl_Gov_UkHomePage() => tFLHomePage.navigateToSite();

        [Given(@"User click on accept all cookies")]
        public void GivenUserClickOnAcceptAllCookies() => tFLHomePage.AcceptCookies();

        [Given(@"User click on done Your cookie settings are saved")]
        public void GivenUserClickOnDone() => tFLHomePage.ClickCookieDone();

        [When(@"User enter valid location details")]
        public void WhenIEnterValidLocationAsFollows(Table table)
        {
            dynamic enterDetails = table.CreateDynamicInstance();
            tFLHomePage.validLocationDetails(enterDetails.fromLocation, enterDetails.toLocation);
        }

        [When(@"User click on plan my journey btn")]
        public void WhenUserClickOnPlanMyJourneyBtn() => tFLHomePage.clickPlanMyJourneyBtn();

        [Then(@"User is presented with the '(.*)'")]
        public void UserIsPresentedWithTheJourneyResults(string expectedValue)
        {
            var actualValue = tFLHomePage.getJourneyResultHeaderText();
            Assert.AreEqual(expectedValue, actualValue);
        }

        [When(@"User enter invalid location details")]
        public void WhenUserEnterInvalidLocationDetails(Table table)
        {
            dynamic enterDetails = table.CreateDynamicInstance();
            tFLHomePage.invalidLocationDetails(enterDetails.invalidFromLocation, enterDetails.invalidToLocation);
        }

        [Then(@"User is presented with error Message '(.*)'")]
        public void UserIsPresentedWithErrorMessage(string expectedErrorMessage)
        {
            var actualErrorMessage = tFLHomePage.getErrorMessageDisplayed();
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
        }

        [When(@"User enter empty location as details")]
        public void WhenUserEnterEmptyLocationAsDetails(Table table)
        {
            dynamic enterDetails = table.CreateDynamicInstance();
            tFLHomePage.emptyLocationAsDetails(enterDetails.emptyFromLocation, enterDetails.emptyToLocation);
        }

        [Then(@"Error Messages displayed on From and To text field")]
        public void TErrorMessagesDisplayed(Table table)
        {
            dynamic errorterDetails = table.CreateDynamicInstance();
            Assert.Multiple(() =>
            {
                Assert.AreEqual(errorterDetails.From, tFLHomePage.getFromErrorMessage());
                Assert.AreEqual(errorterDetails.To, tFLHomePage.geToErrorMessage());
            });
        }

        [When(@"User click on change time LinkText")]
        public void WhenUserClickOnChangeTimeLinkText() => tFLHomePage.clickChangeTime();

        [When(@"User verify that (.*) is displayed")]
        public void WhenUserVerifyThatArrivingIsDisplayed(string expected)
        {
            var actual = tFLHomePage.arrivingTimeDisplayed();
            Assert.AreEqual(expected, actual);
        }

        [When(@"User click on Arriving")]
        public void WhenUserClickOnArriving() => tFLHomePage.clickArrivingTime();

        [Then(@"User is presented with the Arriving Journey time")]
        public void UserIsPresentedWithArrivingJourneyTime()
        {
            var arrivingTimeDetails = tFLHomePage.IsArrivingTimeDisplayed();
            Assert.IsTrue(tFLHomePage.IsArrivingTimeDisplayed().Equals(arrivingTimeDetails));
        }

        [When(@"User click on Edit Journey")]
        public void WhenUserClickOnEditJourney() => tFLHomePage.clickEdithJourney();

        [When(@"User enter (.*) as To to update journey")]
        public void WhenUserEnterBrentfordAsToToUpdateJourney(string value) => tFLHomePage.enterEnterToEdith(value);

        [When(@"User click on updateJourney button")]
        public void WhenUserClickOnUpdateJourneyButton() => tFLHomePage.clickUpdateJourneyBtn();

        [Then(@"User is presented with updated journey result")]
        public void UserIsPresentedWithUpdatedJourneyResult()
        {
            var upadatedJourneyDetails = tFLHomePage.IsArrivingTimeDisplayed();
            Assert.IsTrue(tFLHomePage.IsArrivingTimeDisplayed().Equals(upadatedJourneyDetails));
        }

        //[When(@"User click on '([^']*)' tab")]
        //public void WhenUserEnterClickOnTab(string recents) => tFLHomePage.clickRecentTab();

        //[When(@"User click on plan a journey btn on the menu bar")]
        //public void WhenUserClickOnPlanAJourneyOnAMenuBar() => tFLHomePage.clickPlanAJourneyBtn();

        //[Then(@"The list of recently planned journeys contains the following:")]
        //public void ListOfRecentlyPlannedJourneysContains(Table table)
        //{
        //    dynamic recentJourneyContains = table.CreateDynamicInstance();
        //    Assert.AreEqual(recentJourneyContains.MessageDisplayed, tFLHomePage.recentJourneyDetails());
        //}
    }
}