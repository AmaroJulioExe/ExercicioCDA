using ExercicioCDA.Models;
using ExercicioCDA.Models.Entities;

namespace ExercicioCDA.Repositories
{
    public interface ICriminalRepository
    {
        public bool Create(PostCriminalCodes criminalcode); 
        //public bool Update(PostCriminalCodes criminalcode);
    }

    public class CriminalCodesRepository : ICriminalRepository
    {
        private readonly _DbContext db;

        public CriminalCodesRepository(_DbContext _db)
        {
            db = _db;
        }

        public bool Create(PostCriminalCodes criminalcode)
        {
            try
            {
                var criminalcode_db = new CriminalCodes()
                {
                    Name = criminalcode.Name,
                    Description = criminalcode.Description,
                    Penalty = criminalcode.Penalty,
                    PrisonTime = criminalcode.PrisonTime,
                    StatusId = criminalcode.StatusId,
                    CreateDate = criminalcode.CreateDate,
                    CreateUserId = criminalcode.CreateUserId
                };
                db.CriminalCodes.Add(criminalcode_db);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
