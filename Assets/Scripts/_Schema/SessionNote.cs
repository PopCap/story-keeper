using System;
using System.Collections.Generic;

public class SessionNote : ITable
{

	public int id { get; set; }

	public int sessionId { get; set; }

	public string note { get; set; }

	public string timestamp { get; set; }

	public string CreateTable()
	{
		return "CREATE TABLE IF NOT EXISTS session_note (" +
			   "id INTEGER PRIMARY KEY," +
			   "sess_id INT," +
			   "note TEXT," +
			   "timestamp CURRENT_TIMESTAMP," +
			   "FOREIGN KEY(sess_id) REFERENCES session(id)" +
			   ");";
	}

	public string InsertRow(List<string> values)
    {
		if (values == null || values.Count != 2) return null;
		else
		{
			return string.Format("INSERT INTO session_note(sess_id, note, timestamp) VALUES ('{0}', '{1}', {2});",
				Int32.Parse(values[0]),
				values[1],
				"datetime('now', 'localtime')"
				);
		}
	}

	public override string ToString()
		{
			return string.Format("[Session Note: id={0}, sess_id={1},  note={2}, timestamp={3}]", id, sessionId, note, timestamp);
		}

}