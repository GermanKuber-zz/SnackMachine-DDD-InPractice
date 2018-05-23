using System;
using FluentAssertions;
using Xunit;

namespace SnackMachine.Core.Test
{
    public class MoneyShould
    {
        [Fact]
        public void Get_Sum_Of_Two_Money()
        {
            Money money1 = new Money(1, 2, 3, 4, 5);
            Money money2 = new Money(1, 2, 3, 4, 5);

            Money sum = money1 + money2;

            sum.CentsCount.Should().Be(2);
            sum.OnePesosCount.Should().Be(4);
            sum.TwoPesosCount.Should().Be(6);
            sum.FivePesosCount.Should().Be(8);
            sum.TenPesosCount.Should().Be(10);
        }

        [Fact]
        public void Be_Equal_If_Two_Money_Contains_The_Same_Values()
        {
            Money money1 = new Money(1, 2, 3, 4, 5);
            Money money2 = new Money(1, 2, 3, 4, 5);

            money1.Should().Be(money2);
            money1.GetHashCode().Should().Be(money2.GetHashCode());
        }

        [Fact]
        public void Two_money_instances_do_not_equal_if_contain_different_money_amounts()
        {
            Money dollar = new Money(0, 0, 0, 1, 0);
            Money hundredCents = new Money(100, 0, 0, 0, 0);

            dollar.Should().NotBe(hundredCents);
            dollar.GetHashCode().Should().NotBe(hundredCents.GetHashCode());
        }

        [Theory]
        [InlineData(-1, 0, 0, 0, 0)]
        [InlineData(0, -2, 0, 0, 0)]
        [InlineData(0, 0, -3, 0, 0)]
        [InlineData(0, 0, 0, -4, 0)]
        [InlineData(0, 0, 0, 0, -5)]
        public void Cannot_create_money_with_negative_value(
            int oneCentCount,
            int tenCentCount,
            int quarterCount,
            int oneDollarCount,
            int fiveDollarCount)
        {
            Action action = () => new Money(
                oneCentCount,
                tenCentCount,
                quarterCount,
                oneDollarCount,
                fiveDollarCount);

            action.Should().Throw<InvalidOperationException>();
        }
    }
  
}