namespace Agri.Models
{
    public class FirebaseErrorModel
    {
        public string? message { get; set; } // Make nullable or provide a default value
        public List<string>? errors { get; set; } // Make nullable or provide a default value
        public FirebaseErrorDetails? error { get; set; } // Make nullable or provide a default value
    }

    public class FirebaseErrorDetails
    {
        public string? message { get; set; } // Make nullable or provide a default value
    }
}
