
using DevExpress.ExpressApp;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Data.Filtering;

namespace DXExample.Module {
    public partial class FilterResourcesByOwnersController : ViewController {
        public FilterResourcesByOwnersController() {
            TargetObjectType = typeof(UserResource);
            TargetViewType = ViewType.ListView;
        }
        protected override void OnActivated() {
            base.OnActivated();
            Role adminRole = View.ObjectSpace.FindObject<Role>(new BinaryOperator("Name", "Administrators"));
            if (((CustomUser)SecuritySystem.CurrentUser).Roles.Lookup(adminRole.Oid) == null) {
                ((ListView)View).CollectionSource.Criteria["ByUsers"] = CriteriaOperator.Parse("Owners[Oid = ?] OR Owners.Count = 0", SecuritySystem.CurrentUserId);
            }
        }
    }
}
