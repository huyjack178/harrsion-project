// ---------------------------------------------------------------------------------
// <copyright file="ITicketsDAO.cs" company="Nexcel Solutions Vietnam">
//     Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
// <history>
//     <change who="Marc.Bui" date="2014.02.11">Create</change>
// </history>
// ---------------------------------------------------------------------------------

namespace Fanex.BetList.Example.Data
{
    using Fanex.BetList.Core.Entities;
    using System.Collections.Generic;

    public interface ITicketsDAO
    {
        IList<ITicket> GetTickets();

        IList<ITicketData> GetTicketData();
    }
}