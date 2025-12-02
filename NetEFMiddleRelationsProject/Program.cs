using NetEFMiddleRelationsProject;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

using (MiddleContext context = new())
{
    context.Providers.Include(p => p.ProductProviders)
                        .ThenInclude(pp => pp.Product)
                     .Load();
    context.Products.Load();
                            
    ObservableCollection<Provider> providers = 
        context.Providers.Local.ToObservableCollection();
    ObservableCollection<Product> products = 
        context.Products.Local.ToObservableCollection();

    foreach(var provider in providers)
    {
        Console.WriteLine(provider.Name);
        //ObservableCollection<ProductProvider> productProviders =
        //    new(provider.ProductProviders);

        foreach (var p in provider.ProductProviders)
            Console.WriteLine($"\t{p.Product.Name} {p.Price}");
    }


    var selectedProvider = providers.FirstOrDefault();
    var selectedProduct = products.FirstOrDefault(p => p.Id == 11);
    
    ObservableCollection<ProductProvider> providerProducts =
            new(selectedProvider.ProductProviders);

    selectedProvider.ProductProviders.Add
        (
            new()
            {
                Product = selectedProduct,
                Price = 110
            }
        );
    
    context.SaveChanges();

}



//using (MiddleContext context = new())
//{
//    context.Database.EnsureDeleted();
//    context.Database.EnsureCreated();


//    List<Provider> providers = new()
//    {
//        new() { Name = "ProdProv Inc" },
//        new() { Name = "Fermer House" },
//        new() { Name = "Ivanov Products" }
//    };

//    List<Product> products = new()
//    {
//        new(){ Name = "Milk" },
//        new(){ Name = "Patato" },
//        new(){ Name = "Bread" },
//        new(){ Name = "Meat" },
//        new(){ Name = "Chicken" },
//        new(){ Name = "Pasta" },
//        new(){ Name = "Beanz" },
//        new(){ Name = "Apple" },
//        new(){ Name = "Pumpkin" },
//        new(){ Name = "Orange" },
//        new(){ Name = "Carrot" },
//    };

//    context.Products.AddRange(products);
//    context.Providers.AddRange(providers);

//    context.SaveChanges();
//}

//using (MiddleContext context = new())
//{
//    var provider = context.Providers.Find(1);
//    var product = context.Products.Find(3);

//    provider.ProductProviders.Add(new() { Product = context.Products.Find(3), Price = 120 });
//    provider.ProductProviders.Add(new() { Product = context.Products.Find(1), Price = 220 });
//    provider.ProductProviders.Add(new() { Product = context.Products.Find(10), Price = 170 });
//    provider.ProductProviders.Add(new() { Product = context.Products.Find(5), Price = 230 });
//    provider.ProductProviders.Add(new() { Product = context.Products.Find(7), Price = 160 });

//    provider = context.Providers.Find(2);
//    provider.ProductProviders.Add(new() { Product = context.Products.Find(3), Price = 220 });
//    provider.ProductProviders.Add(new() { Product = context.Products.Find(1), Price = 180 });
//    provider.ProductProviders.Add(new() { Product = context.Products.Find(9), Price = 195 });
//    provider.ProductProviders.Add(new() { Product = context.Products.Find(5), Price = 200 });
//    provider.ProductProviders.Add(new() { Product = context.Products.Find(8), Price = 175 });

//    provider = context.Providers.Find(3);
//    provider.ProductProviders.Add(new() { Product = context.Products.Find(2), Price = 190 });
//    provider.ProductProviders.Add(new() { Product = context.Products.Find(3), Price = 185 });
//    provider.ProductProviders.Add(new() { Product = context.Products.Find(6), Price = 250 });
//    provider.ProductProviders.Add(new() { Product = context.Products.Find(9), Price = 215 });
//    provider.ProductProviders.Add(new() { Product = context.Products.Find(4), Price = 195 });

//    context.SaveChanges();
//}
    