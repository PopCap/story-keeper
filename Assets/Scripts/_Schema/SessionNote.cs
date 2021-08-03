public class SessionNote : ITable
{

	public int id { get; set; }

	public int sessionId { get; set; }

	public string note { get; set; }

	public string timeStamp { get; set; }

	public string CreateTable()
	{
		return "CREATE TABLE IF NOT EXISTS session_note (" +
			   "id INT PRIMARY KEY ASC," +
			   "sess_id INT," +
			   "note TEXT," +
			   "timestamp CURRENT_TIMESTAMP" +
			   "FOREIGN KEY(sess_id) REFERENCES session(id)" +
			   ");";
    }

	public override string ToString()
		{
			return string.Format("[Session Note: id={0}, sess_id={1},  note={2}, time_stamp={3}]", id, sessionId, note, timeStamp);
		}

}