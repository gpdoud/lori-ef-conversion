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

tvr.TextOutput();

