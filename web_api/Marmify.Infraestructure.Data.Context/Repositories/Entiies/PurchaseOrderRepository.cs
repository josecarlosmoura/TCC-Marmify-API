using Marmify.Domain.Entities;
using Marmify.Domain.Interfaces.Repositories;
using Marmify.Infraestructure.Data.Context.Context;
using Marmify.Infraestructure.Data.Context.Repositories.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Marmify.Infraestructure.Data.Context.Repositories.Entiies
{
	public class PurchaseOrderRepository : MarmifyRepositoryBase<PurchaseOrder>, IPurchaseOrderRepository
	{
	}
}
