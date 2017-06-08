using ICW.Framework.Pages.SiteComponents;

namespace ICW.Framework.Pages.Projects
{
    public class ProjectsPage : BasePage<ProjectsPage>
    {
        public override string PageTitle { get { return "projects"; } }

        public LinkedWebTable Table
        {
            get { return _table ?? (_table = new LinkedWebTable("project")); }
        }
        private LinkedWebTable _table;
    }
}
