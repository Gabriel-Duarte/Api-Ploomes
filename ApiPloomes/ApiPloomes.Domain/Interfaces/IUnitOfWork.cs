namespace ApiPloomes.Domain.Interfaces
{
	public interface IUnitOfWork
	{
		IProductRepository ProductRepository { get; }
		void Commit();
	}
}
