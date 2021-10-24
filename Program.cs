using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var driver = new ChromeDriver())
            {
                
                driver.Manage().Window.Maximize();
                
                //Переменная для задержки
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                
                //Переходим на ссылку установки расширения метамаска
                driver.Navigate().GoToUrl(@"https://chrome.google.com/webstore/detail/metamask/nkbihfbeogaeaoehlefnkodbefgpgknn?hl=ru");

                var x0 = driver.CurrentWindowHandle;
                //Получаем дескриптор окна браузера
                var mainWindow = WinApi.GetForegroundWindow();
                
                //Нажимаем кнопку установить(Metamask)
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='g-c-R  webstore-test-button-label']"))).Click();
                Thread.Sleep(3000);

                //Получаем дескриптор окна
                var modalWindow = WinApi.GetForegroundWindow();
                //WinApi.MoveWindow(modalWindow, 0, 0, 400, 300, false);
                
                //Поднимаем наверх модальное окно
                WinApi.SetWindowPos(modalWindow, (IntPtr)0, 0, 0, 0, 0, SetWindowPosFlags.NOMOVE | SetWindowPosFlags.NOSIZE | SetWindowPosFlags.NOZORDER | SetWindowPosFlags.SHOWWINDOW);
                
                //Задаем позицию курсора
                WinApi.SetCursorPos(1325, 275);

                //Нажимаешь левую кнопку мыши
                WinApi.MouseClickLeft();
                
                //Поднимаем вверх окно браузера
                WinApi.SetWindowPos(mainWindow, (IntPtr)0, 0, 0, 0, 0, SetWindowPosFlags.NOMOVE | SetWindowPosFlags.NOSIZE | SetWindowPosFlags.NOZORDER | SetWindowPosFlags.SHOWWINDOW);
                Thread.Sleep(5000);
                var x2 = driver.WindowHandles;
                driver.SwitchTo().Window(x2[1]);
                //
                wait.Until(e => e.FindElement(By.XPath("//button"))).Click();
                wait.Until(e => e.FindElement(By.CssSelector("#app-content > div > div.main-container-wrapper > div > div > div.select-action__wrapper > div > div.select-action__select-buttons > div:nth-child(2) > button"))).Click();
                wait.Until(e => e.FindElement(By.XPath("//button[@class ='button btn-primary page-container__footer-button']"))).Click();
                Thread.Sleep(500);
                driver.FindElement(By.Id("create-password")).SendKeys("fccjkm0107");
                driver.FindElement(By.Id("confirm-password")).SendKeys("fccjkm0107");
                wait.Until(e => e.FindElement(By.XPath("//div[@class ='first-time-flow__checkbox']"))).Click();
                wait.Until(e => e.FindElement(By.XPath("//button[@class ='button btn-primary first-time-flow__button']"))).Click();
                try
                {
                    var x4 = driver.FindElement(By.XPath("//button"));
                    x4.Click();
                }
                catch
                {
                    var x4 = driver.FindElement(By.XPath("//button"));
                    x4.Click();
                }
                wait.Until(e => e.FindElement(By.CssSelector("#app-content > div > div.main-container-wrapper > div > div > div.reveal-seed-phrase > div.reveal-seed-phrase__buttons > button.button.btn-secondary.first-time-flow__button"))).Click();
                wait.Until(e => e.FindElement(By.XPath("//button[@class ='fas fa-times popover-header__button'"))).Click();
                wait.Until(e => e.FindElement(By.XPath("//div[@class ='identicon'"))).Click();
                wait.Until(e => e.FindElement(By.XPath("//div[@class ='account - menu__item__text'"))).Click();


                driver.Quit();
            }   
        }
    }
}
