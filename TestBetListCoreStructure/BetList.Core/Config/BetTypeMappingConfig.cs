using System.Collections.Generic;
using System.Xml;

namespace BetList.Core.Config
{
    public class BetTypeMappingConfig : IConfig
    {
        public BetTypeMappingConfig()
        {
            BetTypeMapping = new Dictionary<string, string>();
        }

        public IDictionary<string, string> BetTypeMapping
        {
            get; set;
        }

        public string GetBaseBetTypeId(string betTypeId)
        {
            return BetTypeMapping[betTypeId];
        }

        public void MapBetTypeToBaseBetType(string betTypeId, string baseBetTypeId)
        {
            BetTypeMapping.Add(betTypeId, baseBetTypeId);
        }

        public void LoadConfigFileAndMap(string fileName)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            var baseBetTypeNodes = xmlDoc.SelectSingleNode("BaseBetTypes");
            foreach (XmlNode baseBetTypeNode in baseBetTypeNodes.SelectNodes("BaseBetType"))
            {
                foreach (XmlNode betTypeNode in baseBetTypeNode)
                {
                    MapBetTypeToBaseBetType(betTypeNode.Attributes["id"].Value, baseBetTypeNode.Attributes["id"].Value);
                }
            }
        }
    }
}