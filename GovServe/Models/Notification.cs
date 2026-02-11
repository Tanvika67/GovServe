namespace GovServe.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public int  UserId { get; set; }
        public string Message { get; set; }
        public string Category {  get; set; }
		public string Status{ get; set; }
		public DateTime CreatedDate { get; set; }

    }
}
