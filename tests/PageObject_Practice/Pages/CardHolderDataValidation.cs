using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace PageObject_Practice.Pages;

/// <summary>
/// 2. Страница проверки введенных данных
/// </summary>
internal class CardHolderDataValidation
{
    private WebDriverWait webDriverWait;
    
    [FindsBy(How = How.XPath, Using = "//div[contains(@class,'confirm-section')]//span[text()='Фамилия:']//following-sibling::b")]
    [CacheLookup]
    public IWebElement CardHolderLastNameField { get; set; }

    [FindsBy(How = How.XPath, Using = "//div[contains(@class,'confirm-section')]//span[text()='Имя:']//following-sibling::b")]
    [CacheLookup]
    public IWebElement CardHolderFirstNameField { get; set; }

    [FindsBy(How = How.XPath, Using = "//div[contains(@class,'confirm-section')]//span[text()='Отчество:']//following-sibling::b")]
    [CacheLookup]
    public IWebElement CardHolderMiddleNameField { get; set; }

    [FindsBy(How = How.XPath, Using = "//div[contains(@class,'confirm-section')]//span[text()='Дата рождения:']//following-sibling::b")]
    [CacheLookup]
    public IWebElement BirthDateField { get; set; }

    [FindsBy(How = How.XPath, Using = "//div[contains(@class,'confirm-section')]//span[text()='Мобильный телефон:']//following-sibling::b")]
    [CacheLookup]
    public IWebElement PhoneNumberField { get; set; }

    public CardHolderDataValidation(IWebDriver webDriver, WebDriverWait webDriverWait)
    {
        this.webDriverWait = webDriverWait;
        PageFactory.InitElements(webDriver, this);
    }
}
