namespace InSite.Common.Interfaces
{
    public interface INavigatablePage : IPageObject
    {
        string PageTitle { get; }

        void Navigate();
    }
}
