using System;
using FluentAssertions;
using Xunit;
using static Xunit.Assert;

namespace SnackMachine.Core.Test
{
    public class SnackMachineShould
    {
        private readonly SnackMachine _sut;
        public SnackMachineShould()
        {
            _sut = new SnackMachine();
        }
        [Fact]
        public void Insert_Money()
        {
            var cent = Money.FiftyCents;
            _sut.InsertMoney(cent);

            _sut.TransactionMoney.Should().Be(cent);
        }

        [Fact]
        public void Insert_Two_Coins()
        {
            var cent = Money.FiftyCents;
            var cent2 = Money.FiftyCents;
            _sut.InsertMoney(cent);
            _sut.InsertMoney(cent2);

            _sut.TransactionMoney.Should().Be(cent + cent2);
        }
        [Fact]
        public void Insert_None()
        {
            var none = Money.None;
            Action action = () => _sut.InsertMoney(none);
            action.Should().Throw<InvalidOperationException>();
        }




        [Fact]
        public void Return_Money()
        {
            var cent = Money.FiftyCents;
            _sut.InsertMoney(cent);
            _sut.ReturnMoney();
            _sut.TransactionMoney.Should().Be(Money.None);
        }

        [Fact]
        public void Sum_from_transaction_money_to_internal_money()
        {
            var cent = Money.FiftyCents;
            _sut.InsertMoney(cent);
            _sut.Buy();
            _sut.InternalMoney.Should().Be(Money.FiftyCents);
        }
        [Fact]
        public void Put_in_none_transactional_money()
        {
            var cent = Money.FiftyCents;
            _sut.InsertMoney(cent);
            _sut.Buy();
            _sut.TransactionMoney.Should().Be(Money.None);
        }

        //[Fact]
        //public void Insert_Two_Cent_Produce_Error()
        //{
        //    var twoCents = Money.Cent + Money.Cent;
        //    Action action = () => _sut.InsertMoney(twoCents);
        //    action.Should().Throw<InvalidOperationException>();
        //}
        //[Fact]
        //public void Add_More_Money()
        //{
        //    _sut.InsertMoney(15, (change) => { });
        //    _sut.InsertMoney(15, (change) => { });

        //    _sut.QuantityOfMoney.Should().Be(30);

        //}

        //[Fact]
        //public void Add_Money()
        //{
        //    _sut.InsertMoney(15, (change) => { });
        //    _sut.InsertMoney(15, (change) => { });

        //    _sut.QuantityOfMoney.Should().Be(30);
        //}

        //[Fact]
        //public void Buy_Product()
        //{
        //    var turron = _sut.Buy(new TurronToBuy(new Turron()));

        //    turron.Price.Should().Be(15);

        //}

        //[Fact]
        //public void Get_Change()
        //{
        //    _sut.InsertMoney(20, (change) =>
        //    {


        //    });
        //    var turron = _sut.Buy(new TurronToBuy(new Turron()));
        //    turron.Price.Should().Be(15);

        //}
    }
}
