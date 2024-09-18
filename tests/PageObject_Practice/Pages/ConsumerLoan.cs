using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace PageObject_Practice.Pages;

/// <summary>
/// 3. Наследование страниц.
/// </summary>
internal class ConsumerLoan : YourCashbackNew
{
    private WebDriverWait webDriverWait;
    
    [FindsBy(How = How.XPath, Using = "//mat-select[@name='RussianEmployment']")]
    [CacheLookup]
    public IWebElement EmploymentComboBox { get; set; }

    [FindsBy(How = How.XPath, Using = "//rui-checkbox[contains(@name,'BkiRequestAgreementConcent')]")]
    [CacheLookup]
    public IWebElement creditBureauRequestPermissionCheckbox { get; set; }

    public ConsumerLoan(IWebDriver webDriver, WebDriverWait webDriverWait) : base(webDriver, webDriverWait)
    {
        this.webDriverWait = webDriverWait;
        PageFactory.InitElements(webDriver, this);
    }

    public ConsumerLoan ChooseEmploymentStatus(string employmentStatus)
    {
        EmploymentComboBox.Click();

        IWebElement optionWebElement = webDriverWait.Until(driver => driver.FindElement(By.XPath($"//span[text()='{employmentStatus}']//ancestor::mat-option")));
        ChooseOption(optionWebElement);

        return this;
    }

    public ConsumerLoan CheckCreditBureauRequestPermission()
    {
        creditBureauRequestPermissionCheckbox.Click();

        return this;
    }

    public ConsumerLoan FillForm(string firstName, string middleName, string lastName, string gender, DateOnly birthDate, string phoneNumber,
        string citizenship, bool personalDataProcessingAgreement, string employmentStatus, bool checkCreditBureauRequestPermission)
    {
        base.FillForm(firstName, middleName, lastName, gender, birthDate, phoneNumber, citizenship, personalDataProcessingAgreement);

        return ChooseEmploymentStatus(employmentStatus)
            .CheckCreditBureauRequestPermission();
    }
}
