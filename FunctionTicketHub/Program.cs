using FunctionTicketHub;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
    })
    .Build();

host.Run();

//note: Create table string
///CREATE TABLE Tickets (
//TicketID INT IDENTITY(1,1) PRIMARY KEY,
//ConcertID INT NOT NULL,
//Email NVARCHAR(255) NOT NULL,
//Name NVARCHAR(60) NOT NULL,
//Phone NVARCHAR(50) NOT NULL,
//Quantity INT NOT NULL CHECK (Quantity BETWEEN 1 AND 12),
//CreditCard NVARCHAR(30) NOT NULL,
//Expiration CHAR(5) NOT NULL CHECK (Expiration LIKE '__/__'),
//SecurityCode NVARCHAR(4) NOT NULL CHECK (LEN(SecurityCode) BETWEEN 3 AND 4),
//Address NVARCHAR(200) NOT NULL,
//City NVARCHAR(100) NOT NULL,
//Province NVARCHAR(100) NOT NULL,
//PostalCode CHAR(7) NOT NULL CHECK (PostalCode LIKE '[A-Z][0-9][A-Z] [0-9][A-Z][0-9]'),
//Country NVARCHAR(100) NOT NULL
//);