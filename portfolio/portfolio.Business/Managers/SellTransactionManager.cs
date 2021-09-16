﻿using portfolio.Domain.Entities;
using portfolio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.Business.Managers
{
    public class SellTransactionManager : BaseManager
    {
        public SellTransactionManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        // <summary>
        /// general list of sell transactions
        /// </summary>
        public IEnumerable<SellTransaction> sellTransactions
        {
            get => sellTransactionRepository.GetAll();
        }

        public SellTransaction GetById(int id) => sellTransactionRepository.Get(id);

        public SellTransaction CreateSellTransaction(SellTransaction sellTransaction)
        {
            sellTransactionRepository.Create(sellTransaction);
            unitOfWork.SaveChanges();
            return sellTransaction;
        }

        ///<summary>
        /// Add sell transactions from list
        /// </summary>
        /// <param name = "sellTransactions"></param>
        public void AddRange(List<SellTransaction> sellTransactions)
        {
            sellTransactions.ForEach(s => sellTransactionRepository.Create(s));
            unitOfWork.SaveChanges();
        }

        ///<summary>
        /// Delete sell transactions by id
        /// </summary>
        /// <param name = "id">id sell transactions to delete</param>
        /// <returns></returns>
        public bool DeleteSellTransaction(int id)
        {
            var result = sellTransactionRepository.Delete(id);
            if (!result) return false;
            unitOfWork.SaveChanges();
            return true;
        }

        /// <summary>
        /// Update sell transaction
        /// </summary>
        /// <param name="sellTransaction"></param>
        public void UpdateSellTransaction(SellTransaction sellTransaction)
        {
            sellTransactionRepository.Update(sellTransaction);
            unitOfWork.SaveChanges();
        }
    }
}