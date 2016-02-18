namespace BetList.Core.Config
{
    using System.Collections.Generic;

    public interface IConfig
    {
        IDictionary<string, string> BetTypeMapping { get; set; }

        void MapBetTypeToBaseBetType(string betTypeId, string baseBetTypeId);

        string GetBaseBetTypeId(string betTypeId);
    }
}