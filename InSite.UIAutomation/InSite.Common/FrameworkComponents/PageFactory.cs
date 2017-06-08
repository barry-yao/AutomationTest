using InSite.Common.Interfaces;

namespace InSite.Common.FrameworkComponents
{
    public class PageFactory
    {
        public static T GetPage<T>() where T : class, IPageObject
        {
            var type = typeof (T);

            return (T) type.Assembly.CreateInstance(type.FullName);
        }
    }
}
