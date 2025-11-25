using NetEFInheritProject;

using (InheritContext context = new())
{
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();

    PersonsInit(context);

}


void PersonsInit(InheritContext context)
{
    Person bob = new() 
    { 
        Name = "Bobby", 
        Age = 28 
    };

    Person sam = new()
    {
        Name = "Sammy",
        Age = 31
    };

    Teacher leo = new()
    {
        Name = "Lenny",
        Age = 27,
        Experience = 4
    };

    Teacher poul = new()
    {
        Name = "Poully",
        Age = 42,
        Experience = 15
    };

    Doctor tim = new()
    {
        Name = "Timmy",
        Age = 35,
        Specialty = "Surgeon"
    };

    Doctor ben = new()
    {
        Name = "Benny",
        Age = 29,
        Specialty = "Dentist"
    };

    context.Persons.AddRange(bob, sam);
    context.Teachers.AddRange(leo, poul);
    context.Doctors.AddRange(tim, ben);

    context.SaveChanges();
}