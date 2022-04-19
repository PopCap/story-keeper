using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;

public class SessionNote : AbstractTable
{

	public int id { get; set; }

	public int sessionId { get; set; }

	public string note { get; set; }

	public string timestamp { get; set; }

	public override List<AbstractTable> BuildQueryResults(SqliteDataReader reader)
	{
		List<AbstractTable> results = new List<AbstractTable>();
		while (reader.Read())
		{
			results.Add(new SessionNote
			{
				id = int.Parse(reader["id"].ToString()),
				sessionId = int.Parse(reader["sess_id"].ToString()),
				note = reader["note"].ToString(),
				timestamp = reader["timestamp"].ToString()

			});
		}
		return results;
	}

	public override string CreateTable()
	{
		return "CREATE TABLE IF NOT EXISTS session_note (" +
			   "id INTEGER PRIMARY KEY," +
			   "sess_id INT," +
			   "note TEXT," +
			   "timestamp CURRENT_TIMESTAMP," +
			   "FOREIGN KEY(sess_id) REFERENCES session(id)" +
			   ");";
	}

	public override string DeleteRow(int id)
	{
		return "";
	}

	public override string InsertRow(List<string> values)
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

	public override string UpdateRow(int id, List<string> values)
	{
		return string.Format("UPDATE campaign SET name = '{0}' dm = '{1}' WHERE id = {2};",
			values[0],
			values[1],
			id);
	}

	public override string ToString()
		{
			return string.Format("[Session Note: id={0}, sess_id={1},  note={2}, timestamp={3}]", id, sessionId, note, timestamp);
		}

}