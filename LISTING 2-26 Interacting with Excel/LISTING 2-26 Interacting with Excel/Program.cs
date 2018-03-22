namespace LISTING_2_26_Interacting_with_Excel
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the interop
            var excelApp = new Microsoft.Office.Interop.Excel.Application();

            // make the app visible
            excelApp.Visible = true;

            // Add a new workbook
            excelApp.Workbooks.Add();

            // Obtain the active sheet from the app
            // There is no need to cast this dynamic type
            Microsoft.Office.Interop.Excel.Worksheet workSheet = excelApp.ActiveSheet;

            // Write into two cells
            workSheet.Cells[1, "A"] = "Hello";
            workSheet.Cells[1, "B"] = "from C#";
        }
    }
}
