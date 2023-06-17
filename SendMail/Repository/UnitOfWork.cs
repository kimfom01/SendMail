﻿using SendMail.Data;

namespace SendMail.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly SendMailDbContext _context;

    public UnitOfWork(SendMailDbContext context)
    {
        Mails = new MailRepository(context);
        _context = context;
    }

    public IMailRepository Mails { get; }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}