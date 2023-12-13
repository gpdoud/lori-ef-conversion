
using System.ComponentModel.DataAnnotations.Schema;

namespace lori_ef_conversion;

public class Invoice {
    public int Id { get; set; }
    public int Lines { get; set; }
    [Column(TypeName = "decimal(7,2)")]
    public decimal TotAmt { get; set; }
    public string FFname { get; set; }
    public string CurDate { get; set; }
    public string InvoiceNbr { get; set; }
    public string InvDate { get; set; }
    public string ItemNbr { get; set; }
    public int Quantity { get; set; }
    [Column(TypeName = "decimal(7,2)")]
    public decimal UnitPrice { get; set; }
    [Column(TypeName = "decimal(7,2)")]
    public decimal ItemSalesAmt { get; set; }

}
