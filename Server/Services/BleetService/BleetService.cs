namespace BrightApp.Server.Services.BleetService
{
    public class BleetService : IBleetService
    {
        private readonly BleetContext _context;

        public BleetService(BleetContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Bleet>>> GetBleetsAsync()
        {
            var response = new ServiceResponse<List<Bleet>>
            {
                Data = await _context.Bleets.ToListAsync()
            };

            return response;
        }
    }
}
