using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tag : ITable
{
	public int id { get; set; }

	public int sessionNoteId { get; set; }

	public string name { get; set; }

	public string CreateTable()
	{
		return "CREATE TABLE IF NOT EXISTS tag (" +
			   "id INT PRIMARY KEY ASC," +
			   "sess_note_id INT," +
			   "name TEXT," +
			   "FOREIGN KEY(sess_note_id) REFERENCES session_note(id)" +
			   ");";
	}

	public override string ToString()
	{
		return string.Format("[Tag: id={0}, sess_note_id={1},  name={2}]", id, sessionNoteId, name);
	}

}
