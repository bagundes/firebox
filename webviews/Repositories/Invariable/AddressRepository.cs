using webviews.Models.Invariable;

namespace webviews.Repositories.Invariable
{
    public interface IAddressRepository : IBaseRepository<AddressModel>
    {

    }
    public class AddressRepository : BaseRepository<AddressModel>, IAddressRepository
    {
        public AddressRepository(AppContext context) : base(context)
        {
        }

        public void CreateDefault()
        {
            throw new System.NotImplementedException();
        }
    }
}