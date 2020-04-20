using Domain.Services.ClassRooms;
using Domain.Services.ClassRooms.Abstractions;
using Domain.Services.Groups;
using Domain.Services.Groups.Abstractions;
using Domain.Services.Lectures;
using Domain.Services.Lectures.Abstractions;
using Domain.Services.LecturesPool;
using Domain.Services.LecturesPool.Abstractions;
using Domain.Services.Subjects;
using Domain.Services.Subjects.Abstractions;
using Domain.Services.Users;
using Domain.Services.Users.Abstractions;
using Domain.Utilites;
using Microsoft.Extensions.DependencyInjection;

namespace Domain
{
    public static class ServicesExtensions
    {
        public static void AddDomain(this IServiceCollection service)
        {
            service.AddScoped<IClassRoomService, ClassRoomService>();
            service.AddScoped<IGroupsService, GroupsService>();
            service.AddScoped<ILecturesService, LecturesService>();
            service.AddScoped<ILecturesPoolService, LecturesPoolService>();
            service.AddScoped<ISubjectsService, SubjectsService>();
            service.AddScoped<IUsersService, UsersService>();

            service.AddTransient<DataInitilaizer>();
        }
    }
}
