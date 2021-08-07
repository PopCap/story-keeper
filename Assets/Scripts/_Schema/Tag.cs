using System;
using System.Collections.Generic;

public class Tag : ITable
{
	public int id { get; set; }

	public int sessionNoteId { get; set; }

	public string name { get; set; }

	public string CreateTable()
	{
		return "CREATE TABLE IF NOT EXISTS tag (" +
			   "id INTEGER PRIMARY KEY," +
			   "sess_note_id INT," +
			   "name TEXT," +
			   "FOREIGN KEY(sess_note_id) REFERENCES session_note(id)" +
			   ");";
	}

	public string DeleteRow(int id)
	{
		return "";
	}

	public string InsertRow(List<string> values)
	{
		if (values == null || values.Count != 2) return null;
		else
		{
			return string.Format("INSERT INTO tag(sess_note_id, name) VALUES ('{0}', '{1}');",
				Int32.Parse(values[0]),
				values[1]
				);
		}
	}

	public string UpdateRow(int id, List<string> values)
	{
		return string.Format("UPDATE campaign SET name = '{0}' dm = '{1}' WHERE id = {2};",
			values[0],
			values[1],
			id);
	}

	public override string ToString()
	{
		return string.Format("[Tag: id={0}, sess_note_id={1},  name={2}]", id, sessionNoteId, name);
	}

}
