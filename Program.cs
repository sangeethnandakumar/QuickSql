// Connect
var conn = @"Server=LAPTOP-EQ7280N0\SQLEXPRESS01;Database=Picofine;Trusted_Connection=True;TrustServerCertificate=True";

// Run query
var result = SqlHelper.RunSQL(conn, "SELECT * FROM [Picofine].[dbo].[ClientMain]");

// Access rows
var firstRow = result.Rows.First(); // Get the first row
var firstName = firstRow["FName"]; // Access column by name

// Access columns
var firstCol = result.Cols.First(); // Get the first column
var firstColValue = firstCol[0]; // Access value by row index

//Access a specifcic item
var fname = result.Rows[1]["FName"];

// Count rows and columns
var rowCount = result.RowCount;
var colCount = result.ColCount;

Console.WriteLine($"First Name: {firstName}");
Console.WriteLine($"First Column Value: {firstColValue}");
Console.WriteLine($"Rows: {rowCount}, Columns: {colCount}");