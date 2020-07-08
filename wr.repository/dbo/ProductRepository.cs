using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using wr.entity;

namespace wr.repository.dbo
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
    }
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly DbContext _context;
        private readonly IDataProtectionProvider _protectionProvider;
        //private readonly PurposeStringConstants _purposeStringConstants;
        private IDataProtector _dataProtector;
        public ProductRepository(DbContext context, IDataProtectionProvider p_protectionProvider/*, PurposeStringConstants p_purposeStringConstants*/) : base(context)
        {
            this._context = context;
            _protectionProvider = p_protectionProvider;
            //_purposeStringConstants = p_purposeStringConstants;
            //_dataProtector = _protectionProvider.CreateProtector(_purposeStringConstants.UserIdQueryString);
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await this.Query().SelectAsync();

            return products;
        }

        public async Task<Product> GetById(int id)
        {

            var products = await this.Query() .SingleOrDefaultAsync(p=>p.Pid==id,CancellationToken.None);

            return products;
        }
    }
}
