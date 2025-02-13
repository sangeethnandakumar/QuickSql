public class SqlResult
{
    private readonly List<dynamic> _rows;
    private readonly List<string> _columnNames;

    public SqlResult(IEnumerable<dynamic> rows)
    {
        _rows = rows.ToList();
        _columnNames = rows.Any() ? ((IDictionary<string, object>)rows.First()).Keys.ToList() : new List<string>();
    }

    public dynamic Row(int rowIndex) => _rows[rowIndex];

    public dynamic Col(int colIndex) => _rows.Select(row => ((IDictionary<string, object>)row).Values.ElementAt(colIndex)).ToList();

    public dynamic Col(string colName) => _rows.Select(row => ((IDictionary<string, object>)row)[colName]).ToList();

    public dynamic Item(int rowIndex, string colName) => ((IDictionary<string, object>)_rows[rowIndex])[colName];

    public dynamic Item(int rowIndex, int colIndex) => ((IDictionary<string, object>)_rows[rowIndex]).Values.ElementAt(colIndex);
}