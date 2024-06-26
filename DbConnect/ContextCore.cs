using Microsoft.EntityFrameworkCore;
using System;
namespace PwDbAssistant.DbConnect
{
    public class ContextCore : DbContext
    {
        public ContextCore(DbContextOptions<ContextCore> options) : base(options)
        {

        }
    }
}
