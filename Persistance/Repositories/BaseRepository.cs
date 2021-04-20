using Api.Persistance.Contexts;
namespace Api.Persistance.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly OS_Plus_Money_Flow _context;
        public BaseRepository(OS_Plus_Money_Flow context)
        {
            _context=context;
        }
    }
}