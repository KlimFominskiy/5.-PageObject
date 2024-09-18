using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace PageObject_Practice.Pages;

/// <summary>
/// 1. Cайт заявки на дебетовую карту "Твой Кешбэк"
/// </summary>
internal class YourCashbackNew
{
    private WebDriverWait webDriverWait;

    [FindsBy(How = How.XPath, Using = "//input[@name='CardHolderLastName']")]
    [CacheLookup]
    public IWebElement CardHolderLastNameInput { get; set; }

    [FindsBy(How = How.XPath, Using = "//input[@name='CardHolderFirstName']")]
    [CacheLookup]
    public IWebElement CardHolderFirstNameInput { get; set; }

    [FindsBy(How = How.XPath, Using = "//input[@name='CardHolderMiddleName']")]
    [CacheLookup]
    public IWebElement CardHolderMiddleNameInput { get; set; }

    [FindsBy(How = How.XPath, Using = "//rui-radio[contains(@id,'radio_Sex_0-0')]")]
    [CacheLookup]
    public IWebElement MaleGenderCheckbox { get; set; }

    [FindsBy(How = How.XPath, Using = "//rui-datepicker[@name='BirthDate']//input")]
    [CacheLookup]
    public IWebElement BirthDateInput { get; set; }

    [FindsBy(How = How.XPath, Using = "//input[@name='Phone']")]
    [CacheLookup]
    public IWebElement PhoneNumberInput { get; set; }

    [FindsBy(How = How.XPath, Using = "//mat-select[@name='RussianFederationResident']")]
    [CacheLookup]
    public IWebElement CitizenshipComboBox { get; set; }

    [FindsBy(How = How.XPath, Using = "//rui-checkbox[contains(@name,'PersonalDataProcessingAgreementConcent')]")]
    [CacheLookup]
    public IWebElement PersonalDataProcessingAgreementConcentCheckbox { get; set; }

    [FindsBy(How = How.XPath, Using = "//rui-checkbox[contains(@name,'PromotionAgreementConcent')]")]
    [CacheLookup]
    public IWebElement PromotionAgreementConcentCheckboxXpath { get; set; }

    [FindsBy(How = How.XPath, Using = "//span[text()=' Продолжить ']//ancestor::button")]
    [CacheLookup]
    public IWebElement ContinueButton { get; set; }
   
    
    [FindsBy(How = How.XPath, Using = "//div[contains(@class,'block ')]//button")]
    [CacheLookup]
    public IWebElement acceptCookiesButton { get; set; }

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
        CitizenshipComboBox.Click();
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

    public YourCashbackNew AcceptCookies()
    {
        acceptCookiesButton.Click();

        return this;
    }

    public YourCashbackNew FillForm(string firstName, string middleName, string lastName,string gender, DateOnly birthDate,string phoneNumber,
        string citizenship, bool personalDataProcessingAgreement)
    {
        return FillFirstName(firstName)
            .FillMiddleName(middleName)
            .FillLastName(lastName)
            .ChooseMaleGender()
            .FillBirthDate(birthDate)
            .FillPhoneNumber(phoneNumber)
            .ChooseCitizenship(citizenship)
            .CheckPersonalDataProcessingAgreementConcent();
    }

    protected void FillInput(IWebElement inputWebElement, string text)
    {
        webDriverWait.Until(driver => inputWebElement.Displayed);
        inputWebElement.Click();
        inputWebElement.SendKeys(text);
    }

    protected void ChooseOption(IWebElement optionWebElement)
    {
        webDriverWait.Until(driver => optionWebElement.Displayed);
        optionWebElement.Click();
    }
}