using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PageObject_Practice.Pages;

namespace PageObject_Practice.Tests;

public class TestCase
{
    private IWebDriver webDriver;

    public WebDriverWait webDriverWait;

    public YourCashbackNew yourCashbackNew;

    [SetUp]
    public void SetUp()
    {
        webDriver = new ChromeDriver();
        webDriver.Manage().Window.Maximize();
        webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
        webDriver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/your-cashback-new");
        yourCashbackNew = new(webDriver, webDriverWait);
    }

    [TearDown]
    public void TearDown()
    {
        webDriver.Close();
        webDriver.Quit();
    }

    [Test]
    public void FillClientData()
    {
        yourCashbackNew
            .FillFirstName("Александр")
            .FillMiddleName("Сергеевич")
            .FillLastName("Пушкин")
            .ChooseMaleGender()
            .FillBirthDate(new DateOnly(2000, 01, 17))
            .FillPhoneNumber("9771234567")
            .ChooseCitizenship("РФ")
            .CheckPersonalDataProcessingAgreementConcent();
            //.CheckPromotionAgreementConcent(); - можно подать заявку и без этого согласия.

        Thread.Sleep(5000);
    }
}