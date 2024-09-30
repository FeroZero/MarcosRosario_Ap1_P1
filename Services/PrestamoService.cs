using MarcosRosario_Ap1_P1.DAL;
using MarcosRosario_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MarcosRosario_Ap1_P1.Services
{
	public class PrestamoService(Contexto contexto)
	{
		public async Task<bool> Guardar(Prestamos prestamo)
		{
			if (!await Existe(prestamo.PrestamoId))
				return await Insertar(prestamo);
			else
				return await Modificar(prestamo);
		}

		private async Task<bool> Modificar(Prestamos prestamo)
		{
			contexto.Update(prestamo);
			var modificado = await contexto.SaveChangesAsync() > 0;
			contexto.Entry(prestamo).State = EntityState.Modified;
			return modificado;
		}

		private async Task<bool> Insertar(Prestamos prestamo)
		{
			contexto.Prestamos.Add(prestamo);
			return await contexto.SaveChangesAsync() > 0;
		}

		private async Task<bool> Existe(int prestamoId)
		{
			return await contexto.Prestamos
				.AnyAsync(p => p.PrestamoId ==  prestamoId);
		}

		public async Task<bool> Eliminar(int prestamoId)
		{
			return await contexto.Prestamos
				.AsNoTracking()
				.Where(p => p.PrestamoId == prestamoId)
				.ExecuteDeleteAsync() > 0;
		}

		public async Task<Prestamos?> Buscar(int prestamoId)
		{
			return await contexto.Prestamos
				.AsNoTracking()
				.FirstOrDefaultAsync(p => p.PrestamoId == prestamoId);
		}

		public async Task<List<Prestamos>> Listar(Expression<Func<Prestamos, bool>> criterio)
		{
			return await contexto.Prestamos
				.AsNoTracking()
				.Where(criterio)
				.ToListAsync();
		}
	}
}
