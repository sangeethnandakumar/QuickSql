public class SqlRow
{
    private readonly IDictionary<string, object> _rowData;

    public SqlRow(IDictionary<string, object> rowData)
    {
        _rowData = rowData ?? throw new ArgumentNullException(nameof(rowData));
    }

    // Access a column by name
    public object this[string columnName] => _rowData[columnName];

    // Access a column by index
    public object this[int columnIndex] => _rowData.Values.ElementAt(columnIndex);

    // Get all column names
    public IEnumerable<string> ColumnNames => _rowData.Keys;

    // Get all column values
    public IEnumerable<object> Values => _rowData.Values;
}
