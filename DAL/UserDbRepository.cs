using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using BOL;

namespace DAL
{
    public class UserDbRepository
    {
        private Mvc3TierEntities db;

        public UserDbRepository()
        {
            db = new Mvc3TierEntities();
        }

        public IEnumerable<tbl_User> GetAll()
        {
            return db.tbl_User.ToList();
        }

        public tbl_User GetById(int id)
        {
            return db.tbl_User.Find(id);
        }

        public void Insert(tbl_User user)
        {
            user.c_Password = Hashing.HashPassword(user.c_Password);
            user.c_ConfirmPassword = user.c_Password;
            db.tbl_User.Add(user);
            Save();
        }

        public void Delete(int id)
        {
            tbl_User url = db.tbl_User.Find(id);
            db.tbl_User.Remove(url);
            Save();
        }

        public void Update(tbl_User user)
        {
            //db.Entry(user).State = EntityState.Modified;
            db.Entry(user).State = EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = false;
            Save();
            db.Configuration.ValidateOnSaveEnabled = true;
        }

        private void Save()
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }

        }
    }
}
