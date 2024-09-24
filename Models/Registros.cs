using System.ComponentModel.DataAnnotations;

namespace MarcosRosario_Ap1_P1.Models
{
	public class Registros
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "Campo obligatoria")]
		public string? Nombres { get; set; }
	}
}
