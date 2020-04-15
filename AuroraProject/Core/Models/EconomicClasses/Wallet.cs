using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Core.Models
{
    public class Wallet
    {
        public int ID { get; set; }
        public float Value { get; private set; }
        //NAVIGATION TO USER
        public ApplicationUser Owner { get; set; }

        public Wallet()
        {

        }
        public Wallet(float initialAmount)
        {
            Value = initialAmount;
        }

        public static void GiveWalletToUser(ApplicationUser user)
        {
            // GIVE A WALLET TO USER WITH THE INITIAL AMMOUNT OF 1000 CREDITS
            user.Wallet = new Wallet(1000);
        }

        public void AddMoney(float amount, int walletID)
        {
            Value += amount;
        }

        public void SubMoney(float amount, int walletID)
        {
            Value -= amount;
        }

        public void WithdrawMoney(float amount, int walletID)
        {
            if (amount < Value)
            {
                Value -= amount;
            }
            else
            {
                Value -= Value;
            }
        }        
    }
}