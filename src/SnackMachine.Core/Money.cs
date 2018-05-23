using System;

namespace SnackMachine.Core
{
    public sealed class Money : ValueObject<Money>
    {
        public static readonly Money None = new Money(0, 0, 0, 0, 0);
        public static readonly Money FiftyCents = new Money(1, 0, 0, 0, 0);
        public static readonly Money OnePesos = new Money(0, 1, 0, 0, 0);
        public static readonly Money TwoPesos = new Money(0, 0, 1, 0, 0);
        public static readonly Money FivePesos = new Money(0, 0, 0, 1, 0);
        public static readonly Money TenPesos = new Money(0, 0, 0, 0, 1);

        public int CentsCount { get; }
        public int OnePesosCount { get; }
        public int TwoPesosCount { get; }
        public int FivePesosCount { get; }
        public int TenPesosCount { get; }


        public Money(int centsCount, int onePesosCount, int twoPesosCount, int fivePesosCount, int tenPesosCount)
        {
            ValidateMoney(centsCount, onePesosCount, twoPesosCount, fivePesosCount, tenPesosCount);
            CentsCount = centsCount;
            OnePesosCount = onePesosCount;
            TwoPesosCount = twoPesosCount;
            FivePesosCount = fivePesosCount;
            TenPesosCount = tenPesosCount;
        }


        private static void ValidateMoney(int centsCount,
                                            int onePesosCount, 
                                            int TwoPesosCount, 
                                            int fivePesosCount,
                                            int tenPesosCount)
        {
            if (centsCount < 0)
                throw new InvalidOperationException();
            if (onePesosCount < 0)
                throw new InvalidOperationException();
            if (TwoPesosCount < 0)
                throw new InvalidOperationException();
            if (fivePesosCount < 0)
                throw new InvalidOperationException();
            if (fivePesosCount < 0)
                throw new InvalidOperationException();
            if (tenPesosCount < 0)
                throw new InvalidOperationException();
        }

        public static Money operator +(Money money1, Money money2)
        {
            Money sum = new Money(
                money1.CentsCount + money2.CentsCount,
                money1.OnePesosCount + money2.OnePesosCount,
                money1.TwoPesosCount + money2.TwoPesosCount,
                money1.FivePesosCount + money2.FivePesosCount,
                money1.TenPesosCount + money2.TenPesosCount);

            return sum;
        }

        public static Money operator -(Money money1, Money money2)
        {
            return new Money(
             money1.CentsCount + money2.CentsCount,
             money1.OnePesosCount + money2.OnePesosCount,
             money1.TwoPesosCount + money2.TwoPesosCount,
             money1.FivePesosCount + money2.FivePesosCount,
             money1.TenPesosCount + money2.TenPesosCount);
        }

        protected override bool EqualsCore(Money otherMOney)
        {
            return CentsCount == otherMOney.CentsCount
                   && OnePesosCount == otherMOney.OnePesosCount
                   && TwoPesosCount == otherMOney.TwoPesosCount
                   && FivePesosCount == otherMOney.FivePesosCount
                   && TenPesosCount == otherMOney.TenPesosCount;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = CentsCount;
                hashCode = (hashCode * 397) ^ OnePesosCount;
                hashCode = (hashCode * 397) ^ TwoPesosCount;
                hashCode = (hashCode * 397) ^ FivePesosCount;
                hashCode = (hashCode * 397) ^ TenPesosCount;
                return hashCode;
            }
        }
    }
}