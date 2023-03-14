namespace ChromeExtensionBackend.Models
{
    public class TagItem
    {
        public int TagItemId { get; set; }
        public int UserId { get; set; }
        public List<Tags> tag { get; set; }
        public string time { get; set; }
        public string selection { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public bool isEditing { get; set; }
        public bool isFlipped { get; set; }
        public bool isShowing { get; set; }
        public string metaDescription { get; set; }
    }

    public class Tags
    {
        public int Id { get; set; }
        public string tag { get; set; }
    }
}
