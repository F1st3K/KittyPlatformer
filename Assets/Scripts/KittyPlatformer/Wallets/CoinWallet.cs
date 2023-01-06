using System;
using KittyPlatformer.Base;

namespace KittyPlatformer.Wallets
{
    public class CoinWallet : Wallet
    {
        private protected override void Awake()
        {
            maxResources = Int32.MaxValue;
        }
    }
}