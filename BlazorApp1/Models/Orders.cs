using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Models;

[Keyless]
[Table("vw_OrderTotals")]
public class OrderTotal
{
    [Column("order_id")]
    public int OrderId { get; set; }

    [Column("order_date")]
    public DateOnly OrderDate { get; set; }

    [Column("customer_id")]
    public int CustomerId { get; set; }

    [Column("customer_name")]
    public string? CustomerName { get; set; }

    [Column("total_price")]
    public decimal TotalPrice { get; set; }
}