using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using OpenQA.Selenium.Remote;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.DevTools;
using System.IO;

namespace TextAplication
{

   
        internal class Program
        {
            static void Main()


            {


                AccidentesTests.ExecuteTests();



            }
        }





        public class AccidentesTests
        {
            private static IWebDriver driver;
            private static WebDriverWait wait;

            public static void ExecuteTests()
            {
                using (driver = new ChromeDriver())
                {
                    wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100000));


                    Setup();
                    TestAgregarAccidente();
                    TestResponsiveDesign();
                    Cleanup();
                }
            }

            private static void Setup()
            {
                // Adjust the path to your ChromeDriver executable
                driver.Navigate().GoToUrl("http://localhost:5181");
                TakeScreenshot("Setup");
            }

            private static void TestAgregarAccidente()
            {
                // Click the "Agregar Accidente" button
                IWebElement agregarAccidenteButton = wait.Until(d => d.FindElement(By.Id("AgregarAccidentes")));
                agregarAccidenteButton.Click();

                Thread.Sleep(500);

                // Fill in the accident details in the form

                IWebElement fechaInput = wait.Until(d => d.FindElement(By.Id("fecha")));
                fechaInput.SendKeys("2023-01-01"); // Ajusta la fecha según sea necesario
                Thread.Sleep(200);

                IWebElement descripcionInput = wait.Until(d => d.FindElement(By.Id("descripcion")));
                descripcionInput.SendKeys("Camiones ");
                Thread.Sleep(300);
                IWebElement costoInput = wait.Until(d => d.FindElement(By.Id("costo")));
                costoInput.SendKeys("100");
                Thread.Sleep(300);

                IWebElement muertosInput = wait.Until(d => d.FindElement(By.Id("muertos")));
                muertosInput.SendKeys("1");
                Thread.Sleep(300);

                IWebElement heridosInput = wait.Until(d => d.FindElement(By.Id("heridos")));
                heridosInput.SendKeys("2");
                Thread.Sleep(200);

                IWebElement vehiculosInput = wait.Until(d => d.FindElement(By.Id("vehiculos")));
                vehiculosInput.SendKeys("3");
                Thread.Sleep(200);

                // Click the "Guardar" button
                IWebElement guardarButton = wait.Until(d => d.FindElement(By.Id("Guardaraccidente")));
                guardarButton.Click(); Thread.Sleep(10000);

                TakeScreenshot("TestAgregarAccidente");




            }


            private static void TestResponsiveDesign()
            {

                driver.Manage().Window.Size = new System.Drawing.Size(375, 667); // Puedes ajustar estos valores según tus necesidades

                // Navega a la página que deseas probar (ajusta la URL según tus necesidades)
                driver.Navigate().GoToUrl("http://localhost:5181");
                Thread.Sleep(200);
                TakeScreenshot("TestResponsiveDesign"); // Captura de pantalla durante las pruebas de responsividad



                // Restaura el tamaño de la ventana a su estado original
                driver.Manage().Window.Maximize();
                Thread.Sleep(200);
                TakeScreenshot("TestResponsiveDesign_Maximized");
            }




            private static void Cleanup()
            {
                // Close the browser after the tests
                driver.Quit();
            }

            private static void TakeScreenshot(string screenshotName)
            {
                ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
                Screenshot screenshot = screenshotDriver.GetScreenshot();

                // Crear una carpeta para almacenar capturas de pantalla si no existe
                string screenshotsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");
                if (!Directory.Exists(screenshotsDirectory))
                {
                    Directory.CreateDirectory(screenshotsDirectory);
                }

                string screenshotPath = Path.Combine(screenshotsDirectory, $"{screenshotName}.png");
                screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
            }

        }

    }


