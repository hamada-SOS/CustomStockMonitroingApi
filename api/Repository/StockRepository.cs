using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Helpers;
using api.Interfacses;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.ID == id);
            if (stockModel == null)
            {
                return null;

            }

            _context.Stocks.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }


        public async Task<List<Stock>> GetAllAsync(QuaryableObjects quary)
        {

            var stocks = _context.Stocks.Include(c => c.Comments).AsQueryable();

            if (!string.IsNullOrWhiteSpace(quary.Symbol))
            {
                stocks = stocks.Where(s => s.Symbol.Contains(quary.Symbol));
            }


            if (!string.IsNullOrWhiteSpace(quary.Company))
            {
                stocks = stocks.Where(s => s.Company.Contains(quary.Company));
            }

            if (!string.IsNullOrWhiteSpace(quary.SortBy))
            {

                if (quary.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase)) { }
                {
                    stocks = quary.IsDescending ? stocks.OrderByDescending(s => s.Symbol) : stocks.OrderBy(s => s.Symbol);
                }

            }


            return stocks.ToList();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            var stockModel = await _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(i => i.ID == id); // Adjust 'Stocks' based on your actual DBSet name

            if (stockModel == null)
            {
                return null;
            }

            return stockModel;

        }

        public Task<bool> StoclExists(int stock_id)
        {
            return _context.Stocks.AnyAsync(s => s.ID == stock_id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stackDto)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.ID == id);

            if (stockModel == null)
            {
                return null;

            }

            stockModel.Symbol = stackDto.Symbol;
            stockModel.Company = stackDto.Company;
            stockModel.Purchase = stackDto.Purchase;
            stockModel.LastDiv = stackDto.LastDiv;
            stockModel.Indestry = stackDto.Indestry;
            stockModel.MarketCap = stackDto.MarketCap;

            await _context.SaveChangesAsync();

            return stockModel;
        }
    }
}