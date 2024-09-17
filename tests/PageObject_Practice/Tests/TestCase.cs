using AngleSharp.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PageObject_Practice.Pages;

namespace PageObject_Practice.Tests;

internal class TestCase
{
    private IWebDriver webDriver;

    private WebDriverWait webDriverWait;

    private YourCashbackNew yourCashbackNew;

    private CardHolderDataValidation cardHolderDataValidation;

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
        // 

        string firstName = "Александр";
        string middleName = "Сергеевич";
        string lastName = "Пушкин";
        DateOnly birthDate = new DateOnly(2000, 01, 17);
        string phoneNumber = "9771234567";
        string citizenship = "РФ";

        yourCashbackNew
            .FillFirstName(firstName)
            .FillMiddleName(middleName)
            .FillLastName(lastName)
            .ChooseMaleGender()
            .FillBirthDate(birthDate)
            .FillPhoneNumber(phoneNumber)
            .ChooseCitizenship(citizenship)
            .CheckPersonalDataProcessingAgreementConcent();
        //.CheckPromotionAgreementConcent(); - можно подать заявку и без этого согласия.

        // 2. Передача данных между страницами

        yourCashbackNew.ContinueButton.Click();

        cardHolderDataValidation = new(webDriver, webDriverWait);

        Assert.That(firstName, Is.EqualTo(cardHolderDataValidation.CardHolderFirstNameField.Text));
        Assert.That(middleName, Is.EqualTo(cardHolderDataValidation.CardHolderMiddleNameField.Text));
        Assert.That(lastName, Is.EqualTo(cardHolderDataValidation.CardHolderLastNameField.Text));
        Assert.That(birthDate.ToString("dd.MM.yyyy"), Is.EqualTo(cardHolderDataValidation.BirthDateField.Text));

        //Thread.Sleep(5000);
    }
}