<!-- default file list -->
*Files to look at*:

* [CustomUser.cs](./CS/DXExample.Module/CustomUser.cs) (VB: [CustomUser.vb](./VB/DXExample.Module/CustomUser.vb))
* [FilterResourcesByOwnersController.cs](./CS/DXExample.Module/FilterResourcesByOwnersController.cs) (VB: [FilterResourcesByOwnersController.vb](./VB/DXExample.Module/FilterResourcesByOwnersController.vb))
* [Updater.cs](./CS/DXExample.Module/Updater.cs) (VB: [Updater.vb](./VB/DXExample.Module/Updater.vb))
* [UserResource.cs](./CS/DXExample.Module/UserResource.cs) (VB: [UserResource.vb](./VB/DXExample.Module/UserResource.vb))
<!-- default file list end -->
# OBSOLETE: How to filter persistent objects in ListView, according to the users who own them (Complex Security)


<p><strong>==============================<br />
</strong><strong>This example is related to the old security system. To learn how to implement this functionality in the new security system, refer to the </strong><a href="https://www.devexpress.com/Support/Center/p/Q430153">How to filter records by the current user (the object owner feature)</a><strong> ticket.</strong><strong><br />
==============================</strong></p><p><br />
This is the continuation of the <a href="https://www.devexpress.com/Support/Center/p/E919">E919</a> example. Here, I've used Many-to-Many relation between users and their resources, and filtered resources by the associated users (owners), if the current user doesn't have the Administrators role.</p>

<br/>


