
// Connect
var conn = "";

//Run
var result = SqlHelper.RunSQL(conn, "SELECT * FROM dbo.MainTable WHERE Id=@id AND Name=@name", 1, "John");

// Access
var name1 = result.Row(0); // Entire first row
var name2 = result.Col(0); // First column of all rows
var name3 = result.Row(0).Col(2); // Third column of the first row
var name4 = result.Item(0, "Name"); // Value of "Name" column in the first row
var name5 = result.Item(0, 2); // Value of the third column in the first row

//Validate