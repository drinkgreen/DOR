using DORv3.BLL.BusinessObjects;
using DORv3.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using System.Web;

namespace DORv3.BLL
{
    public class DealBiz
    {
        private FowlerDORContext context;
        private List<MasterFI> ListOfDeals;
        public DealBiz()
        {
            this.context = new FowlerDORContext();
            ListOfDeals = context.MasterFIs.ToList();
        }

        public List<DealRecord_Summary> GetListOfDealsSummary(int dealerID)
        {
            List<DealRecord_Summary> deals = new List<DealRecord_Summary>();

            var dealRecords = ListOfDeals.Where(m=>  m.Dealerid == dealerID).OrderByDescending(m=>m.MasterFiId).Select(x => x).Take(25).ToList(); 
            foreach (MasterFI record in dealRecords)
            {
                DealRecord_Summary deal = new DealRecord_Summary {
                    dorID = record.DORid,
                    buyerlname = record.buyerlname,
                    buyerfname = record.buyerfname,
                    //cobuyerlname = record.cobuyerlname,
                   // cobuyerfname = record.cobuyerfname,
                    vehicle = record.vehicle,
                    vehicletype = record.vehicletype,
                    status = context.DealStatus.Where(s => s.StatusId == record.status).Select(s => s.StatusName).FirstOrDefault(),
                    DaysInStock = record.daysinstock,
                    dealnum = record.dealnum,
                    stocknum = record.stocknum,
                    make = record.make,
                    model = record.model,
                    year = record.year,
                    salesdate = record.salesdate,
                    delvdate = (DateTime)record.delvdate,
                    Trade1Status = (record.trade1status == true) ? "Y" : "N",
                    SalesManager = context.SalesManagers.Where(sm => sm.SMId == record.salesmanager).Select(sm => sm.SMName).FirstOrDefault(),
                    FinanceManager = context.FinanceManagers.Where(fm => fm.FMId == record.fimanager).Select(fm => fm.FMName).FirstOrDefault(),
                    FinanceType = context.FinanceTypes.Where(ft => ft.FinanceTypeId.ToString() == record.fitype).Select(ft => ft.FinanceType1).FirstOrDefault(),
                    backend = record.backend,
                    totalgross = record.totalgross
                };

                //deal.Salespersons = new List<SalespersonsPerDeal>();

                //if(record.salesperson1 != null)
                //{
                //    deal.Salespersons.Add( new SalespersonsPerDeal
                //    {
                //       dorID = record.DORid,
                //       Salesperson = context.SalesPersons.Where(sp => sp.ID == record.salesperson1).FirstOrDefault(),
                //       PercentofDeal = record.salesperson1per
                //    });
                //}
                //else if(record.salesperson2 != null)
                //{
                //    deal.Salespersons.Add(new SalespersonsPerDeal
                //    {
                //        dorID = record.DORid,
                //        Salesperson = context.SalesPersons.Where(sp => sp.ID == record.salesperson2).FirstOrDefault(),
                //        PercentofDeal = record.salesperson2per
                //    });
                //}
                //else if(record.salesperson3 != null)
                //{
                //    deal.Salespersons.Add(new SalespersonsPerDeal
                //    {
                //        dorID = record.DORid,
                //        Salesperson = context.SalesPersons.Where(sp => sp.ID == record.salesperson3).FirstOrDefault(),
                //        PercentofDeal = record.salesperson3per
                //    });
                //}

                deals.Add(deal);
            }

            return deals;
        }

        public void SearchByDealNumber(string dealnum)
        {
            ListOfDeals = ListOfDeals.Where(d => d.dealnum == dealnum).ToList();
        }

        public void SearchByStockNumber(string stocknum)
        {
            ListOfDeals = ListOfDeals.Where(d => d.stocknum == stocknum).ToList();
        }

        public void SearchByLastName(string lastName)
        {
            ListOfDeals = ListOfDeals.Where(d => d.buyerlname == lastName).ToList();
        }

        public void SearchByFirstName(string firstname)
        {
            ListOfDeals = ListOfDeals.Where(d => d.buyerfname == firstname).ToList();
        }

        public void SearchBySalesDate(DateTime salesdate)
        {
            ListOfDeals = ListOfDeals.Where(d => d.salesdate == salesdate).ToList();
        }

        public void SearchByDeliveryDate(DateTime deliverydate)
        {
            ListOfDeals = ListOfDeals.Where(d => d.delvdate == deliverydate).ToList();
        }

        //public MasterFI GetDealRecord(int dorID)
        //{
        //    MasterFI record = context.MasterFIs.Where(m => m.DORid == dorID).FirstOrDefault();
        //    return record;
        //}

        public DealRecord GetDealRecord(int dorID)
        {
            DealRecord record = new DealRecord();
            MasterFI mFI = context.MasterFIs.Where(m => m.DORid == dorID).FirstOrDefault();

            foreach(var prop in record.GetType().GetProperties())
            {
                if (mFI.GetType().GetProperty(prop.Name) != null)
                {
                    var sourceValue = mFI.GetType().GetProperty(prop.Name).GetValue(mFI, null);
                    prop.SetValue(record, sourceValue, null);
                }
                
            }

           return record;
        }

        public void AddDealRecord(DealRecord deal)
        {
            MasterFI mFI = new MasterFI();
            IList<PropertyMap> propItems = GetPropertyMap(deal.GetType(), mFI.GetType());
            foreach (var prop in propItems)
            {
                var sourceValue = prop.DealProperty.GetValue(deal, null);
                prop.MasterProperty.SetValue(mFI, sourceValue, null);
            }

            context.MasterFIs.Add(mFI);
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            
        }

        private IList<PropertyMap> GetPropertyMap(Type dealType, Type masterType)
        {
            var dealProps = dealType.GetProperties();
            var masterProps = masterType.GetProperties();

            var properties = (from d in dealProps
                              from m in masterProps
                              where d.Name == m.Name &&
                                  d.CanRead &&
                                  m.CanWrite &&
                                  d.PropertyType.IsPublic &&
                                  m.PropertyType.IsPublic &&
                                  d.Name.ToLower() != "masterfiid" &&
                                  d.PropertyType == m.PropertyType &&
                                  (
                                      (d.PropertyType.IsValueType &&
                                      m.PropertyType.IsValueType
                                      ) ||
                                      (d.PropertyType == typeof(string) &&
                                      m.PropertyType == typeof(string)
                                      )
                                  )
                              select new PropertyMap
                              {
                                  DealProperty = d,
                                  MasterProperty = m
                              }).ToList();
            return properties;
        }

        private class PropertyMap
        {
            public PropertyInfo DealProperty { get; set; }
            public PropertyInfo MasterProperty { get; set; }
        }

        public void UpdateDealRecord(DealRecord deal)
        {
            MasterFI mFI = context.MasterFIs.Where(m => m.MasterFiId == deal.MasterFiId).FirstOrDefault();
            foreach (var prop in deal.GetType().GetProperties())
            {
                if (mFI.GetType().GetProperty(prop.Name) != null)
                {
                    var sourceValue = mFI.GetType().GetProperty(prop.Name).GetValue(deal, null);
                    prop.SetValue(mFI, sourceValue, null);
                }

            }
            context.SaveChanges();
        }

        public List<SalespersonsPerDeal> GetSalespersons(DealRecord deal)
        {
            List<SalespersonsPerDeal> salespersons = new List<SalespersonsPerDeal>();

            if (deal.salesperson1 != null)
            {
                salespersons.Add(new SalespersonsPerDeal
                {
                    dorID = deal.DORid,
                    Salesperson = context.SalesPersons.Where(sp => sp.ID == deal.salesperson1).FirstOrDefault(),
                    PercentofDeal = deal.salesperson1per
                });
            }
            else if (deal.salesperson2 != null)
            {
                salespersons.Add(new SalespersonsPerDeal
                {
                    dorID = deal.DORid,
                    Salesperson = context.SalesPersons.Where(sp => sp.ID == deal.salesperson2).FirstOrDefault(),
                    PercentofDeal = deal.salesperson2per
                });
            }
            else if (deal.salesperson3 != null)
            {
                salespersons.Add(new SalespersonsPerDeal
                {
                    dorID = deal.DORid,
                    Salesperson = context.SalesPersons.Where(sp => sp.ID == deal.salesperson3).FirstOrDefault(),
                    PercentofDeal = deal.salesperson3per
                });
            }

            return salespersons;
        }

       

        public List<DealTradeObject> GetTrades(DealRecord deal)
        {
            List<DealTradeObject> trades = new List<DealTradeObject>();
            DealTradeObject trade;
            if (deal.trade1status == true)
            {
                trade = new DealTradeObject
                {
                    Status = deal.trade1status,
                    Make = deal.trade1make,
                    Model = deal.trade1model,
                    OtherMake = deal.trade1makeother,
                    OtherModel = deal.trade1modelother,
                    Year = deal.trade1year,
                    Mileage = deal.trade1mileage,
                    Intent = deal.trade1intent,
                    Title = deal.trade1title,
                    LienHolder = deal.trade1lien,
                    ACV = deal.trade1acv,
                    Payoff = deal.trade1payoff,
                    Equity = deal.trade1equity
                };

                trades.Add(trade);
            }
            if (deal.trade2status == true)
            {
                trade = new DealTradeObject
                {
                    Status = deal.trade2status,
                    Make = deal.trade2make,
                    Model = deal.trade2model,
                    OtherMake = deal.trade2makeother,
                    OtherModel = deal.trade2modelother,
                    Year = deal.trade2year,
                    Mileage = deal.trade2mileage,
                    Intent = deal.trade2intent,
                    Title = deal.trade2title,
                    LienHolder = deal.trade2lien,
                    ACV = deal.trade2acv,
                    Payoff = deal.trade2payoff,
                    Equity = deal.trade2equity
                };
                trades.Add(trade);
            }
            return trades;
        }

        //public DealRecord GetDealRecord(int dorID)
        //{
        //    DealRecord record = new DealRecord();
        //    record = context.MasterFIs.Where(m => m.DORid == dorID)
        //        .Select(d => new DealRecord
        //        {
        //            dorID = d.DORid,
        //            buyerfname = d.buyerfname,
        //            buyerlname = d.buyerlname,
        //            cobuyerfname = d.cobuyerfname,
        //            cobuyerlname = d.cobuyerlname,
        //            vehicle = d.vehicle,
        //            vehicletype = d.vehicletype,
        //            businesssource = d.businesssource,
        //            SalesCategory = context.SalesCategories.Where(s => s.SalesCategoryId.ToString() == d.salescategory).Select(s => s.SalesCategoryName).FirstOrDefault(),
        //            dealstatus = context.DealStatus.Where(s => s.StatusId.ToString() == d.status).Select(s => s.Status).FirstOrDefault(),
        //            Intent = context.FinanceTypes.Where(ft => ft.FinanceTypeId.ToString() == d.fitype).Select(ft => ft.FinanceType1).FirstOrDefault(),
        //            TurnOption = d.turnoption,
        //            OtherBusinessSource = d.otherbusinesssource,
        //            DaysInStock = d.daysinstock,
        //            dealnum = d.dealnum,
        //            stocknum = d.stocknum,
        //            make = d.make,
        //            model = d.model,
        //            OtherMake = d.makeother,
        //            OtherModel = d.modelother,
        //            year = d.year,
        //            Mileage = d.mileage,
        //            SalesDate = d.salesdate,
        //            //Trade1Status = (record.trade1status == "1") ? "Y" : "N",
        //            SalesManager = context.SalesManagers.Where(sm => sm.SMId.ToString() == d.salesmanager).Select(sm => sm.SMName).FirstOrDefault(),
        //            FinanceManager = context.FinanceManagers.Where(fm => fm.FMId.ToString() == d.fimanager).Select(fm => fm.FMName).FirstOrDefault(),
        //            FinanceType = context.FinanceTypes.Where(ft => ft.FinanceTypeId.ToString() == d.fitype).Select(ft => ft.FinanceType1).FirstOrDefault(),
        //            PaymentIn = d.fipaymentin,
        //            PaymentOut = d.fipaymentout,
        //            TermIn = d.fitermin,
        //            TermOut = d.fitermout,
        //            CashDown = d.ficashdown,
        //            LienHolder = d.lienholder,
        //            DeliveryDate = d.delvdate,
        //            //GradeCredit = d.gradecreditid,
        //            //GradeCreditList = d.gradecreditid,
        //            DateToAccounting = Convert.ToDateTime(d.datetoacct),
        //            Gap = d.gap,
        //            Enviro = d.enviro,
        //            Etch = d.etch,
        //            Dent = d.dent,
        //            Maint = d.Maint,

        //            backend = record.backend,
        //            totalgross = record.totalgross

        //        }).FirstOrDefault();

        //    return record;

        //}
    }
}