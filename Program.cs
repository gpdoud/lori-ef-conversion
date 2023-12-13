using lori_ef_conversion;

Console.WriteLine("Lori w/EF");

var context = new AppDbContext();

var fileLines = new Dictionary<string, List<string>>();

var companyList = (from inv in context.Invoices
                   orderby inv.FFname
                   select new {
                       inv.FFname
                   }).Distinct();

foreach(var company in companyList.ToList()) {

    var invoiceList = (from inv in context.Invoices
                       where inv.FFname == company.FFname
                       orderby inv.InvoiceNbr
                       select new {
                           Name = inv.FFname, Invoice = inv.InvoiceNbr
                       }).Distinct();

    var lines = new List<string>();

    foreach(var inv in invoiceList.ToList()) {

        lines.Add($"H N:{inv.Name}, I:{inv.Invoice} ");
        var total = 0m;
        foreach(var item in context.Invoices.Where(x => x.InvoiceNbr == inv.Invoice).ToList()) {
            lines.Add($"D I:{item.ItemNbr}, Q:{item.Quantity}, P:{item.UnitPrice:C}, LT:{item.Quantity * item.UnitPrice:C}");
            total += item.Quantity * item.UnitPrice;
        }
        lines.Add($"S TOTAL:{total:C}\n");
    }

    fileLines.Add(company.FFname, lines);
}

foreach(var company in fileLines.Keys) {
    var fullpath = Path.Combine(Directory.GetCurrentDirectory(), "../../..", $"{company}.txt");
    File.WriteAllLines(fullpath, fileLines[company]);
}