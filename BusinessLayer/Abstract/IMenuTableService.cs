using EntityLayer.Entities;

namespace BusinessLayer.Abstract
{
    public interface IMenuTableService : IGenericService<MenuTable>
    {
        int TMenuTableCount();
    }
}
