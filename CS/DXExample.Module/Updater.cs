using System;

using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;

namespace DXExample.Module {
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            CustomUser user1 = ObjectSpace.FindObject<CustomUser>(new BinaryOperator("UserName", "Admin"));
            if (user1 == null) {
                user1 = ObjectSpace.CreateObject<CustomUser>();
                user1.UserName = "Admin";
                user1.FirstName = "Admin";
                user1.SetPassword("");
            }
            CustomUser user2 = ObjectSpace.FindObject<CustomUser>(new BinaryOperator("UserName", "User"));
            if (user2 == null) {
                user2 = ObjectSpace.CreateObject<CustomUser>();
                user2.UserName = "User";
                user2.FirstName = "User";
                user2.SetPassword("");
            }
            Role adminRole = ObjectSpace.FindObject<Role>(new BinaryOperator("Name", "Administrators"));
            if (adminRole == null) {
                adminRole = ObjectSpace.CreateObject<Role>();
                adminRole.Name = "Administrators";
            }
            Role userRole = ObjectSpace.FindObject<Role>(new BinaryOperator("Name", "Users"));
            if (userRole == null) {
                userRole = ObjectSpace.CreateObject<Role>();
                userRole.Name = "Users";
            }
            while (adminRole.PersistentPermissions.Count > 0) {
                ObjectSpace.Delete(adminRole.PersistentPermissions[0]);
            }
            while (userRole.PersistentPermissions.Count > 0) {
                ObjectSpace.Delete(userRole.PersistentPermissions[0]);
            }
            adminRole.AddPermission(new ObjectAccessPermission(typeof(object), ObjectAccess.AllAccess));
            adminRole.AddPermission(new EditModelPermission(ModelAccessModifier.Allow));
            adminRole.Save();
            userRole.AddPermission(new ObjectAccessPermission(typeof(object), ObjectAccess.AllAccess));
            userRole.AddPermission(new ObjectAccessPermission(typeof(User),
               ObjectAccess.ChangeAccess, ObjectAccessModifier.Deny));
            userRole.AddPermission(new ObjectAccessPermission(typeof(Role),
               ObjectAccess.AllAccess, ObjectAccessModifier.Deny));
            userRole.AddPermission(new ObjectAccessPermission(typeof(UserResource),
               ObjectAccess.ChangeAccess, ObjectAccessModifier.Deny));
            userRole.AddPermission(new EditModelPermission(ModelAccessModifier.Deny));
            userRole.Save();
            user1.Roles.Add(adminRole);
            user2.Roles.Add(userRole);
            user1.Save();
            user2.Save();
        }
    }
}
