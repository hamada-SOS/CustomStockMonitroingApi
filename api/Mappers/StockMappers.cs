using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Models;

namespace api.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                ID = stockModel.ID,
                Symbol = stockModel.Symbol,
                Company = stockModel.Company,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Indestry = stockModel.Indestry,
                MarketCap = stockModel.MarketCap,
                Comments = stockModel.Comments.Select(c => c.ToCommentDto()).ToList()
            };

        }

        public static Stock ToStockFromCreateDTO(this CreateStockRequestDto stockDto)
        {
            return new Stock
            {
                Symbol = stockDto.Symbol,
                Company = stockDto.Company,
                Purchase = stockDto.Purchase,
                LastDiv = stockDto.LastDiv,
                Indestry = stockDto.Indestry,
                MarketCap = stockDto.MarketCap,
            };
        }

    }
}