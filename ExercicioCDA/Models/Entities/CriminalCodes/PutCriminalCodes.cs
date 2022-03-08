namespace ExercicioCDA.Models.Entities.CriminalCodes
{
    public class PutCriminalCodes : PostCriminalCodes
    {
        public int id { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateUserId { get; set; }
    }
}
