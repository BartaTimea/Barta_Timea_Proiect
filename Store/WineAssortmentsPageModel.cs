using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Barta_Timea_Proiect.Data;


namespace Barta_Timea_Proiect.Store
{
    public class WineAssortmentsPageModel : PageModel
    {
        public List<AssignedAssortmentData> AssignedAssortmentDataList;
        public void PopulateAssignedAssortmentData(Barta_Timea_ProiectContext context, Wine wine)
        {
            var allAssortments = context.Assortment;
            var wineAssortments = new HashSet<int>(wine.WineAssortments.Select(c => c.WineID));
            AssignedAssortmentDataList = new List<AssignedAssortmentData>();
            foreach (var ass in allAssortments)
            {
                AssignedAssortmentDataList.Add(new AssignedAssortmentData
                {
                    AssortmentID = ass.ID,
                    Name = ass.AssortmentName,
                    Assigned = wineAssortments.Contains(ass.ID)
                });
            }
        }
        public void UpdateWineAssortments(Barta_Timea_ProiectContext context, string[] selectedAssortments, Wine wineToUpdate)
        {
            if (selectedAssortments == null)
            {
                wineToUpdate.WineAssortments = new List<WineAssortment>();
                return;
            }
            var selectedAssortmentsHS = new HashSet<string>(selectedAssortments);
            var wineAssortments = new HashSet<int>(wineToUpdate.WineAssortments.Select(c => c.Assortment.ID));
            foreach (var ass in context.Assortment)
            {
                if (selectedAssortmentsHS.Contains(ass.ID.ToString()))
                {
                    if (!wineAssortments.Contains(ass.ID))
                    {
                        wineToUpdate.WineAssortments.Add(new WineAssortment
                        {
                            WineID = wineToUpdate.ID,
                            AssortmentID = ass.ID
                        });
                    }
                }
                else
                {
                    if (wineAssortments.Contains(ass.ID))
                    {
                        WineAssortment courseToRemove = wineToUpdate.WineAssortments.SingleOrDefault(i => i.AssortmentID == ass.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
