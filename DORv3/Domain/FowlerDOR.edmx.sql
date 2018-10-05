
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/27/2018 00:07:09
-- Generated from EDMX file: E:\Repos\Holodeck\DORv3\DORv3\Domain\FowlerDOR.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FowlerDOR];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[MasterFIs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MasterFIs];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[BUSINESSSOURCE]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[BUSINESSSOURCE];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[DealerShip]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[DealerShip];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[Deals]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[Deals];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[DealsbyFinMgr]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[DealsbyFinMgr];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[DealsDetail]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[DealsDetail];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[DealStatus]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[DealStatus];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[DOR_import]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[DOR_import];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[DORHistory]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[DORHistory];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[DORLienHolder]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[DORLienHolder];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[DORProducts]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[DORProducts];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[FinanceManager]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[FinanceManager];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[FinanceType]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[FinanceType];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[FindUnwidDeals]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[FindUnwidDeals];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[finmgrfix]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[finmgrfix];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[GradeCredit]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[GradeCredit];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[Make]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[Make];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[Model]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[Model];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[MonthlyHistory]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[MonthlyHistory];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[mtd_holder]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[mtd_holder];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[OtherIncome]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[OtherIncome];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[OtherProduct]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[OtherProduct];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[Roles]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[Roles];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[RoleScreenXRef]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[RoleScreenXRef];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[SalesCategory]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[SalesCategory];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[SalesManager]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[SalesManager];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[SalesPerson]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[SalesPerson];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[Screens]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[Screens];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[Security]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[Security];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[UserRoleXRef]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[UserRoleXRef];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[Vehicle]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[Vehicle];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[VehicleType]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[VehicleType];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[viewBackouts]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[viewBackouts];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[viewBackoutsDetail]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[viewBackoutsDetail];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[viewCashDealswithFinRes]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[viewCashDealswithFinRes];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[viewDeal]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[viewDeal];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[viewDealswithoutsalesmgr]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[viewDealswithoutsalesmgr];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[viewDORProduct]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[viewDORProduct];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[viewNonCashProdforCashDeals]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[viewNonCashProdforCashDeals];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[viewScreenbytype]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[viewScreenbytype];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[viewScreenTypeOrder]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[viewScreenTypeOrder];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[viewUnwindDateFix]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[viewUnwindDateFix];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[viewUserRole]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[viewUserRole];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[VSales_Recap]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[VSales_Recap];
GO
IF OBJECT_ID(N'[FowlerDORModelStoreContainer].[Year]', 'U') IS NOT NULL
    DROP TABLE [FowlerDORModelStoreContainer].[Year];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'MasterFIs'
CREATE TABLE [dbo].[MasterFIs] (
    [MasterFiId] int IDENTITY(1,1) NOT NULL,
    [DORid] int  NOT NULL,
    [Dealerid] int  NOT NULL,
    [buyerlname] nvarchar(50)  NULL,
    [buyerfname] nvarchar(50)  NULL,
    [cobuyerlname] nvarchar(50)  NULL,
    [cobuyerfname] nvarchar(50)  NULL,
    [vehicle] nvarchar(50)  NULL,
    [vehicletype] nvarchar(50)  NULL,
    [businesssource] nvarchar(50)  NULL,
    [otherbusinesssource] nvarchar(50)  NULL,
    [salescategory] nvarchar(50)  NULL,
    [status] nvarchar(50)  NULL,
    [intent] nvarchar(50)  NULL,
    [turnoption] nvarchar(50)  NULL,
    [dealnum] nvarchar(50)  NULL,
    [stocknum] nvarchar(50)  NULL,
    [make] nvarchar(50)  NULL,
    [model] nvarchar(50)  NULL,
    [year] int  NOT NULL,
    [mileage] int  NOT NULL,
    [salesdate] datetime  NOT NULL,
    [gross] decimal(18,0)  NULL,
    [holdback] decimal(18,0)  NOT NULL,
    [payablegross] decimal(19,4)  NOT NULL,
    [frontendgross] decimal(18,0)  NULL,
    [tradestatus] nvarchar(50)  NULL,
    [trademake] nvarchar(50)  NULL,
    [trademodel] nvarchar(50)  NULL,
    [tradeyear] int  NULL,
    [trademileage] int  NULL,
    [tradeintent] nvarchar(50)  NULL,
    [tradetitle] nvarchar(50)  NULL,
    [tradelien] nvarchar(50)  NULL,
    [tradeacv] decimal(18,0)  NULL,
    [tradepayoff] decimal(18,0)  NULL,
    [salesmanager] nvarchar(50)  NULL,
    [salesperson1] nvarchar(50)  NULL,
    [salesperson2] nvarchar(50)  NULL,
    [fimanager] nvarchar(50)  NOT NULL,
    [fitype] nvarchar(50)  NULL,
    [fipaymentin] nvarchar(50)  NULL,
    [fipaymentout] nvarchar(50)  NULL,
    [fitermin] nvarchar(50)  NULL,
    [fitermout] nvarchar(50)  NULL,
    [ficashdown] decimal(18,0)  NULL,
    [lienholder] nvarchar(max)  NOT NULL,
    [price] decimal(18,0)  NULL,
    [delvdate] datetime  NULL,
    [gap] decimal(18,0)  NULL,
    [enviro] decimal(18,0)  NULL,
    [etch] decimal(18,0)  NULL,
    [dent] decimal(18,0)  NULL,
    [tirewheel] decimal(18,0)  NULL,
    [cl] decimal(18,0)  NULL,
    [ah] decimal(18,0)  NULL,
    [vsc] decimal(18,0)  NULL,
    [vscoption] nvarchar(50)  NULL,
    [TBD] decimal(18,0)  NULL,
    [Maint] decimal(18,0)  NULL,
    [finresv] decimal(18,0)  NULL,
    [frontend] decimal(18,0)  NULL,
    [backend] decimal(18,0)  NULL,
    [totalgross] decimal(18,0)  NULL,
    [creditscore] int  NULL,
    [datetoacct] nvarchar(50)  NULL,
    [bookeddate] nvarchar(50)  NULL,
    [unwinddate] datetime  NULL,
    [datetotag] nvarchar(50)  NULL,
    [datetobank] nvarchar(50)  NULL,
    [datepaid] nvarchar(50)  NULL,
    [sectrade] nvarchar(50)  NULL,
    [amt_fin] decimal(18,0)  NULL,
    [fintype] int  NULL,
    [EnteredDt] datetime  NOT NULL,
    [UpdatedDt] datetime  NOT NULL,
    [daysinstock] int  NULL,
    [makeother] nvarchar(50)  NULL,
    [modelother] nvarchar(50)  NULL,
    [trade1status] nvarchar(50)  NULL,
    [trade1make] nvarchar(50)  NULL,
    [trade1model] nvarchar(50)  NULL,
    [trade1makeother] nvarchar(50)  NULL,
    [trade1modelother] nvarchar(50)  NULL,
    [trade1year] int  NULL,
    [trade1mileage] int  NULL,
    [trade1intent] nvarchar(50)  NULL,
    [trade1title] nvarchar(50)  NULL,
    [trade1lien] nvarchar(50)  NULL,
    [trade1acv] decimal(18,0)  NULL,
    [trade1payoff] decimal(18,0)  NULL,
    [trade1equity] decimal(18,0)  NULL,
    [trade2status] nvarchar(50)  NULL,
    [trade2make] nvarchar(50)  NULL,
    [trade2model] nvarchar(50)  NULL,
    [trade2makeother] nvarchar(50)  NULL,
    [trade2modelother] nvarchar(50)  NULL,
    [trade2year] int  NULL,
    [trade2mileage] int  NULL,
    [trade2intent] nvarchar(50)  NULL,
    [trade2title] nvarchar(50)  NULL,
    [trade2lien] nvarchar(50)  NULL,
    [trade2acv] decimal(18,0)  NULL,
    [trade2payoff] decimal(18,0)  NULL,
    [trade2equity] decimal(18,0)  NULL,
    [salesperson1per] nvarchar(50)  NULL,
    [salesperson2per] nvarchar(50)  NULL,
    [salesperson3] nvarchar(50)  NULL,
    [salesperson3per] nvarchar(50)  NULL,
    [gradecreditid] int  NULL
);
GO

-- Creating table 'BUSINESSSOURCEs'
CREATE TABLE [dbo].[BUSINESSSOURCEs] (
    [BSourceID] int  NOT NULL,
    [BusinessSource1] nvarchar(50)  NULL,
    [DisableDate] datetime  NULL,
    [AddUser] nvarchar(50)  NULL,
    [AddDate] datetime  NULL,
    [UpdateUser] nvarchar(50)  NULL,
    [UpdateDate] datetime  NULL,
    [BusinessSourceID] int  NOT NULL
);
GO

-- Creating table 'DealerShips'
CREATE TABLE [dbo].[DealerShips] (
    [DealerID] int  NOT NULL,
    [DealerName] nvarchar(50)  NOT NULL,
    [DisableDate] datetime  NULL,
    [AddUser] nvarchar(50)  NULL,
    [UpdUser] nvarchar(50)  NULL,
    [AddDate] datetime  NULL,
    [DefaultMakes] nvarchar(100)  NULL,
    [RGBColor] nvarchar(7)  NULL,
    [Color] nvarchar(25)  NULL
);
GO

-- Creating table 'Deals'
CREATE TABLE [dbo].[Deals] (
    [DORId] int  NOT NULL,
    [StatusId] int  NULL,
    [DealNumber] nvarchar(50)  NULL,
    [AddDate] datetime  NULL,
    [DealerId] int  NULL,
    [DeliveryDate] datetime  NULL,
    [Vehicle] nvarchar(50)  NULL,
    [VehicleType] nvarchar(50)  NULL,
    [MakeCalc] nvarchar(50)  NULL,
    [FinanceType] nvarchar(50)  NULL,
    [payablegross] decimal(19,4)  NULL,
    [FinReserve] decimal(19,4)  NULL
);
GO

-- Creating table 'DealsbyFinMgrs'
CREATE TABLE [dbo].[DealsbyFinMgrs] (
    [DORId] int  NOT NULL,
    [StatusId] int  NULL,
    [DealerId] int  NULL,
    [FinanceManagerId] int  NULL,
    [DeliveryDate] datetime  NULL,
    [BEGross] decimal(19,4)  NULL
);
GO

-- Creating table 'DealsDetails'
CREATE TABLE [dbo].[DealsDetails] (
    [DORId] int  NOT NULL,
    [FinanceManagerId] int  NULL,
    [DealerId] int  NULL,
    [SaleDate] datetime  NULL,
    [DeliveryDate] datetime  NULL,
    [Vehicle] nvarchar(50)  NULL,
    [VehicleType] nvarchar(50)  NULL,
    [MakeCalc] nvarchar(50)  NULL,
    [FinanceType] nvarchar(50)  NULL,
    [PName] nvarchar(50)  NULL,
    [PAmount] decimal(19,4)  NULL,
    [Recap] int  NULL
);
GO

-- Creating table 'DealStatus'
CREATE TABLE [dbo].[DealStatus] (
    [StatusId] int  NOT NULL,
    [Status] nvarchar(50)  NULL,
    [DisableDate] datetime  NULL,
    [AddUser] nvarchar(50)  NULL,
    [UpdUser] nvarchar(50)  NULL,
    [AddDate] datetime  NULL
);
GO

-- Creating table 'DOR_import'
CREATE TABLE [dbo].[DOR_import] (
    [DORId] int  NOT NULL,
    [DealerId] int  NULL,
    [AddDate] datetime  NULL,
    [UpdDate] datetime  NULL,
    [fname1] nvarchar(50)  NULL,
    [lname1] nvarchar(50)  NULL,
    [fname2] nvarchar(50)  NULL,
    [lname2] nvarchar(50)  NULL,
    [VehicleId] int  NULL,
    [VehicleTypeId] int  NULL,
    [BSourceId] int  NULL,
    [BSOther] nvarchar(50)  NULL,
    [SaleCategoryId] int  NULL,
    [StatusId] int  NULL,
    [IntentId] int  NULL,
    [TurnOption] nvarchar(50)  NULL,
    [DealNumber] nvarchar(50)  NULL,
    [StockNumber] nvarchar(50)  NULL,
    [Make] nvarchar(50)  NULL,
    [MakeOther] nvarchar(50)  NULL,
    [Model] nvarchar(50)  NULL,
    [ModelOther] nvarchar(50)  NULL,
    [Year] int  NULL,
    [SaleDate] datetime  NULL,
    [FEGross] decimal(19,4)  NULL,
    [Holdback] decimal(19,4)  NULL,
    [payablegross] decimal(19,4)  NULL,
    [Trade1] int  NULL,
    [Trade1Make] nvarchar(50)  NULL,
    [Trade1MakeOther] nvarchar(50)  NULL,
    [Trade1Model] nvarchar(50)  NULL,
    [Trade1ModelOther] nvarchar(50)  NULL,
    [Trade1Year] int  NULL,
    [Trade1Intent] nvarchar(50)  NULL,
    [Trade1Title] int  NULL,
    [Trade1POLHolder] nvarchar(50)  NULL,
    [Trade1ACV] decimal(19,4)  NULL,
    [Trade1PayOff] decimal(19,4)  NULL,
    [Trade1Equity] decimal(19,4)  NULL,
    [Trade2] int  NULL,
    [Trade2Make] nvarchar(50)  NULL,
    [Trade2MakeOther] nvarchar(50)  NULL,
    [Trade2Model] nvarchar(50)  NULL,
    [Trade2ModelOther] nvarchar(50)  NULL,
    [Trade2Year] int  NULL,
    [Trade2Intent] nvarchar(50)  NULL,
    [Trade2Title] int  NULL,
    [Trade2POLHolder] nvarchar(50)  NULL,
    [Trade2ACV] decimal(19,4)  NULL,
    [Trade2PayOff] decimal(19,4)  NULL,
    [Trade2Equity] decimal(19,4)  NULL,
    [SaleManagerId] int  NULL,
    [SalesPerson1Id] int  NULL,
    [SalesPerson1Perc] int  NULL,
    [SalesPerson2Id] int  NULL,
    [SalesPerson2Perc] int  NULL,
    [FinanceManagerId] int  NULL,
    [FinanceTypeId] int  NULL,
    [PaymentIn] decimal(19,4)  NULL,
    [PaymentOut] decimal(19,4)  NULL,
    [TermIn] int  NULL,
    [TermOut] int  NULL,
    [CashDown] decimal(19,4)  NULL,
    [DORLienHolderId] int  NULL,
    [DeliveryDate] datetime  NULL,
    [GradeCreditId] int  NULL,
    [AcctDate] datetime  NULL,
    [BookedDate] datetime  NULL,
    [TagDate] datetime  NULL,
    [BankDate] datetime  NULL,
    [PaidDate] datetime  NULL,
    [FinReserve] decimal(19,4)  NULL,
    [BEGross] decimal(19,4)  NULL,
    [TotGross] decimal(19,4)  NULL,
    [BackoutDate] datetime  NULL,
    [UnwindDate] datetime  NULL,
    [AddUser] nvarchar(50)  NULL,
    [UpdUser] nvarchar(50)  NULL,
    [MakeCalc] nvarchar(50)  NULL,
    [SalesPerson3Perc] int  NULL,
    [SalesPerson3Id] int  NULL,
    [GradeCredit] int  NULL,
    [DateToAcct] datetime  NULL,
    [Mileage] int  NULL,
    [Trade1Mileage] int  NULL,
    [Trade2Mileage] int  NULL,
    [DaysInStock] int  NULL
);
GO

-- Creating table 'DORHistories'
CREATE TABLE [dbo].[DORHistories] (
    [HistoryDORId] int  NOT NULL,
    [DORId] int  NULL,
    [DealerId] int  NULL,
    [AddDate] datetime  NULL,
    [fname1] nvarchar(50)  NULL,
    [lname1] nvarchar(50)  NULL,
    [fname2] nvarchar(50)  NULL,
    [lname2] nvarchar(50)  NULL,
    [VehicleId] int  NULL,
    [VehicleTypeId] int  NULL,
    [BSourceId] int  NULL,
    [BSOther] nvarchar(50)  NULL,
    [SaleCategoryId] int  NULL,
    [StatusId] int  NULL,
    [IntentId] int  NULL,
    [TurnOption] nvarchar(50)  NULL,
    [DealNumber] nvarchar(50)  NULL,
    [StockNumber] nvarchar(50)  NULL,
    [Make] nvarchar(50)  NULL,
    [MakeOther] nvarchar(50)  NULL,
    [Model] nvarchar(50)  NULL,
    [ModelOther] nvarchar(50)  NULL,
    [Year] int  NULL,
    [SaleDate] datetime  NULL,
    [FEGross] decimal(19,4)  NULL,
    [Holdback] decimal(19,4)  NULL,
    [payablegross] decimal(19,4)  NULL,
    [Trade1] int  NULL,
    [Trade1Make] nvarchar(50)  NULL,
    [Trade1MakeOther] nvarchar(50)  NULL,
    [Trade1Model] nvarchar(50)  NULL,
    [Trade1ModelOther] nvarchar(50)  NULL,
    [Trade1Year] int  NULL,
    [Trade1Intent] nvarchar(50)  NULL,
    [Trade1Title] int  NULL,
    [Trade1POLHolder] nvarchar(50)  NULL,
    [Trade1ACV] decimal(19,4)  NULL,
    [Trade1PayOff] decimal(19,4)  NULL,
    [Trade1Equity] decimal(19,4)  NULL,
    [Trade2] int  NULL,
    [Trade2Make] nvarchar(50)  NULL,
    [Trade2MakeOther] nvarchar(50)  NULL,
    [Trade2Model] nvarchar(50)  NULL,
    [Trade2ModelOther] nvarchar(50)  NULL,
    [Trade2Year] int  NULL,
    [Trade2Intent] nvarchar(50)  NULL,
    [Trade2Title] int  NULL,
    [Trade2POLHolder] nvarchar(50)  NULL,
    [Trade2ACV] decimal(19,4)  NULL,
    [Trade2PayOff] decimal(19,4)  NULL,
    [Trade2Equity] decimal(19,4)  NULL,
    [SaleManagerId] int  NULL,
    [SalesPerson1Id] int  NULL,
    [SalesPerson1Perc] int  NULL,
    [SalesPerson2Id] int  NULL,
    [SalesPerson2Perc] int  NULL,
    [FinanceManagerId] int  NULL,
    [FinanceTypeId] int  NULL,
    [PaymentIn] decimal(19,4)  NULL,
    [PaymentOut] decimal(19,4)  NULL,
    [TermIn] int  NULL,
    [TermOut] int  NULL,
    [CashDown] decimal(19,4)  NULL,
    [DORLienHolderId] int  NULL,
    [DeliveryDate] datetime  NULL,
    [GradeCreditId] int  NULL,
    [AcctDate] datetime  NULL,
    [BookedDate] datetime  NULL,
    [TagDate] datetime  NULL,
    [BankDate] datetime  NULL,
    [PaidDate] datetime  NULL,
    [FinReserve] decimal(19,4)  NULL,
    [BEGross] decimal(19,4)  NULL,
    [TotGross] decimal(19,4)  NULL,
    [BackoutDate] datetime  NULL,
    [UnwindDate] datetime  NULL,
    [AddUser] nvarchar(50)  NULL,
    [MakeCalc] nvarchar(50)  NULL,
    [SalesPerson3Perc] int  NULL,
    [SalesPerson3Id] int  NULL,
    [GradeCredit] int  NULL,
    [DateToAcct] datetime  NULL,
    [Mileage] int  NULL,
    [Trade1Mileage] int  NULL,
    [Trade2Mileage] int  NULL
);
GO

-- Creating table 'DORLienHolders'
CREATE TABLE [dbo].[DORLienHolders] (
    [DORLienHolderId] int  NOT NULL,
    [DORLienHolder1] nvarchar(100)  NULL,
    [Dealer] int  NULL,
    [DisableDate] datetime  NULL,
    [AddUser] nvarchar(50)  NULL,
    [UpdUser] nvarchar(50)  NULL,
    [AddDate] datetime  NULL
);
GO

-- Creating table 'DORProducts'
CREATE TABLE [dbo].[DORProducts] (
    [DORProductId] int  NOT NULL,
    [DORId] int  NULL,
    [OtherProductId] int  NULL,
    [PType] nvarchar(50)  NULL,
    [AddDate] nvarchar(50)  NULL,
    [PAmount] decimal(19,4)  NULL,
    [Recap] int  NULL,
    [VSCOption] nvarchar(50)  NULL,
    [UpdateDate] datetime  NULL,
    [AddUser] nvarchar(50)  NULL,
    [UpdUser] nvarchar(50)  NULL
);
GO

-- Creating table 'FinanceManagers'
CREATE TABLE [dbo].[FinanceManagers] (
    [FMId] int  NOT NULL,
    [FMName] nvarchar(60)  NULL,
    [Dealer] int  NULL,
    [DisableDate] datetime  NULL,
    [AddUser] nvarchar(50)  NULL,
    [UpdUser] nvarchar(50)  NULL,
    [AddDate] datetime  NULL
);
GO

-- Creating table 'FinanceTypes'
CREATE TABLE [dbo].[FinanceTypes] (
    [FinanceTypeId] int  NOT NULL,
    [FinanceType1] nvarchar(50)  NULL,
    [DisableDate] datetime  NULL,
    [AddUser] nvarchar(50)  NULL,
    [UpdUser] nvarchar(50)  NULL,
    [AddDate] datetime  NULL
);
GO

-- Creating table 'FindUnwidDeals'
CREATE TABLE [dbo].[FindUnwidDeals] (
    [DORId] int  NOT NULL,
    [StockNumber] nvarchar(50)  NULL,
    [DealerId] int  NULL,
    [DealNumber] nvarchar(50)  NULL,
    [DeliveryDate] datetime  NULL,
    [UnwindDate] datetime  NULL,
    [payablegross] decimal(19,4)  NULL,
    [FinReserve] decimal(19,4)  NULL,
    [BEGross] decimal(19,4)  NULL,
    [TotGross] decimal(19,4)  NULL,
    [FinanceTypeId] int  NULL
);
GO

-- Creating table 'finmgrfixes'
CREATE TABLE [dbo].[finmgrfixes] (
    [DORId] int  NOT NULL,
    [DealerId] int  NULL,
    [DealNumber] nvarchar(50)  NULL,
    [StockNumber] nvarchar(50)  NULL,
    [lname1] nvarchar(50)  NULL,
    [StatusId] int  NULL,
    [DeliveryDate] datetime  NULL,
    [FinanceManagerId] int  NULL
);
GO

-- Creating table 'GradeCredits'
CREATE TABLE [dbo].[GradeCredits] (
    [GradeId] int  NOT NULL,
    [Grade] nvarchar(50)  NULL,
    [DisableDate] datetime  NULL,
    [AddUser] nvarchar(50)  NULL,
    [UpdUser] nvarchar(50)  NULL,
    [AddDate] datetime  NULL
);
GO

-- Creating table 'Makes'
CREATE TABLE [dbo].[Makes] (
    [MakeId] int  NOT NULL,
    [Dealer] int  NULL,
    [Make1] nvarchar(50)  NULL,
    [DisableDate] datetime  NULL,
    [AddUser] nvarchar(50)  NULL,
    [UpdUser] nvarchar(50)  NULL,
    [AddDate] datetime  NULL
);
GO

-- Creating table 'Models'
CREATE TABLE [dbo].[Models] (
    [ModelId] int  NOT NULL,
    [MakeId] int  NULL,
    [Model1] nvarchar(50)  NULL,
    [DisableDate] datetime  NULL,
    [AddUser] nvarchar(50)  NULL,
    [UpdUser] nvarchar(50)  NULL,
    [AddDate] datetime  NULL
);
GO

-- Creating table 'MonthlyHistories'
CREATE TABLE [dbo].[MonthlyHistories] (
    [MonthlyHistId] int  NOT NULL,
    [DealerId] int  NULL,
    [HistDate] datetime  NULL,
    [NewCount] int  NULL,
    [UsedCount] int  NULL,
    [TotalCount] int  NULL
);
GO

-- Creating table 'mtd_holder'
CREATE TABLE [dbo].[mtd_holder] (
    [id] int IDENTITY(1,1) NOT NULL,
    [deal_id] nvarchar(20)  NULL,
    [deal_status] nvarchar(50)  NULL,
    [deal_delv_date] datetime  NULL,
    [deal_stck_num] nvarchar(20)  NULL,
    [deal_mileage] int  NULL,
    [deal_customer] nvarchar(50)  NULL,
    [deal_year] int  NULL,
    [deal_new_used] nvarchar(20)  NULL,
    [deal_FIMgr] nvarchar(50)  NULL,
    [deal_sp_1] nvarchar(60)  NULL,
    [deal_sp_2] nvarchar(60)  NULL,
    [deal_fin_type] nvarchar(50)  NULL,
    [deal_trade_year] int  NULL,
    [deal_trade_model] nvarchar(20)  NULL,
    [deal_title_status] int  NULL,
    [deal_trade_value] int  NULL,
    [deal_dent] decimal(19,4)  NULL,
    [deal_cl] decimal(19,4)  NULL,
    [deal_warr] decimal(19,4)  NULL,
    [deal_gap] decimal(19,4)  NULL,
    [deal_etch] decimal(19,4)  NULL,
    [deal_tw] decimal(19,4)  NULL,
    [deal_enviro] decimal(19,4)  NULL,
    [deal_fin] decimal(19,4)  NULL,
    [deal_frnt_end] decimal(19,4)  NULL
);
GO

-- Creating table 'OtherIncomes'
CREATE TABLE [dbo].[OtherIncomes] (
    [OtherIncomeId] int  NOT NULL,
    [OtherProductId] int  NULL,
    [DealerId] int  NULL,
    [PType] nvarchar(50)  NULL,
    [PAmount] decimal(19,4)  NULL,
    [fname1] nvarchar(50)  NULL,
    [lname1] nvarchar(50)  NULL,
    [AdjDate] datetime  NULL,
    [SaleDate] datetime  NULL,
    [Reason] nvarchar(250)  NULL,
    [AddDate] nvarchar(50)  NULL,
    [DisableDate] datetime  NULL,
    [AddUser] nvarchar(50)  NULL,
    [UpdUser] nvarchar(50)  NULL,
    [DealNum] int  NULL,
    [VSCOption] nvarchar(50)  NULL,
    [FinanceManagerId] int  NULL,
    [UpdDate] datetime  NULL,
    [VehicleTypeId] int  NULL,
    [OtherType] nvarchar(5)  NULL,
    [VehicleId] int  NULL
);
GO

-- Creating table 'OtherProducts'
CREATE TABLE [dbo].[OtherProducts] (
    [OtherProductId] int  NOT NULL,
    [Product] nvarchar(50)  NULL,
    [PName] nvarchar(50)  NULL,
    [PType] nvarchar(50)  NULL,
    [POrder] int  NULL,
    [DisableDate] datetime  NULL,
    [AddUser] nvarchar(50)  NULL,
    [UpdUser] nvarchar(50)  NULL,
    [AddDate] datetime  NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [RoleId] int  NOT NULL,
    [RoleName] nvarchar(100)  NULL,
    [Comment] nvarchar(250)  NULL,
    [AddUser] nvarchar(50)  NULL,
    [UpdUser] nvarchar(50)  NULL,
    [AddDate] datetime  NULL,
    [UpdDate] datetime  NULL
);
GO

-- Creating table 'RoleScreenXRefs'
CREATE TABLE [dbo].[RoleScreenXRefs] (
    [RefId] int  NOT NULL,
    [ScreenId] int  NULL,
    [RoleId] int  NULL,
    [AddDate] datetime  NULL,
    [AddUser] nvarchar(50)  NULL,
    [UpdUser] nvarchar(50)  NULL,
    [UpdDate] datetime  NULL
);
GO

-- Creating table 'SalesCategories'
CREATE TABLE [dbo].[SalesCategories] (
    [SalesCategoryId] int  NOT NULL,
    [SalesCategory1] nvarchar(50)  NULL,
    [DisableDate] datetime  NULL,
    [AddUser] nvarchar(50)  NULL,
    [UpdUser] nvarchar(50)  NULL,
    [AddDate] datetime  NULL
);
GO

-- Creating table 'SalesManagers'
CREATE TABLE [dbo].[SalesManagers] (
    [SMId] int  NOT NULL,
    [SMName] nvarchar(60)  NULL,
    [Dealer] int  NULL,
    [DisableDate] datetime  NULL,
    [AddUser] nvarchar(50)  NULL,
    [UpdUser] nvarchar(50)  NULL,
    [AddDate] datetime  NULL
);
GO

-- Creating table 'SalesPersons'
CREATE TABLE [dbo].[SalesPersons] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [SPtoMasterId] int  NULL,
    [SPName] nvarchar(60)  NULL,
    [Dealer] int  NULL,
    [DisableDate] datetime  NULL,
    [AddUser] nvarchar(50)  NULL,
    [UpdUser] nvarchar(50)  NULL,
    [AddDate] datetime  NULL
);
GO

-- Creating table 'Screens'
CREATE TABLE [dbo].[Screens] (
    [ScreenId] int  NOT NULL,
    [ScreenName] nvarchar(100)  NULL,
    [ScreenType] nvarchar(10)  NULL,
    [ScreenASP] nvarchar(50)  NULL,
    [ScreenOpt] int  NULL,
    [AddUser] nvarchar(50)  NULL,
    [UpdUser] nvarchar(50)  NULL,
    [AddDate] datetime  NULL,
    [UpdDate] datetime  NULL,
    [ScreenOrder] int  NULL
);
GO

-- Creating table 'Securities'
CREATE TABLE [dbo].[Securities] (
    [SecurityId] int  NOT NULL,
    [UserId] nvarchar(50)  NOT NULL,
    [UserName] nvarchar(50)  NULL,
    [UserPass] nvarchar(50)  NULL,
    [DealerShip] int  NULL,
    [DisableDate] datetime  NULL,
    [AddDate] datetime  NULL,
    [UpdDate] datetime  NULL,
    [AddUser] nvarchar(50)  NULL,
    [UpdUser] nvarchar(50)  NULL
);
GO

-- Creating table 'UserRoleXRefs'
CREATE TABLE [dbo].[UserRoleXRefs] (
    [RefId] int  NOT NULL,
    [SecurityId] int  NULL,
    [RoleId] int  NULL,
    [AddDate] datetime  NULL,
    [UpdDate] datetime  NULL,
    [AddUser] nvarchar(50)  NULL,
    [UpdUser] nvarchar(50)  NULL
);
GO

-- Creating table 'Vehicles'
CREATE TABLE [dbo].[Vehicles] (
    [VehicleId] int  NOT NULL,
    [Vehicle1] nvarchar(50)  NULL,
    [DisableDate] datetime  NULL,
    [AddUser] nvarchar(50)  NULL,
    [UpdUser] nvarchar(50)  NULL,
    [AddDate] datetime  NULL
);
GO

-- Creating table 'VehicleTypes'
CREATE TABLE [dbo].[VehicleTypes] (
    [VehicleTypeId] int  NOT NULL,
    [VehicleType1] nvarchar(50)  NULL,
    [DisableDate] datetime  NULL,
    [AddUser] nvarchar(50)  NULL,
    [UpdUser] nvarchar(50)  NULL,
    [AddDate] datetime  NULL
);
GO

-- Creating table 'viewBackouts'
CREATE TABLE [dbo].[viewBackouts] (
    [DORId] int  NOT NULL,
    [DealNumber] nvarchar(50)  NULL,
    [DealerId] int  NULL,
    [StatusId] int  NULL,
    [DeliveryDate] datetime  NULL,
    [payablegross] decimal(19,4)  NULL,
    [BEGross] decimal(19,4)  NULL
);
GO

-- Creating table 'viewBackoutsDetails'
CREATE TABLE [dbo].[viewBackoutsDetails] (
    [DORId] int  NOT NULL,
    [DealerId] int  NULL,
    [AddDate] datetime  NULL,
    [UpdDate] datetime  NULL,
    [BackoutDate] datetime  NULL,
    [SaleDate] datetime  NULL,
    [DeliveryDate] datetime  NULL,
    [VehicleTypeId] int  NULL,
    [StatusId] int  NULL,
    [DealNumber] nvarchar(50)  NULL,
    [StockNumber] nvarchar(50)  NULL
);
GO

-- Creating table 'viewCashDealswithFinRes'
CREATE TABLE [dbo].[viewCashDealswithFinRes] (
    [DORId] int  NOT NULL,
    [DealNumber] nvarchar(50)  NULL,
    [DealerId] int  NULL,
    [FinanceTypeId] int  NULL,
    [FinReserve] decimal(19,4)  NULL,
    [DeliveryDate] datetime  NULL
);
GO

-- Creating table 'viewDeals'
CREATE TABLE [dbo].[viewDeals] (
    [DORId] int  NOT NULL,
    [DealerId] int  NULL,
    [VehicleTypeId] int  NULL,
    [FinanceTypeId] int  NULL,
    [VehicleId] int  NULL,
    [DealNumber] nvarchar(50)  NULL,
    [StockNumber] nvarchar(50)  NULL,
    [lname1] nvarchar(50)  NULL,
    [StatusId] int  NULL,
    [DeliveryDate] datetime  NULL,
    [payablegross] decimal(19,4)  NULL,
    [BEGross] decimal(19,4)  NULL,
    [MakeCalc] nvarchar(50)  NULL
);
GO

-- Creating table 'viewDealswithoutsalesmgrs'
CREATE TABLE [dbo].[viewDealswithoutsalesmgrs] (
    [DORId] int  NOT NULL,
    [DealerId] int  NULL,
    [DealNumber] nvarchar(50)  NULL,
    [StockNumber] nvarchar(50)  NULL,
    [lname1] nvarchar(50)  NULL,
    [StatusId] int  NULL,
    [DeliveryDate] datetime  NULL,
    [SaleManagerId] int  NULL
);
GO

-- Creating table 'viewDORProducts'
CREATE TABLE [dbo].[viewDORProducts] (
    [DORProductId] int  NOT NULL,
    [DORId] int  NULL
);
GO

-- Creating table 'viewNonCashProdforCashDeals'
CREATE TABLE [dbo].[viewNonCashProdforCashDeals] (
    [DORId] int  NOT NULL,
    [DealNumber] nvarchar(50)  NULL,
    [DealerId] int  NULL,
    [StatusId] int  NULL,
    [DeliveryDate] datetime  NULL,
    [FinanceTypeId] int  NULL,
    [Recap] int  NULL,
    [PAmount] decimal(19,4)  NULL,
    [OtherProductId] int  NULL
);
GO

-- Creating table 'viewScreenbytypes'
CREATE TABLE [dbo].[viewScreenbytypes] (
    [ScreenId] int  NOT NULL,
    [ScreenName] nvarchar(100)  NULL,
    [ScreenType] nvarchar(10)  NULL,
    [ScreenOrder] int  NULL
);
GO

-- Creating table 'viewScreenTypeOrders'
CREATE TABLE [dbo].[viewScreenTypeOrders] (
    [ScreenId] int  NOT NULL,
    [ScreenName] nvarchar(100)  NULL,
    [ScreenType] nvarchar(10)  NULL,
    [ScreenOrder] int  NULL
);
GO

-- Creating table 'viewUnwindDateFixes'
CREATE TABLE [dbo].[viewUnwindDateFixes] (
    [DealerId] int  NULL,
    [DORId] int  NOT NULL,
    [StatusId] int  NULL,
    [DeliveryDate] datetime  NULL,
    [UnwindDate] datetime  NULL,
    [lname1] nvarchar(50)  NULL,
    [AddUser] nvarchar(50)  NULL,
    [UpdUser] nvarchar(50)  NULL,
    [BackoutDate] datetime  NULL
);
GO

-- Creating table 'viewUserRoles'
CREATE TABLE [dbo].[viewUserRoles] (
    [UserId] nvarchar(50)  NULL,
    [UserName] nvarchar(50)  NULL,
    [DealerShip] int  NULL,
    [RoleId] int  NULL,
    [SecurityId] int  NOT NULL,
    [DisableDate] datetime  NULL
);
GO

-- Creating table 'VSales_Recap'
CREATE TABLE [dbo].[VSales_Recap] (
    [SalesRecapRecordID] int IDENTITY(1,1) NOT NULL,
    [dealership] nvarchar(50)  NULL,
    [dealer_id] int  NULL,
    [new_cars] int  NULL,
    [new_trucks] int  NULL,
    [new_suvs] int  NULL,
    [used_vehicles] int  NULL,
    [total_vehicles] int  NULL,
    [cash] int  NULL,
    [nc_cash_per] int  NULL,
    [nt_cash_per] int  NULL,
    [ns_cash_per] int  NULL,
    [uv_cash_per] int  NULL,
    [conv] int  NULL,
    [nc_conv_per] int  NULL,
    [nt_conv_per] int  NULL,
    [ns_conv_per] int  NULL,
    [uv_conv_per] int  NULL,
    [rbf] int  NULL,
    [nc_rbf_per] int  NULL,
    [nt_rbf_per] int  NULL,
    [ns_rbf_per] int  NULL,
    [uv_rbf_per] int  NULL,
    [osf] int  NULL,
    [nc_osf_per] int  NULL,
    [nt_osf_per] int  NULL,
    [ns_osf_per] int  NULL,
    [uv_osf_per] int  NULL,
    [ave_nc_front] int  NULL,
    [ave_nt_front] int  NULL,
    [ave_ns_front] int  NULL,
    [ave_nv_front] int  NULL,
    [ave_uv_front] int  NULL,
    [ave_nc_back] int  NULL,
    [ave_nt_back] int  NULL,
    [ave_ns_back] int  NULL,
    [ave_nv_back] int  NULL,
    [ave_uv_back] int  NULL,
    [tot_income] int  NULL,
    [avg_front] int  NULL,
    [avg_fi_gross] int  NULL,
    [avg_f_b] int  NULL
);
GO

-- Creating table 'Years'
CREATE TABLE [dbo].[Years] (
    [YearId] int  NOT NULL,
    [Year1] int  NULL,
    [DisableDate] datetime  NULL,
    [AddUser] nvarchar(50)  NULL,
    [UpdUser] nvarchar(50)  NULL,
    [AddDate] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MasterFiId] in table 'MasterFIs'
ALTER TABLE [dbo].[MasterFIs]
ADD CONSTRAINT [PK_MasterFIs]
    PRIMARY KEY CLUSTERED ([MasterFiId] ASC);
GO

-- Creating primary key on [BSourceID], [BusinessSourceID] in table 'BUSINESSSOURCEs'
ALTER TABLE [dbo].[BUSINESSSOURCEs]
ADD CONSTRAINT [PK_BUSINESSSOURCEs]
    PRIMARY KEY CLUSTERED ([BSourceID], [BusinessSourceID] ASC);
GO

-- Creating primary key on [DealerID], [DealerName] in table 'DealerShips'
ALTER TABLE [dbo].[DealerShips]
ADD CONSTRAINT [PK_DealerShips]
    PRIMARY KEY CLUSTERED ([DealerID], [DealerName] ASC);
GO

-- Creating primary key on [DORId] in table 'Deals'
ALTER TABLE [dbo].[Deals]
ADD CONSTRAINT [PK_Deals]
    PRIMARY KEY CLUSTERED ([DORId] ASC);
GO

-- Creating primary key on [DORId] in table 'DealsbyFinMgrs'
ALTER TABLE [dbo].[DealsbyFinMgrs]
ADD CONSTRAINT [PK_DealsbyFinMgrs]
    PRIMARY KEY CLUSTERED ([DORId] ASC);
GO

-- Creating primary key on [DORId] in table 'DealsDetails'
ALTER TABLE [dbo].[DealsDetails]
ADD CONSTRAINT [PK_DealsDetails]
    PRIMARY KEY CLUSTERED ([DORId] ASC);
GO

-- Creating primary key on [StatusId] in table 'DealStatus'
ALTER TABLE [dbo].[DealStatus]
ADD CONSTRAINT [PK_DealStatus]
    PRIMARY KEY CLUSTERED ([StatusId] ASC);
GO

-- Creating primary key on [DORId] in table 'DOR_import'
ALTER TABLE [dbo].[DOR_import]
ADD CONSTRAINT [PK_DOR_import]
    PRIMARY KEY CLUSTERED ([DORId] ASC);
GO

-- Creating primary key on [HistoryDORId] in table 'DORHistories'
ALTER TABLE [dbo].[DORHistories]
ADD CONSTRAINT [PK_DORHistories]
    PRIMARY KEY CLUSTERED ([HistoryDORId] ASC);
GO

-- Creating primary key on [DORLienHolderId] in table 'DORLienHolders'
ALTER TABLE [dbo].[DORLienHolders]
ADD CONSTRAINT [PK_DORLienHolders]
    PRIMARY KEY CLUSTERED ([DORLienHolderId] ASC);
GO

-- Creating primary key on [DORProductId] in table 'DORProducts'
ALTER TABLE [dbo].[DORProducts]
ADD CONSTRAINT [PK_DORProducts]
    PRIMARY KEY CLUSTERED ([DORProductId] ASC);
GO

-- Creating primary key on [FMId] in table 'FinanceManagers'
ALTER TABLE [dbo].[FinanceManagers]
ADD CONSTRAINT [PK_FinanceManagers]
    PRIMARY KEY CLUSTERED ([FMId] ASC);
GO

-- Creating primary key on [FinanceTypeId] in table 'FinanceTypes'
ALTER TABLE [dbo].[FinanceTypes]
ADD CONSTRAINT [PK_FinanceTypes]
    PRIMARY KEY CLUSTERED ([FinanceTypeId] ASC);
GO

-- Creating primary key on [DORId] in table 'FindUnwidDeals'
ALTER TABLE [dbo].[FindUnwidDeals]
ADD CONSTRAINT [PK_FindUnwidDeals]
    PRIMARY KEY CLUSTERED ([DORId] ASC);
GO

-- Creating primary key on [DORId] in table 'finmgrfixes'
ALTER TABLE [dbo].[finmgrfixes]
ADD CONSTRAINT [PK_finmgrfixes]
    PRIMARY KEY CLUSTERED ([DORId] ASC);
GO

-- Creating primary key on [GradeId] in table 'GradeCredits'
ALTER TABLE [dbo].[GradeCredits]
ADD CONSTRAINT [PK_GradeCredits]
    PRIMARY KEY CLUSTERED ([GradeId] ASC);
GO

-- Creating primary key on [MakeId] in table 'Makes'
ALTER TABLE [dbo].[Makes]
ADD CONSTRAINT [PK_Makes]
    PRIMARY KEY CLUSTERED ([MakeId] ASC);
GO

-- Creating primary key on [ModelId] in table 'Models'
ALTER TABLE [dbo].[Models]
ADD CONSTRAINT [PK_Models]
    PRIMARY KEY CLUSTERED ([ModelId] ASC);
GO

-- Creating primary key on [MonthlyHistId] in table 'MonthlyHistories'
ALTER TABLE [dbo].[MonthlyHistories]
ADD CONSTRAINT [PK_MonthlyHistories]
    PRIMARY KEY CLUSTERED ([MonthlyHistId] ASC);
GO

-- Creating primary key on [id] in table 'mtd_holder'
ALTER TABLE [dbo].[mtd_holder]
ADD CONSTRAINT [PK_mtd_holder]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [OtherIncomeId] in table 'OtherIncomes'
ALTER TABLE [dbo].[OtherIncomes]
ADD CONSTRAINT [PK_OtherIncomes]
    PRIMARY KEY CLUSTERED ([OtherIncomeId] ASC);
GO

-- Creating primary key on [OtherProductId] in table 'OtherProducts'
ALTER TABLE [dbo].[OtherProducts]
ADD CONSTRAINT [PK_OtherProducts]
    PRIMARY KEY CLUSTERED ([OtherProductId] ASC);
GO

-- Creating primary key on [RoleId] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [RefId] in table 'RoleScreenXRefs'
ALTER TABLE [dbo].[RoleScreenXRefs]
ADD CONSTRAINT [PK_RoleScreenXRefs]
    PRIMARY KEY CLUSTERED ([RefId] ASC);
GO

-- Creating primary key on [SalesCategoryId] in table 'SalesCategories'
ALTER TABLE [dbo].[SalesCategories]
ADD CONSTRAINT [PK_SalesCategories]
    PRIMARY KEY CLUSTERED ([SalesCategoryId] ASC);
GO

-- Creating primary key on [SMId] in table 'SalesManagers'
ALTER TABLE [dbo].[SalesManagers]
ADD CONSTRAINT [PK_SalesManagers]
    PRIMARY KEY CLUSTERED ([SMId] ASC);
GO

-- Creating primary key on [ID] in table 'SalesPersons'
ALTER TABLE [dbo].[SalesPersons]
ADD CONSTRAINT [PK_SalesPersons]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ScreenId] in table 'Screens'
ALTER TABLE [dbo].[Screens]
ADD CONSTRAINT [PK_Screens]
    PRIMARY KEY CLUSTERED ([ScreenId] ASC);
GO

-- Creating primary key on [SecurityId], [UserId] in table 'Securities'
ALTER TABLE [dbo].[Securities]
ADD CONSTRAINT [PK_Securities]
    PRIMARY KEY CLUSTERED ([SecurityId], [UserId] ASC);
GO

-- Creating primary key on [RefId] in table 'UserRoleXRefs'
ALTER TABLE [dbo].[UserRoleXRefs]
ADD CONSTRAINT [PK_UserRoleXRefs]
    PRIMARY KEY CLUSTERED ([RefId] ASC);
GO

-- Creating primary key on [VehicleId] in table 'Vehicles'
ALTER TABLE [dbo].[Vehicles]
ADD CONSTRAINT [PK_Vehicles]
    PRIMARY KEY CLUSTERED ([VehicleId] ASC);
GO

-- Creating primary key on [VehicleTypeId] in table 'VehicleTypes'
ALTER TABLE [dbo].[VehicleTypes]
ADD CONSTRAINT [PK_VehicleTypes]
    PRIMARY KEY CLUSTERED ([VehicleTypeId] ASC);
GO

-- Creating primary key on [DORId] in table 'viewBackouts'
ALTER TABLE [dbo].[viewBackouts]
ADD CONSTRAINT [PK_viewBackouts]
    PRIMARY KEY CLUSTERED ([DORId] ASC);
GO

-- Creating primary key on [DORId] in table 'viewBackoutsDetails'
ALTER TABLE [dbo].[viewBackoutsDetails]
ADD CONSTRAINT [PK_viewBackoutsDetails]
    PRIMARY KEY CLUSTERED ([DORId] ASC);
GO

-- Creating primary key on [DORId] in table 'viewCashDealswithFinRes'
ALTER TABLE [dbo].[viewCashDealswithFinRes]
ADD CONSTRAINT [PK_viewCashDealswithFinRes]
    PRIMARY KEY CLUSTERED ([DORId] ASC);
GO

-- Creating primary key on [DORId] in table 'viewDeals'
ALTER TABLE [dbo].[viewDeals]
ADD CONSTRAINT [PK_viewDeals]
    PRIMARY KEY CLUSTERED ([DORId] ASC);
GO

-- Creating primary key on [DORId] in table 'viewDealswithoutsalesmgrs'
ALTER TABLE [dbo].[viewDealswithoutsalesmgrs]
ADD CONSTRAINT [PK_viewDealswithoutsalesmgrs]
    PRIMARY KEY CLUSTERED ([DORId] ASC);
GO

-- Creating primary key on [DORProductId] in table 'viewDORProducts'
ALTER TABLE [dbo].[viewDORProducts]
ADD CONSTRAINT [PK_viewDORProducts]
    PRIMARY KEY CLUSTERED ([DORProductId] ASC);
GO

-- Creating primary key on [DORId] in table 'viewNonCashProdforCashDeals'
ALTER TABLE [dbo].[viewNonCashProdforCashDeals]
ADD CONSTRAINT [PK_viewNonCashProdforCashDeals]
    PRIMARY KEY CLUSTERED ([DORId] ASC);
GO

-- Creating primary key on [ScreenId] in table 'viewScreenbytypes'
ALTER TABLE [dbo].[viewScreenbytypes]
ADD CONSTRAINT [PK_viewScreenbytypes]
    PRIMARY KEY CLUSTERED ([ScreenId] ASC);
GO

-- Creating primary key on [ScreenId] in table 'viewScreenTypeOrders'
ALTER TABLE [dbo].[viewScreenTypeOrders]
ADD CONSTRAINT [PK_viewScreenTypeOrders]
    PRIMARY KEY CLUSTERED ([ScreenId] ASC);
GO

-- Creating primary key on [DORId] in table 'viewUnwindDateFixes'
ALTER TABLE [dbo].[viewUnwindDateFixes]
ADD CONSTRAINT [PK_viewUnwindDateFixes]
    PRIMARY KEY CLUSTERED ([DORId] ASC);
GO

-- Creating primary key on [SecurityId] in table 'viewUserRoles'
ALTER TABLE [dbo].[viewUserRoles]
ADD CONSTRAINT [PK_viewUserRoles]
    PRIMARY KEY CLUSTERED ([SecurityId] ASC);
GO

-- Creating primary key on [SalesRecapRecordID] in table 'VSales_Recap'
ALTER TABLE [dbo].[VSales_Recap]
ADD CONSTRAINT [PK_VSales_Recap]
    PRIMARY KEY CLUSTERED ([SalesRecapRecordID] ASC);
GO

-- Creating primary key on [YearId] in table 'Years'
ALTER TABLE [dbo].[Years]
ADD CONSTRAINT [PK_Years]
    PRIMARY KEY CLUSTERED ([YearId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------