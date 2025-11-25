using NetEFLazyLoadingProject;

using(LazyContext context = new())
{
    //context.Database.EnsureDeleted();
    //context.Database.EnsureCreated();
    //EmployeesInit(context);

    var employees = context.Employees.ToList();

    foreach(var e in employees)
        Console.WriteLine(e);
}

void EmployeesInit(LazyContext context)
{
    Company yandex = new() { Name = "Yandex" };
    Company avito = new() { Name = "Avito" };
    Company microsoft = new() { Name = "Microsoft" };

    Employee bobby = new()
    {
        Name = "Bobby",
        Age = 28,
        Company = yandex,
    };

    Employee sammy = new()
    {
        Name = "Sammy",
        Age = 31,
        Company = avito,
    };

    Employee kenny = new()
    {
        Name = "Kenny",
        Age = 26,
        Company = microsoft,
    };

    Employee jimmy = new()
    {
        Name = "Jimmy",
        Age = 25,
        Company = yandex,
    };

    Employee lenny = new()
    {
        Name = "Lenny",
        Age = 33,
        Company = avito,
    };

    context.Employees.AddRange(bobby, jimmy, sammy, lenny, kenny);

    context.SaveChanges();
}