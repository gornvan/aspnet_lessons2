using FabricMarket_DAL;
using lesson11_FabricMarket_DomainModel.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace FabricMarket_TestWebApi.Controllers.SQLInjection
{

	[ApiController]
	[Route("api/[controller]")]
	public class SQLInjectionController
	{

		private readonly IUnitOfWork _unitOfWork;
		private readonly DbContext _dbContext;

		public SQLInjectionController(IUnitOfWork uow, DbContext context)
		{
			_unitOfWork = uow;
			_dbContext = context;
		}

		/// <summary>
		/// the usual modern LINQ-based - secure by default
		/// </summary>
		[HttpGet]
		public async Task<ActionResult> Get(string searchByEmail)
		{
			var repo = _unitOfWork.GetRepository<User>();

			var users = await repo.AsReadOnlyQueryable().Where(u => u.Email.Contains(searchByEmail)).ToListAsync()
				?? new List<User>();

			return new JsonResult(users);
		}


		/// <summary>
		/// the usual modern LINQ-based - secure by default
		/// </summary>
		[HttpGet("Insecure")]
		public async Task<ActionResult> GetInsecure(string searchByEmail)
		{
			var dbset = _dbContext.Set<User>();

			// more secure way - use Formattable String and SqlParameter (?!)
			//// todo somehow the parameter doesn't get inserted at all
			//FormattableString req = $"select a.* from \"AspNetUsers\" as a where a.\"Email\" like '%{searchByEmail}%'";
			//var users = await dbset.FromSql<User>(req).ToListAsync();

			// totally not safe!
			var req_raw = $"select a.* from \"AspNetUsers\" as a where a.\"Email\" like '%{searchByEmail}%'";
			var users = await dbset.FromSqlRaw<User>(req_raw).ToListAsync();

			return new JsonResult(users);
		}


	}
}
