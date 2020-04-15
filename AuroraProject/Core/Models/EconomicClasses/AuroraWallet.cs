using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Core.Models
{
    public class AuroraWallet
    {
        public int ID { get; set; }
        public float Balance { get; private set; }

        public void AddMoney(float amount, int auroraWalletID)
        {
            Balance += amount;
        }

        public void SubMoney(float amount, int auroraWalletID)
        {
            Balance -= amount;
        }

        public void WithdrawMoney(float amount, int auroraWalletID)
        {
            if (amount < Balance)
                Balance -= amount;
            else
                Balance -= Balance;
        }        
    }
}