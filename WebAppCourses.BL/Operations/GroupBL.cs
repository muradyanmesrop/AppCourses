using AppCourses.Core.Abstractions;
using AppCourses.Core.Db;
using AppCourses.Core.Db.Entities;
using AppCourses.Core.Exceptions;
using AppCourses.Core.Models.Abstract;
using AppCourses.Core.Models.View;

namespace AppCourses.BL.Operations
{
    public class GroupBL : IGroupBL
    {
        private readonly AppDbContext _db;

        public GroupBL(AppDbContext db)
        {
            _db = db;
        }


        public GroupViewModel AddGroup(int? userId, int? courseId)
        {
            if (userId == null || courseId == null)
            {
                throw new LogicException("Keys not is null/empty");
            }

            Group group = new Group { UserId = userId, CourseId = courseId };
            _db.Groups.Add(group);
            _db.SaveChanges();
            User user = _db?.Users?.Find(userId);
            Course course = _db?.Courses?.Find(courseId);
            GroupViewModel groupViewModel = new GroupViewModel
            {
                UserId = userId,
                CourseId = courseId,
                UserFirstName = user?.FirstName,
                UserLastName = user?.LastName,
                CourseName = course?.CourseName
            };
            return groupViewModel;
        }

        public IEnumerable<GroupViewModel> GetGroups(int? Id = null)
        {
            var gorups = (from groups in _db.Groups
                          join courses in _db.Courses on groups.CourseId equals courses.CourseId
                          join users in _db.Users.Where(u => u.UserId == Id || Id == null) on groups.UserId equals users.UserId
                          select new GroupViewModel
                          {
                              CourseId = courses.CourseId,
                              CourseName = courses.CourseName,
                              UserId = users.UserId,
                              UserFirstName = users.FirstName,
                              UserLastName = users.LastName
                          }).ToList();
            return gorups;
        }

        public void RemoveGroup(int? userId, int? courseId)
        {
            if (userId == null || courseId == null)
            {
                throw new LogicException("Keys not is null/empty");
            }
            Group group = _db.Groups.Find(userId, courseId);
            _db.Groups.Remove(group);
            _db.SaveChanges();
        }
    }
}
