using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace BrightApp.Server.Services.BleetService
{
    public class BleetService : IBleetService
    {
        private readonly BleetContext _context;

        public BleetService(BleetContext context)
        {
            _context = context;
        }

        public async Task<Bleet> CreateBleet(Bleet bleet)
        {
            await _context.Bleets.AddAsync(bleet);
            _context.SaveChanges();
            return bleet;
        }

        public async Task<List<Bleet>> GetBleetsAsync()
        {
            var response = await _context.Bleets
                .OrderByDescending(bleet => bleet.CreatedAt)
                .Take(10)
                .ToListAsync();

            return response;
        }



    }
}
