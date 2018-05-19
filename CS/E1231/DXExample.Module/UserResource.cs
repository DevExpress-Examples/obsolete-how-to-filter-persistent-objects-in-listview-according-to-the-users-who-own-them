
using DevExpress.Xpo;

using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;

namespace DXExample.Module {
    [DefaultClassOptions]
    public class UserResource : BaseObject {
        public UserResource(Session session) : base(session) { }
        private string _ResourceName;
        public string ResourceName {
            get { return _ResourceName; }
            set { SetPropertyValue("ResourceName", ref _ResourceName, value); }
        }
        [Association("Users-Resources")]
        public XPCollection<CustomUser> Owners {
            get { return GetCollection<CustomUser>("Owners"); }
        }
    }

}
