using System.ComponentModel.DataAnnotations;

namespace MarcosRosario_Ap1_P1.Models
{
	public class Prestamos
	{
		[Key]
		public int PrestamoId { get; set; }
		[Required(ErrorMessage = "Campo obligatoria")]
		[RegularExpression("@^[a-zA-Z]+$", ErrorMessage = "Solo letras.")]
		public string? Nombres { get; set; }
		[Required(ErrorMessage = "Campo obligatoria")]
		[RegularExpression("@^[a-zA-Z]+$", ErrorMessage = "Solo letras.")]
		public string? Concepto { get; set; }
		[Required(ErrorMessage = "Campo obligatoria")]
		[Range(1, double.MaxValue, ErrorMessage = "No puede ser menor a 0.")]
		public double Monto { get; set; }
	}
}
