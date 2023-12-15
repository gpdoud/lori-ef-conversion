using Microsoft.Data.SqlClient;

using TableViewRepository;

Console.WriteLine("Lori w/EF");

TableViewReader tvr = new TableViewReader {
    Server = "ripper",
    Instance = "sqlexpress",
    Database = "LoriDb",
    UserId = "dsi",
    Password = "dsiadmin",
    SQL = "SELECT * From Invoices order by FFname, InvoiceNbr;"
};

tvr.ExecuteRead();
var cols = new string[] {
    "FFname", "Lines", "TotAmt", "CurDate", "InvoiceNbr",
    "InvDate", "ItemNbr", "Quantity", "UnitPrice", "ItemSalesAmt"
};
var recordList = tvr.TextOutput(cols);

foreach(var record in recordList) {
    Console.WriteLine($"{record}");
}
