using ProjectPSDLab.Factories;
using ProjectPSDLab.Models;
using ProjectPSDLab.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSDLab.Handlers
{
    public class SuplementHandler
    {
        SuplementRepository SupRepo = new SuplementRepository();

        public List<MsSuplement> GetSuplements()
        {
            return SupRepo.GetAllSuplements();
        }

        public List<string> GetAllSuplementTypeNames()
        {
            return SupRepo.GetAllSuplementTypes().Select(type => type.SuplementTypeName).ToList();
        }

        private int GetNextSuplementId()
        {
            var supplements = SupRepo.GetAllSuplements();
            return supplements.Any() ? supplements.Last().SuplementID + 1 : 1;
        }

        public void AddSupplement(string name, DateTime expiryDate, int price, string typeName)
        {
            var type = SupRepo.FindSuplementTypeByName(typeName);
            var newSupplement = SuplementFactory.Create(GetNextSuplementId(), name, expiryDate, price, type.SuplementTypeID);
            SupRepo.AddSuplement(newSupplement);
        }

        public MsSuplement FindSuplementById(int id)
        {
            return SupRepo.FindSuplementById(id);
        }

        public void DeleteSuplement(int suplementId)
        {
            var temp = FindSuplementById(suplementId);
            if (temp != null)
            {
                SupRepo.DeleteSuplement(temp);
            }
        }

        public void UpdateExistingSupplement(int id, string name, DateTime expiryDate, int price, string typeName)
        {
            var type = SupRepo.FindSuplementTypeByName(typeName);
            var updatedSupplement = SuplementFactory.Create(id, name, expiryDate, price, type.SuplementTypeID);
            SupRepo.UpdateSuplement(id, updatedSupplement);
        }
    }

}