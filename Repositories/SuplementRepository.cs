using ProjectPSDLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSDLab.Repositories
{
    public class SuplementRepository
    {
        private LocalDatabaseEntities2 db = DatabaseSingleton.GetInstance();

  
        public List<MsSuplement> GetAllSuplements()
        {
            return db.MsSuplements.ToList();
        }

        public void AddSuplement(MsSuplement suplement)
        {
            db.MsSuplements.Add(suplement);
            db.SaveChanges();
        }

        public MsSuplementType FindSuplementTypeByName(String name)
        {
            return db.MsSuplementTypes.FirstOrDefault(t => t.SuplementTypeName == name);
        }
        public MsSuplement FindSuplementById(int id)
        {
            return db.MsSuplements.FirstOrDefault(s => s.SuplementID == id);
        }

        public List<MsSuplementType> GetAllSuplementTypes()
        {
            return db.MsSuplementTypes.ToList();
        }


        public void UpdateSuplement(int id, MsSuplement updatedSupplement)
        {
            MsSuplement existingSuplement = db.MsSuplements.Find(id);
            if (existingSuplement != null)
            {
                existingSuplement.SuplementName = updatedSupplement.SuplementName;
                existingSuplement.SuplementTypeID = updatedSupplement.SuplementTypeID;
                existingSuplement.SuplementPrice = updatedSupplement.SuplementPrice;
                existingSuplement.SuplementExpired = updatedSupplement.SuplementExpired;
                db.SaveChanges();
            }
        }

        public void DeleteSuplement(MsSuplement suplement)
        {
            db.MsSuplements.Remove(suplement);
            db.SaveChanges();
        }

        
    }
}