using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Helpers;
using api.Models;

namespace api.Interfacses
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QuaryableObjects quary);
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stockModel);
        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stackDto);
        Task<Stock?> DeleteAsync(int id);
        Task<bool> StoclExists(int stock_id);


    };
}