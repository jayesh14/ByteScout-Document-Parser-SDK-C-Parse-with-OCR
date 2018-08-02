using System;
using ByteScout.DocumentParser;

// This example demonstrates the use of Optical Character Recognition (OCR) to parse document 
// from scanned PDF documents and raster images.

namespace ParseWithOCR
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputDocument1 = @".\DigitalOcean-scanned.jpg";

            // Create DocumentParser instance
            using (DocumentParser documentParser = new DocumentParser("demo", "demo"))
            {
                // Enable Optical Character Recognition (OCR)
                // in .Auto mode (SDK automatically checks if needs to use OCR or not)
                documentParser.OCRMode = OCRMode.Auto;

                // Set the location of "tessdata" folder containing language data files
                documentParser.OCRLanguageDataFolder = @".\tessdata\";

                // Set OCR language
                documentParser.OCRLanguage = "eng";
                // "eng" for english, "deu" for German, "fra" for French, "spa" for Spanish etc - according to files in /tessdata
                // Find more language files at https://github.com/tesseract-ocr/tessdata/tree/3.04.00


                Console.WriteLine($"Parsing \"{inputDocument1}\"...");
                Console.WriteLine();

                // Parse document data in JSON format
                string jsonString = documentParser.ParseDocument(inputDocument1, OutputFormat.JSON);
                // Display parsed data in console
                Console.WriteLine("Parsing results in JSON format:");
                Console.WriteLine();
                Console.WriteLine(jsonString);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
