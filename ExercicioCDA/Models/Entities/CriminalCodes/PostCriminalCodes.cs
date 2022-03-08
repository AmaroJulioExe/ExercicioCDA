namespace ExercicioCDA.Models.Entities.CriminalCodes
{
    public class PostCriminalCodes
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Penalty { get; set; }
        public int PrisonTime { get; set; }
        public DateTime CreateDate { get; set; }
        //public DateTime UpdateDate { get; set; }

        public Status? StatusId { get; set; }
        public Users? CreateUserId { get; set; }
        //public Users? UpdateUserId { get; set; }
    }
}
