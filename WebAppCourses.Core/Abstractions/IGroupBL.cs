using AppCourses.Core.Models.Add;
using AppCourses.Core.Models.View;

namespace AppCourses.Core.Abstractions
{
    public interface IGroupBL
    {
        IEnumerable<GroupViewModel> GetGroups(int? Id = null);
        GroupViewModel AddGroup(int? userId, int? courseId);
        void RemoveGroup(int? userId, int? courseId);
    }
}
