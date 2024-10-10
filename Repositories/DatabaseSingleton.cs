using ProjectPSDLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSDLab.Repositories
{
    public class DatabaseSingleton
    {
        public static LocalDatabaseEntities2 db = new LocalDatabaseEntities2();

        public static LocalDatabaseEntities2 GetInstance()
        {
            if(db == null)
            {
                db = new LocalDatabaseEntities2();
            }

            return db;
        }
    }
}