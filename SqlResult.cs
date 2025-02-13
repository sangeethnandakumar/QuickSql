public class SqlResult
{
    public IList<SqlRow> Rows { get; }
    public IList<SqlCol> Cols { get; }

    public SqlResult(IEnumerable<dynamic> rows)
    {
        if (rows == null || !rows.Any())
        {
            Rows = new List<SqlRow>();
            Cols = new List<SqlCol>();
            return;
        }

        // Convert dynamic rows to SqlRow objects
        Rows = rows.Select(row => new SqlRow((IDictionary<string, object>)row)).ToList();

        // Extract column names from the first row
        var columnNames = ((IDictionary<string, object>)rows.First()).Keys;

        // Create SqlCol objects for each column
        Cols = columnNames.Select(colName => new SqlCol(rows.Select(row => ((IDictionary<string, object>)row)[colName]))).ToList();
    }

    // Get the number of rows
    public int RowCount => Rows.Count;

    // Get the number of columns
    public int ColCount => Cols.Count;
}