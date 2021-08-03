
public class Session : ITable
{
	public int id { get; set; }

	public int campId { get; set; }

	public string sessionDate { get; set; }

	public string CreateTable()
	{
		return "CREATE TABLE IF NOT EXISTS session (" +
			   "id INT PRIMARY KEY ASC," +
			   "camp_id INT," +
			   "session_date CURRENT_DATE," +
			   "FOREIGN KEY(camp_id) REFERENCES campaign(id)" +
			   ");";
	}

	public override string ToString()
	{
		return string.Format("[Session: id={0}, camp_id={1},  session_date={2}]", id, campId, sessionDate);
	}
}