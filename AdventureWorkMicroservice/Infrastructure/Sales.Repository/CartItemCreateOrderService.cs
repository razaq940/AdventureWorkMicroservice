using Sales.Contracts;
using Sales.Entities.DTO;
using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Repository.Models
{
    public class CartItemCreateOrderService : ICartItemCreateOrderService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public CartItemCreateOrderService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<CreditCard> CheckCardNumber(CardNumberDto cardNumberDto)
        {
            try
            {
                var cardNumber = await _repositoryManager.CreditCard.GetCreditCardAsync(cardNumberDto.CardNumber, trackChanges: true);
                var businessEntitiyId = _repositoryManager.PersonCreditCard
                                               .GetPersonCreditCardAsync(cardNumber.CreditCardId, trackChanges: true);
                if (businessEntitiyId == null)
                {
                    return null;
                }
                return cardNumber;
            }
            catch (Exception ex)
            {
                _loggerManager.LogWarn($"message : {ex.Message}");
                return null;
            }
            
        }
    }
}
