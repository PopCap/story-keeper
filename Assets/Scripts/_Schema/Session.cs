using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;

public class Session : AbstractTable
{
	public int id { get; set; }

	public int campId { get; set; }

	public string sessionDate { get; set; }

	public override List<AbstractTable> BuildQueryResults(SqliteDataReader reader)
	{
		List<AbstractTable> results = new List<AbstractTable>();
		while (reader.Read())
		{
			results.Add(new Session
			{
				id = int.Parse(reader["id"].ToString()),
				campId = int.Parse(reader["camp_id"].ToString()),
				sessionDate = reader["start_date"].ToString()
			});
		}
		return results;
	}

	public override string CreateTable()
	{
		return "CREATE TABLE IF NOT EXISTS session (" +
			   "id INTEGER PRIMARY KEY," +
			   "camp_id INT," +
			   "session_date CURRENT_DATE," +
			   "FOREIGN KEY(camp_id) REFERENCES campaign(id)" +
			   ");";
	}

	public override string DeleteRow(int id)
	{
		return "";
	}

	public override string InsertRow(List<string> values)
	{
		if (values == null || values.Count != 1) return null;
		else
		{
			return string.Format("INSERT INTO session(camp_id, session_date) VALUES ('{0}', {1});",
                Int32.Parse(values[0]),
				"datetime('now', 'localtime')"
				);
		}
	}

	// shouldn't update the campaign it's linked to
	public override string UpdateRow(int id, List<string> values)
	{
		return string.Format("UPDATE session SET name = '{0}' dm = '{1}' WHERE id = {2};",
			values[0],
			values[1],
			id);
	}

	public override string ToString()
	{
		return string.Format("[Session: id={0}, camp_id={1},  session_date={2}]", id, campId, sessionDate);
	}
}