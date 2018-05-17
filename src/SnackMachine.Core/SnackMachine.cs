using System;
using System.Collections.Generic;
using System.Linq;

namespace SnackMachine.Core
{
    public sealed class SnackMachine : Entity
    {
        public Money InternalMoney { get; private set; } = Money.None;
        public Money TransactionMoney { get; private set; } = Money.None;

        public void InsertMoney(Money money)
        {
            if (money == Money.None)
                throw new InvalidOperationException();
            TransactionMoney += money;
        }


        public Money ReturnMoney() =>
             TransactionMoney = Money.None;

        public void Buy()
        {
            InternalMoney += TransactionMoney;
            TransactionMoney = Money.None;
        }
    }
}