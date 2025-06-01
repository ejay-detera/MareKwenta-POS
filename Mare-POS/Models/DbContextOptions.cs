using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Mare_POS.Models;

// 1. Get connection string from App.config
string connectionString = ConfigurationManager.ConnectionStrings["MyDbContext"].ConnectionString;

// 2. Build the DbContextOptions
var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

// 3. Pass the options into your context
using var context = new MyDbContext(optionsBuilder.Options);

// 4. Now you can use your context like normal
var users = context.Employees.ToList();
