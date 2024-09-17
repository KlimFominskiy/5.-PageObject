using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace PageObject_Practice.Pages;

public class YourCashbackNew
{
    private WebDriverWait webDriverWait;

    [FindsBy(How = How.XPath, Using = "//input[@name='CardHolderLastName']")]
    [CacheLookup]
    private IWebElement CardHolderLastNameInput { get; set; }

    [FindsBy(How = How.XPath, Using = "//input[@name='CardHolderFirstName']")]
    [CacheLookup]
    private IWebElement CardHolderFirstNameInput { get; set; }

    [FindsBy(How = How.XPath, Using = "//input[@name='CardHolderMiddleName']")]
    [CacheLookup]
    private IWebElement CardHolderMiddleNameInput { get; set; }

    [FindsBy(How = How.XPath, Using = "//rui-radio[@id='formly_15_radio_Sex_0-0']")]
    [CacheLookup]
    private IWebElement MaleGenderCheckbox { get; set; }

    [FindsBy(How = How.XPath, Using = "//rui-datepicker[@name='BirthDate']//input")]
    [CacheLookup]
    private IWebElement BirthDateInput { get; set; }

    [FindsBy(How = How.XPath, Using = "//input[@id='formly_19_input_Phone_0']")]
    [CacheLookup]
    private IWebElement PhoneNumberInput { get; set; }

    [FindsBy(How = How.XPath, Using = "//mat-select[@name='RussianFederationResident']")]
    [CacheLookup]
    private IWebElement CitizenshipCombobox { get; set; }

    [FindsBy(How = How.XPath, Using = "//rui-checkbox[contains(@name,'PersonalDataProcessingAgreementConcent')]")]
    [CacheLookup]
    private IWebElement PersonalDataProcessingAgreementConcentCheckbox { get; set; }

    [FindsBy(How = How.XPath, Using = "//rui-checkbox[contains(@name,'PromotionAgreementConcent')]")]
    [CacheLookup]
    private IWebElement PromotionAgreementConcentCheckboxXpath { get; set; }

    [FindsBy(How = How.XPath, Using = "//span[text()=' Продолжить ']//ancestor::button")]
    [CacheLookup]
    private IWebElement ContinueButton { get; set; }

    public YourCashbackNew(IWebDriver webDriver, WebDriverWait webDriverWait)
    {
        this.webDriverWait = webDriverWait;
        PageFactory.InitElements(webDriver, this);
    }

    public YourCashbackNew FillLastName(string lastName)
    {
        FillInput(CardHolderLastNameInput, lastName);

        return this;
    }

    public YourCashbackNew FillMiddleName(string middleName)
    {
        FillInput(CardHolderMiddleNameInput, middleName);

        return this;
    }

    public YourCashbackNew FillFirstName(string firstName)
    {
        FillInput(CardHolderFirstNameInput, firstName);

        return this;
    }

    public YourCashbackNew ChooseMaleGender()
    {
        MaleGenderCheckbox.Click();

        return this;
    }

    public YourCashbackNew ChooseFemaleGender()
    {
        throw new NotImplementedException();
        
        //FemaleGenderCheckbox.Click();

        return this;
    }

    public YourCashbackNew FillBirthDate(DateOnly birthDate)
    {
        FillInput(BirthDateInput, birthDate.ToString());

        return this;
    }

    public YourCashbackNew FillPhoneNumber(string phoneNumber)
    {
        FillInput(PhoneNumberInput, phoneNumber);

        return this;
    }

    public YourCashbackNew ChooseCitizenship(string citizenship)
    {
        CitizenshipCombobox.Click();

        IWebElement option = webDriverWait.Until(driver => driver.FindElement(By.XPath($"//span[text()='{citizenship}']//ancestor::mat-option")));

        ChooseOption(option);

        return this;
    }

    public YourCashbackNew CheckPersonalDataProcessingAgreementConcent()
    {
        PersonalDataProcessingAgreementConcentCheckbox.Click();

        return this;
    }

    public YourCashbackNew CheckPromotionAgreementConcent()
    {
        PromotionAgreementConcentCheckboxXpath.Click();

        return this;
    }

    private void FillInput(IWebElement inputWebElement, string text)
    {
        webDriverWait.Until(driver => inputWebElement.Displayed);
        inputWebElement.Click();
        inputWebElement.SendKeys(text);
    }

    private void ChooseOption(IWebElement optionWebElement)
    {
        webDriverWait.Until(driver => optionWebElement.Displayed);
        optionWebElement.Click();
    }
}