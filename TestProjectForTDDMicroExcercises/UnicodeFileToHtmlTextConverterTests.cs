using System;
using TDDMicroExercises.UnicodeFileToHtmlTextConverter;

namespace TestProjectForTDDMicroExcercises
{
    public class UnicodeFileToHtmlTextConverterTests
    {
        private string testFilePath = "C:\\Users\\eraru\\Desktop\\TestSamples\\text.txt";
        private string testFilePath1 = "C:\\Users\\eraru\\Desktop\\TestSamples\\text1.txt";

        [Test]
        public void ConvertToHtml_WithPlainText_ReturnsHtmlContent()
        {
            try
            {
                var converter = new UnicodeFileToHtmlTextConverter(testFilePath);
                string htmlContent = converter.ConvertToHtml();
                Assert.That(htmlContent, Is.EqualTo("HelloWorld!!<br />"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        [Test]
        public void ConvertToHtml_WithEmptyFile_ReturnsEmptyHtmlContent()
        {
            File.WriteAllText(testFilePath1, string.Empty);
            var converter = new UnicodeFileToHtmlTextConverter(testFilePath1);
            string htmlContent = converter.ConvertToHtml();
            Assert.That(htmlContent, Is.EqualTo(string.Empty));
        }
    }
}