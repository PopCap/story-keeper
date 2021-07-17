
public class Session
{
	public int id { get; set; }

	public int campId { get; set; }

	public string sessionDate { get; set; }

	public override string ToString()
	{
		return string.Format("[Session: id={0}, camp_id={1},  session_date={2}]", id, campId, sessionDate);
	}
}