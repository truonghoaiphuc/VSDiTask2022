using System.ComponentModel;

namespace VSDiTask.Users.Data
{
    public enum StatusCode
    {
        [Description("Công ty đã tồn tại")]
        Company_already_exist = 2,
        [Description("Công ty không tồn tại")]
        Company_not_exist = 3,
        [Description("Phòng ban đã tồn tại")]
        Department_already_exist = 4,
        [Description("Phòng ban không tồn tại")]
        Department_not_exist = 5,
        [Description("Người dùng đã tồn tại trong hệ thống")]
        User_already_exist = 6,
        [Description("Người dùng đã tồn tại trong hệ thống")]
        User_not_exist = 7,
        [Description("Nhóm người dùng đã tồn tại trong hệ thống")]
        Role_already_exist = 8,
        [Description("Nhóm người dùng không tồn tại trong hệ thống")]
        Role_not_exist = 9,
    }
}
