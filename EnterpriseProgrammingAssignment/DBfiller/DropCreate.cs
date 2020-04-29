using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EnterpriseProgrammingAssignment.DBfiller
{
    public class DropCreate : DropCreateDatabaseIfModelChanges<DbContext>
    {
        protected override void SeedDb(DbContext context)
        {
            List<Quality> quality = new List<Quality>();
            quality.Add(new Quality { QualityLevel = "Poor" });
            quality.Add(new Quality { QualityLevel = "Bad" });
            quality.Add(new Quality { QualityLevel = "Good" });
            quality.Add(new Quality { QualityLevel = "Excellent" });
            context.qualities.AddRange(quality);

            base.Seed(context);

        }
    }
}