public class SqlCol
{
    private readonly IEnumerable<object> _columnData;

    public SqlCol(IEnumerable<object> columnData)
    {
        _columnData = columnData ?? throw new ArgumentNullException(nameof(columnData));
    }

    // Access a value by row index
    public object this[int rowIndex] => _columnData.ElementAt(rowIndex);

    // Get all values in the column
    public IEnumerable<object> Values => _columnData;
}
