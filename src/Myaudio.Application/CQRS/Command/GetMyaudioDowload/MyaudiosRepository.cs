using Microsoft.EntityFrameworkCore;
using Myaudio.Application.CQRS.Interface;
using Myaudio.Domain;

namespace Myaudio.Application.CQRS.Command.GetMyaudioDowload
{
    public class MyaudiosRepository : IMyaudiosRepository
    {
        private readonly IContext _context;
        CancellationToken cancellationToken = new CancellationToken();

        public MyaudiosRepository(IContext context)
        {
            _context = context;
        }

        public async Task<List<Myaudios>> GetAllAsync()
        {
            return await _context.Myaudio.ToListAsync();
        }

        public async Task AddAsync(Myaudios myaudio)
        {
            await _context.Myaudio.AddAsync(myaudio);
        }

        public void Remove(Myaudios myaudio)
        {
            _context.Myaudio.Remove(myaudio);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

