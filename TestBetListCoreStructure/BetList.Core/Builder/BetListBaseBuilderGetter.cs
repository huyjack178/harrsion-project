namespace BetList.Core.Builder
{
    using BetList.Core.Config;
    using Entity;

    public class BetListBaseBuilderGetter
    {
        private BetTypeMappingConfig _config = null;

        public BetListBaseBuilderGetter()
        {
            _config = new BetTypeMappingConfig();
            _config.LoadConfigFileAndMap("D:\\project\\harrsion-project\\TestBetListCoreStructure\\BetList.Core\\Config\\config.xml");
        }

        public IBuilder GetChoiceBuilder(ITicket ticket)
        {
            BetListInstanceGetter instanceGetter = new BetListInstanceGetter();

            string baseBuilderId = _config.GetBaseBetTypeId(ticket.BetTypeId.ToString());

            IBuilder choiceBuilder = instanceGetter.GetChoiceBuilderInstance(baseBuilderId);

            choiceBuilder.Config = _config;

            return choiceBuilder;
        }

        public IBuilder GetStatusBuilder(ITicket ticket)
        {
            BetListInstanceGetter instanceGetter = new BetListInstanceGetter();

            string baseBuilderId = _config.GetBaseBetTypeId(ticket.BetTypeId.ToString());

            IBuilder statusBuilder = instanceGetter.GetStatusBuilderInstance(baseBuilderId);

            statusBuilder.Config = _config;

            return statusBuilder;
        }
    }
}