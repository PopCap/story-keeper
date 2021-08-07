using System.Collections.Generic;

public class Campaign : ITable
{
    public int id { get; set; }

	public string name { get; set; }

	public string dm { get; set; }

	public string startDate { get; set; }

    public string CreateTable()
    {
		return "CREATE TABLE IF NOT EXISTS campaign (" +
			   "id INTEGER PRIMARY KEY," +
			   "name TEXT," +
			   "dm TEXT," +
			   "start_date CURRENT_DATE" +
			   ");";
    }

	public string DeleteRow(int id)
    {
		return string.Format("DELETE FROM campaign WHERE id = {0};",
			id);
    }

	public string InsertRow(List<string> values)
    {
		if (values == null || values.Count != 2) return null;
		else
        {
			return string.Format("INSERT INTO campaign(name, dm, start_date) VALUES ('{0}', '{1}', {2});",
				values[0],
				values[1],
				"datetime('now', 'localtime')"
				);
        }
    }

	// shouldn't change campaign's start date
	public string UpdateRow(int id, List<string> values)
    {
		return string.Format("UPDATE campaign SET name = '{0}', dm = '{1}' WHERE id = {2};",
			values[0],
			values[1],
			id);
    }

    public override string ToString()
	{
		return string.Format("[Campaign: id={0}, name={1},  dm={2}, start_date={3}]", id, name, dm, startDate);
	}
}