using DORv3.BLL;
using DORv3.BLL.BusinessObjects;
using DORv3.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace DORv3.Models.ViewModels
{
    public class ListOfDealsViewModel : DORViewModel
    {
        public List<DealRecord_Summary> Deals { get; set; }

        public SearchObject SearchFilter { get; set; }
        public String FilterValue { get; set; }
        public List<SearchObject> SearchByFilters { get; set; }

        public DealerShip  Dealership { get; set; }
        public List<DealerShip> Dealerships { get; private set; }

        FowlerDORContext context = new FowlerDORContext();

        public ListOfDealsViewModel(int userID) : base(userID)
        {
            this.Dealerships = context.DealerShips.Where(d => (d.DisableDate == null || d.DisableDate > DateTime.Now) && DealerIDs.Contains(d.DealerID)).ToList();
            this.Dealership = Dealerships.First();

            this.SearchByFilters = new List<SearchObject>
            {
                new SearchObject {ID = 1, Value = "Deal Number" },
                new SearchObject {ID = 2, Value = "Stock Number" },
                new SearchObject {ID = 3, Value = "Last Name" },
                new SearchObject {ID = 4, Value = "First Name" },
                new SearchObject {ID = 5, Value = "Sales Date" },
                new SearchObject {ID = 6, Value = "Delivery Date" },
            };

            this.Deals = new DealBiz().GetListOfDealsSummary(this.Dealership.DealerID);
        }

        public void GetListOfDeals(int searchID, string filterval, int dealerID)
        {
            DealBiz biz = new DealBiz();
            if (searchID > 0 && filterval != null)
            {
                switch(searchID)
                {
                    case 1:
                        biz.SearchByDealNumber(filterval);
                        break;
                    case 2:
                        biz.SearchByStockNumber(filterval);
                        break;
                    case 3:
                        biz.SearchByLastName(filterval);
                        break;
                    case 4:
                        biz.SearchByFirstName(filterval);
                        break;
                    case 5:
                        biz.SearchBySalesDate(Convert.ToDateTime(filterval));
                        break;
                    case 6:
                        biz.SearchByDeliveryDate(Convert.ToDateTime(filterval));
                        break;
                    default:
                        break;
                }
            }

            this.Deals = biz.GetListOfDealsSummary(dealerID);
        }

        public ListOfDealsViewModel()
        {

        }
    }

    public class SearchObject
    {
        public int ID { get; set; }
        public string Value { get; set; }
    }

    
}