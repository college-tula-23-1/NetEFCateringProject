using NetEFCateringProject.Models;

using (CateringContext context = new())
{
    await context.Database.EnsureDeletedAsync();
    await context.Database.EnsureCreatedAsync();
}