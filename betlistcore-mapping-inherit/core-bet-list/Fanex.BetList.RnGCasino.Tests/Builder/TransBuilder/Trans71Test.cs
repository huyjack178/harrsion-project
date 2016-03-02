﻿namespace Fanex.BetList.RnGCasino.Tests.Builder.StatusBuilder
{
    using Core.Builder.TransBuilder;
    using Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    /// <summary>
    /// The Unit testing for Trans71 class.
    /// </summary>
    public class Trans71Test
    {
        private Trans71 _trans;
        private ITicket _ticket;

        [SetUp]
        public void Setup()
        {
            _trans = new Trans71();
            _ticket = Substitute.For<ITicket>();
        }

        [Test]
        public void BuildRefNo_Always_SetRefNoIsRefNo()
        {
            // Arrange
            _ticket.RefNo = "100";

            // Act
            _trans.Render(_ticket);

            // Assert
            Assert.AreEqual(_ticket.RefNo, _trans.Template.TransTime.refNo);
        }
    }
}