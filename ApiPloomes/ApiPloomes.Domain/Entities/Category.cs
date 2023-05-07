using System.ComponentModel.DataAnnotations.Schema;
using ApiPloomes.Domain.Validation;

namespace ApiPloomes.Domain.Entities
{
	[Table("Categories")]
	public class Category : Entity
	{
		public Category(string name, string imageUrl)
		{
			ValidateDomain(name, imageUrl);
		}

		public Category(int id, string name, string imageUrl)
		{
			DomainExceptionValidation.When(id < 0, "valor de Id inválido.");
			Id = id;
			ValidateDomain(name, imageUrl);
		}

		private void ValidateDomain(string name, string imageUrl)
		{
			DomainExceptionValidation.When(string.IsNullOrEmpty(name),
				"Nome inválido. O nome é obrigatório");

			DomainExceptionValidation.When(string.IsNullOrEmpty(imageUrl),
				"Nome da imagem inválido. O nome é obrigatório");

			DomainExceptionValidation.When(name.Length < 3,
			   "O nome deve ter no mínimo 3 caracteres");

			DomainExceptionValidation.When(imageUrl.Length < 5,
				"Nome da imagem deve ter no mínimo 5 caracteres");

			Name = name;
			ImageUrl = imageUrl;
		}

		public string Name { get; private set; }
		public string ImageUrl { get; private set; }
		public ICollection<Product> Products { get; set; }
	}
}
