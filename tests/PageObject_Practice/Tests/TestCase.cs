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

    private ConsumerLoan consumerLoan;

    [SetUp]
    public void SetUp()
    {
        webDriver = new ChromeDriver();
        webDriver.Manage().Window.Maximize();
        webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
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
        // 1. Создание класса страницы.

        string firstName = "Александр";
        string middleName = "Сергеевич";
        string lastName = "Пушкин";
        DateOnly birthDate = new DateOnly(2000, 01, 17);
        string phoneNumber = "9771234567";
        string citizenship = "РФ";

        webDriver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/your-cashback-new");
        yourCashbackNew = new(webDriver, webDriverWait);

        webDriverWait.Until(driver => yourCashbackNew.acceptCookiesButton.Displayed);
        yourCashbackNew.AcceptCookies();
        yourCashbackNew.FillForm(firstName, middleName, lastName, "male", birthDate, phoneNumber, citizenship, true);

        // 2. Передача данных между страницами

        string actualFirstName = yourCashbackNew.CardHolderFirstNameInput.GetAttribute("value");
        string actualMiddleName = yourCashbackNew.CardHolderMiddleNameInput.GetAttribute("value");
        string actualLastName = yourCashbackNew.CardHolderLastNameInput.GetAttribute("value");
        string actualBirthDate = yourCashbackNew.BirthDateInput.GetAttribute("value");
        string actualPhoneNumber = yourCashbackNew.PhoneNumberInput.GetAttribute("value");

        yourCashbackNew.ContinueButton.Click();
        cardHolderDataValidation = new(webDriver, webDriverWait);
        Assert.Multiple(() =>
        {
            Assert.That(actualFirstName, Is.EqualTo(cardHolderDataValidation.CardHolderFirstNameField.Text));
            Assert.That(actualMiddleName, Is.EqualTo(cardHolderDataValidation.CardHolderMiddleNameField.Text));
            Assert.That(actualLastName, Is.EqualTo(cardHolderDataValidation.CardHolderLastNameField.Text));
            Assert.That(actualBirthDate, Is.EqualTo(cardHolderDataValidation.BirthDateField.Text));
            Assert.That(actualPhoneNumber, Is.EqualTo(cardHolderDataValidation.PhoneNumberField.Text));
        });

        // 3. Наследование страниц.

        webDriver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/consumer-loan");
        consumerLoan = new(webDriver, webDriverWait);
        consumerLoan
            .FillForm(firstName, middleName, lastName, "male", birthDate, phoneNumber, citizenship, true, employmentStatus: "Есть", true);
    }
}