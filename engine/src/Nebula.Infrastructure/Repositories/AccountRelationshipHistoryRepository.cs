using Microsoft.EntityFrameworkCore;
using Nebula.Application.Interfaces;
using Nebula.Domain.Entities;
using Nebula.Infrastructure.Persistence;

namespace Nebula.Infrastructure.Repositories;

public class AccountRelationshipHistoryRepository(AppDbContext db) : IAccountRelationshipHistoryRepository
{
    public Task AddAsync(AccountRelationshipHistory history, CancellationToken ct = default)
    {
        db.AccountRelationshipHistory.Add(history);
        return Task.CompletedTask;
    }
}
