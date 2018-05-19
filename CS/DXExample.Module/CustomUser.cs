
using DevExpress.Xpo;

using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;

namespace DXExample.Module {
    [DefaultClassOptions]
    public class CustomUser : User {
        public CustomUser(Session session) : base(session) { }
        [Association("Users-Resources")]
        public XPCollection<UserResource> Resources {
            get { return GetCollection<UserResource>("Resources"); }
        }
    }

}
