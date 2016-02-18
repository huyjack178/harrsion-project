namespace BetList.Core.Render
{
    using BetList.Core.Entity;

    public interface IRender
    {
        object Render(IElement element);
    }
}