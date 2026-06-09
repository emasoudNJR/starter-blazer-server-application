using Microsoft.EntityFrameworkCore;
using BlazorApp1.Data;
using BlazorApp1.Models;

namespace BlazorApp1.Services;

public class OrderService
{
    private readonly IDbContextFactory<AppDbContext> _factory;

    public OrderService(IDbContextFactory<AppDbContext> factory)
    {
        _factory = factory;
    }

    public async Task<List<OrderTotal>> GetAllOrdersAsync()
    {
        using var context = _factory.CreateDbContext();

        return await context.OrderTotals
            .OrderByDescending(o => o.OrderDate)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<OrderTotal?> GetByIdAsync(int orderId)
    {
        using var context = _factory.CreateDbContext();

        return await context.OrderTotals
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.OrderId == orderId);
    }

    public async Task<List<OrderTotal>> GetOrdersByDateRangeAsync(
    DateOnly? startDate,
    DateOnly? endDate)
    {
        using var context = _factory.CreateDbContext();

        var query = context.OrderTotals.AsQueryable();

        if (startDate.HasValue)
        {
            query = query.Where(o => o.OrderDate >= startDate.Value);
        }

        if (endDate.HasValue)
        {
            query = query.Where(o => o.OrderDate <= endDate.Value);
        }

        return await query
            .OrderByDescending(o => o.OrderDate)
            .AsNoTracking()
            .ToListAsync();
    }
}
