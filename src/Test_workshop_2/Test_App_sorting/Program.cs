

// Укажите путь, по которому будет сохранен файл
using OfficeOpenXml;


string filePath = "example.xlsx";

// Убедитесь, что EPPlus лицензирован для работы
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

using (var package = new ExcelPackage())
{
    // Создаем новый лист
    var worksheet = package.Workbook.Worksheets.Add("Sheet1");

    // Добавляем данные в таблицу
    worksheet.Cells[1, 1].Value = "Имя";
    worksheet.Cells[1, 2].Value = "Возраст";
    worksheet.Cells[2, 1].Value = "Алексей";
    worksheet.Cells[2, 2].Value = 29;

    // Сохраняем файл
    File.WriteAllBytes(filePath, package.GetAsByteArray());
}

Console.WriteLine("Файл сохранен как " + filePath);