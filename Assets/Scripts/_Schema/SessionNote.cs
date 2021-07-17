public class SessionNote
{

	public int id { get; set; }

	public int sessionId { get; set; }

	public string note { get; set; }

	public string timeStamp { get; set; }

	public override string ToString()
	{
		return string.Format("[Session Note: id={0}, sess_id={1},  note={2}, time_stamp={3}]", id, sessionId, note, timeStamp);
	}
}