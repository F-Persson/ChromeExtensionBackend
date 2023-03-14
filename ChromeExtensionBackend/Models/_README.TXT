Add SQL Server Database Project to ChromeExtensionBackend

Add a "SQL Server Database Project" to the Solution. Give the project the
    same name as the database + "Project". For example: ChromeExtensionBackendDbProject.

added table with quires
----------------------------
CREATE TABLE [dbo].[TagItems] (
    [TagItemId]        INT            IDENTITY (1, 1) NOT NULL,
    [Time]            NVARCHAR (MAX) NOT NULL,
    [Selection]       NVARCHAR (MAX) NOT NULL,
    [Url]             NVARCHAR (MAX) NOT NULL,
    [Title]           NVARCHAR (MAX) NOT NULL,
    [IsEditing]       BIT            NOT NULL,
    [IsFlipped]       BIT            NOT NULL,
    [IsShowing]       BIT            NOT NULL,
    [MetaDescription] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_TagItems] PRIMARY KEY CLUSTERED ([TagItemId] ASC)
);

CREATE TABLE [dbo].[Tags] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [TagItemId]       INT            NOT NULL,
    [Tag]             NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Tag_TagItems_TagItemId] FOREIGN KEY ([TagItemId]) REFERENCES [dbo].[TagItems] ([TagItemId])
);
----------------------------
Create the actual database

create database 
    ChromeExtensionBackendDb
collate 
    Finnish_Swedish_CI_AI

    ----------------------------
Add the database to the ChromeExtensionBackendDbProject - right click on the project and select publish
 uncheck the option "Block incremental deployment if data loss might
    occur" found via the "Advanced button".
-- Had to change the ChromeExtensionBackendDbProject to 2019


----------------------------
install 
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design #powershell
dotnet add package Microsoft.EntityFrameworkCore.Design #powershell
dotnet add package Microsoft.EntityFrameworkCore.SqlServer #powershell
dotnet add package Microsoft.EntityFrameworkCore.Tools #powershell

dotnet tool uninstall -g dotnet-aspnet-codegenerator
dotnet tool install -g dotnet-aspnet-codegenerator
----------------------------

Add the connection strnig of the database to the appsettings.json file

----------------------------

Scaffold the database - from package manager console

 Scaffold-DbContext -Connection name=DefaultConnection -Provider Microsoft.EntityFrameworkCore.SqlServer -Project "ChromeExtensionBackend" -OutputDir "Models/Entities" -Context "TagItemContext" -NoOnConfiguring -Force

Scaffold controller

dotnet-aspnet-codegenerator controller -name TagItemsController -async -api -m TagItem -dc TodoContext -outDir Controllers
----------------------------

In Program.cs:

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<TagItemContext>(
                options => options.UseSqlServer(connectionString));


----------------------------



#Publish the database to ChromeExtensionBackend


using Microsoft.EntityFrameworkCore;

namespace ChromeExtensionBackend.Models
{
    public class TagItemContext : DbContext
    {
        public TagItemContext(DbContextOptions<TagItemContext> options)
            : base(options)
        {
        }

        public DbSet<TagItem> TagItems { get; set; }
    }
}
