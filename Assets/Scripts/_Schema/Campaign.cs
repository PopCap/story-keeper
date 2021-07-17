public class Campaign : ITable
{
    public int id { get; set; }

	public string name { get; set; }

	public string dm { get; set; }

	public string startDate { get; set; }

	public string lastEdit { get; set; }

    public string CreateTable()
    {
		return "CREATE TABLE IF NOT EXISTS campaign (" +
			   "id INT PRIMARY KEY ASC," +
			   "name TEXT," +
			   "dm TEXT," +
			   "startDate CURRENT_DATE," +
			   "lastEdit CURRENT_TIMESTAMP" +
			   ");";
    }

    public override string ToString()
	{
		return string.Format("[Campaign: id={0}, name={1},  dm={2}, created_at={3}]", id, name, dm, startDate);
	}
}