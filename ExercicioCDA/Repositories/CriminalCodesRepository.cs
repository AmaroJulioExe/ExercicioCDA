using ExercicioCDA.Models;
using ExercicioCDA.Models.Entities.CriminalCodes;

namespace ExercicioCDA.Repositories
{
    public interface ICriminalRepository
    {
        public bool Create(PostCriminalCodes criminalcode);
        public CriminalCodes Read(int Id);
        public bool Update(PutCriminalCodes criminalcode);
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

        public CriminalCodes Read(int id)
        {
            try
            {
                var criminalcode_db = db.CriminalCodes.Find(id);
                return criminalcode_db;
            }
            catch
            {

                return new CriminalCodes();
            }
        }

        public bool Update(PutCriminalCodes criminalcode)
        {
            try
            {
                var criminalcode_db = db.CriminalCodes.Find(criminalcode.id);
                criminalcode_db.Name = criminalcode.Name;
                criminalcode_db.Description = criminalcode.Description;
                criminalcode_db.Penalty = criminalcode.Penalty;
                criminalcode_db.StatusId = criminalcode.StatusId;
                criminalcode_db.UpdateDate = criminalcode.UpdateDate;
                criminalcode_db.UpdateUserId = criminalcode.UpdateUserId;

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
