namespace ICW.Framework.Pages.SiteComponents
{
    public class LinkedWebTable : InSite.Common.SiteComponents.LinkedWebTableBase
    {
        protected override string _linkTag { get { return "a"; } }

        public LinkedWebTable(string tableMainItemPrefix) : base(tableMainItemPrefix)
        {
        }
    }
}
