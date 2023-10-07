
namespace TFLTechTest.PageObject
{
    public class TFLHomePage
    {
        IWebDriver driver;
        public TFLHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement Cookiesbtn => driver.FindThisElement(By.XPath("//*[@class='cb-button cb-right'][.='Accept all cookies']"));
        //private IWebElement CookiesDonebtn => driver.FindThisElement(By.XPath("//*[@class='cb-button'][.='Done']"));
        private IWebElement CookiesDonebtn => driver.FindThisElement(By.Id("#CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));
        private IWebElement FromLocation => driver.FindThisElement(By.XPath("//*[@id='InputFrom']"));
        private IWebElement ToLocation => driver.FindThisElement(By.XPath("//*[@id='InputTo']"));
        private IWebElement PlanMyJourneyBtn => driver.FindThisElement(By.XPath("//*[@id='plan-journey-button']"));
        private IWebElement JourneyResultDisplayed => driver.FindThisElement(By.XPath("//*[@class=\"headline-container\"]"));
        private IWebElement ErrorMessageDisplayed => driver.FindThisElement(By.XPath("//*[@class='field-validation-error']"));
        private IWebElement FromErrorMessage => driver.FindThisElement(By.XPath
            ("//*[@class='field-validation-error'][.='The From field is required.']"));
        private IWebElement ToErrorMessage => driver.FindThisElement(By.XPath
           ("//*[@id=\"InputTo-error\"][.='The To field is required.']"));
        private IWebElement ChangeTime => driver.FindThisElement(By.XPath("//*[@class='change-departure-time']"));
        private IWebElement ArrivingTimeDisplayed => driver.FindThisElement(By.XPath("//*[@for='arriving']"));
        private IWebElement ArrivingTime => driver.FindThisElement(By.XPath("//*[@for='arriving']"));
        private IWebElement isArrivingDateTimeDisplayed => driver.FindThisElement(By.XPath("//*[@class='summary-row clearfix']"));
        private IWebElement EdithJourney => driver.FindThisElement(By.XPath("//*[@class='summary-row clearfix']//following::a[@class='edit-journey']"));
        private IWebElement EnterToEdith => driver.FindThisElement(By.XPath("//*[@id='InputTo']"));
        private IWebElement UpdateJourneyBtn => driver.FindThisElement(By.XPath("//*[@id=\"plan-journey-button\"]"));
        private IWebElement RecentTab => driver.FindThisElement(By.XPath("//*[@href='#jp-recent']"));
    



        public void clickUpdateJourneyBtn()
        {
            driver.WaitFor(3);
            UpdateJourneyBtn.Click();
        }
        public void enterEnterToEdith(string value)
        {
            EnterToEdith.Clear();
            EnterToEdith.EnterText(driver, value);
        }
        public void clickEdithJourney() => EdithJourney.Click();
        public void clickPlanMyJourneyBtn() => PlanMyJourneyBtn.Click(); 
        public void clickArrivingTime() => ArrivingTime.Click();
        public void clickChangeTime() => ChangeTime.Click();
        public string getErrorMessageDisplayed()
        {
            driver.MilliSec(500);
            return ErrorMessageDisplayed.Text;
        }
        public bool IsArrivingTimeDisplayed() => isArrivingDateTimeDisplayed.Displayed;
        public string getJourneyResultHeaderText() => JourneyResultDisplayed.Text;
        public string arrivingTimeDisplayed() => ArrivingTimeDisplayed.Text;
        public string getFromErrorMessage() => FromErrorMessage.Text;
        public string geToErrorMessage() => ToErrorMessage.Text;
        public void validLocationDetails(string fromLocation, string toLocation)
        {
            FromLocation.SendKeys(fromLocation);
            FromLocation.SendKeys(Keys.Tab);
            ToLocation.SendKeys(toLocation); 
            ToLocation.SendKeys(Keys.Tab);
        }
        public void invalidLocationDetails(string invalidFromLocation, string invalidToLocation)
        {
            Actions action = new Actions(driver);
            FromLocation.SendKeys(invalidFromLocation);
            FromLocation.SendKeys(Keys.Tab);
            ToLocation.SendKeys(invalidToLocation);
            ToLocation.SendKeys(Keys.Tab);
        }
        public void emptyLocationAsDetails(string emptyFromLocation, string emptyToLocation)
        {
            Actions action = new Actions(driver);
            FromLocation.SendKeys(emptyFromLocation);
            FromLocation.SendKeys(Keys.Tab);
            ToLocation.SendKeys(emptyToLocation);
            ToLocation.SendKeys(Keys.Tab);
        }
        public void ClickCookieDone() => CookiesDonebtn.Click();
        public void AcceptCookies()
        {
            driver.MilliSec(500);
            try
            {
                if (Cookiesbtn.Displayed)
                {
                    Cookiesbtn.Click();
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
        public void navigateToSite() => driver.Navigate().GoToUrl(readTestDataConfig.tflUrl);
    }
}