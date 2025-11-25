using Microsoft.EntityFrameworkCore;
using NetEFReferencesProject;

using (ProjectContext context = new())
{
    await context.Database.EnsureDeletedAsync();
    await context.Database.EnsureCreatedAsync();
    //EmployeesInit(context);

    //var companies = context.Companies.ToList();

    //var employees = context.Employees
    //                       .Include(e => e.Company)
    //                            .ThenInclude(c => c.Country)
    //                                .ThenInclude(c => c.Capital)
    //                       .Include(e => e.Position)
    //                       .ToList();

    //var company = context.Companies.FirstOrDefault();
    //context.Employees
    //       .Where(e => e.Company.Name == "Yandex")
    //       .Load();

    //var employees = context.Employees;

    //foreach (var employee in employees)
    //    Console.WriteLine(employee);
    //Console.WriteLine();

    //var company = context.Companies
    //                     .FirstOrDefault();
    //if(company is not null)
    //{
    //    context.Entry(company)
    //           .Collection(c => c.Employees).Load();

    //    Console.WriteLine(company);
    //    foreach(var e in company.Employees)
    //        Console.WriteLine($"\t{e}");
    //}

    //var employee = context.Employees.FirstOrDefault();
    //if(employee is not null)
    //{
    //    context.Entry(employee)
    //           .Reference(e => e.Company);
    //    Console.WriteLine(employee);
    //}
}

void EmployeesInit(ProjectContext context)
{
    City moscow = new() { Name = "Moscow" };
    City washington = new() { Name = "Washington" };

    Country russia = new() { Name = "Russia", Capital = moscow };
    Country usa = new() { Name = "Usa", Capital = washington };

    Company yandex = new() { Name = "Yandex", Country = russia };
    Company avito = new() { Name = "Avito", Country = russia };
    Company microsoft = new() { Name = "Microsoft", Country = usa };

    Position manager = new() { Name = "Manager" };
    Position developer = new() { Name = "Developer" };

    Employee bobby = new()
    {
        Name = "Bobby",
        Age = 28,
        Company = yandex,
        Position = manager,
    };

    Employee sammy = new()
    {
        Name = "Sammy",
        Age = 31,
        Company = avito,
        Position = developer,
    };

    Employee kenny = new()
    {
        Name = "Kenny",
        Age = 26,
        Company = microsoft,
        Position = manager,
    };

    Employee jimmy = new()
    {
        Name = "Jimmy",
        Age = 25,
        Company = yandex,
        Position = developer,
    };

    Employee lenny = new()
    {
        Name = "Lenny",
        Age = 33,
        Company = avito,
        Position = manager,
    };

    context.Employees.AddRange(bobby, jimmy, sammy, lenny, kenny);

    context.SaveChanges();
}

void CompaniesInit(ProjectContext context)
{
    Employee bobby = new()
    {
        Name = "Bobby",
        Age = 28
    };

    Employee sammy = new()
    {
        Name = "Sammy",
        Age = 31
    };

    Employee jimmy = new()
    {
        Name = "Jimmy",
        Age = 25
    };

    Employee lenny = new()
    {
        Name = "Lenny",
        Age = 33
    };

    Company yandex = new()
    {
        Name = "Yandex",
        Employees = new() { bobby, sammy }
    };

    Company ozon = new()
    {
        Name = "Ozon",
        Employees = new() { lenny, jimmy }
    };

    context.Companies.AddRange(yandex, ozon);
    context.Employees.AddRange(bobby, jimmy, sammy, lenny);

    context.SaveChanges();
}