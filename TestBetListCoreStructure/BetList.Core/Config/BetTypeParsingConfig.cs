using System.Collections.Generic;
using System.Xml;

namespace BetList.Core.Config
{
    public class BetTypeParsingConfig : IConfig
    {
        private IDictionary<string, string> _betTypeDic = null;

        public BetTypeParsingConfig()
        {
            _betTypeDic = new Dictionary<string, string>();
        }

        public string GetBaseIdById(string id)
        {
            return _betTypeDic[id];
        }



        public void LoadConfigFileAndParseToDictionary(string fileName)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            var baseBetTypeNodes = xmlDoc.SelectSingleNode("BaseBetTypes");
            foreach (XmlNode baseBetTypeNode in baseBetTypeNodes.SelectNodes("BaseBetType"))
            {
                foreach (XmlNode betTypeNode in baseBetTypeNode)
                {
                    AddToDictionary(betTypeNode.Attributes["id"].Value, baseBetTypeNode.Attributes["id"].Value);
                }
            }
        }

        private void AddToDictionary(string betTypeId, string baseBetTypeId)
        {
            _betTypeDic.Add(betTypeId, baseBetTypeId);
        }
    }
}