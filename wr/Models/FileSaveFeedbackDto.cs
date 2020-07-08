namespace wr.Models
{
    public class FileSaveFeedbackDto
    {
        public int DocumentTypeId { get; set; }
        public string FileUrl { get; set; }
        public string MimeType { get; set; }
        public string FileName { get; set; }
    }
}