# Robo_Apocalypser

ROBOT apocalypse
The year is 2050 and the world as we know it has been taken over by robots.
Created as once friendly robots, have now turned against humankind, especially software engineers like yourself.
Their mission is to transform everyone into mindless zombies for their entertainment.

How to Run Application
  
  Setp 1. Create Database(name like Robot_Apocalypser) to you sql server
  Step 2. Create  tables Survivor, Inventory and SurvivorContamination using the scripts given below- 
      2.a  
               
               CREATE TABLE [dbo].[Survivor] (
            [Id]           INT            IDENTITY (1, 1) NOT NULL,
            [Name]         NVARCHAR (250) NOT NULL,
            [Age]          INT            NOT NULL,
            [Gender]       NVARCHAR (50)  NOT NULL,
            [SurvivorID]   NVARCHAR (50)  NULL,
            [LocationLat]  NVARCHAR (50)  NULL,
            [LocationLong] NVARCHAR (50)  NOT NULL,
            [IsInfected]   BIT            NOT NULL,
            PRIMARY KEY CLUSTERED ([Id] ASC)
            );
            
      2.b 
     
                 CREATE TABLE [dbo].[Inventory] (
                [Id]            INT           IDENTITY (1, 1) NOT NULL,
                [InventoryName] VARCHAR (150) NOT NULL,
                [NoOfDays]      INT           NOT NULL,
                [SurvivorId]    INT           NOT NULL,
                PRIMARY KEY CLUSTERED ([Id] ASC),
                CONSTRAINT [FK_Inventory_Survivor] FOREIGN KEY ([SurvivorId]) REFERENCES [dbo].[Survivor] ([Id])
            );
            
     2.c   
                 CREATE TABLE [dbo].[SurvivorContamination] (
                [Id]                 INT           IDENTITY (1, 1) NOT NULL,
                [SurvivorId]         NVARCHAR (50) NOT NULL,
                [ReporterSurvivorId] NVARCHAR (50) NOT NULL,
                PRIMARY KEY CLUSTERED ([Id] ASC)
            );
            
  Step 3.       Clone the repository to your local machine and build  it with vs2019
  Step 4.       Run Scaffold-DbContext command given below in package manager console
                Scaffold-DbContext "<<Your Db connection string>>" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -f
                         where <<Your Db connection string>> would be your connection string
                 This command will create the entities classes for you tables in Models folder of DAL layer.
                 While running this command please make sure "ROBOT_Apocalypser_DAL" should be selected as default project in package manager console
         
  
  step 5.      Run  application using VS2019
  
  step 6.      Swagger page would be display which conatins documentation of all required apis.
  
  
  

                 






