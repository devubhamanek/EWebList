using DemoDotNet.Common;
using Microsoft.Extensions.DependencyInjection;
using TimeTrackerMt.Business.Abstract;
using TimeTrackerMt.Business.Concrete;
using TimeTrackerMt.DataRepository.Abstract;
using TimeTrackerMt.DataRepository.Concrete;

namespace DemoDotNet.API
{
    public static class DependencyInjection
    {
        public static void AddDependency(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserManager, UserManager>();
            //services.AddScoped<IGeneralGenericFunction, GeneralGenericFunction>();

            //services.AddScoped<IUserSettingBusiness, UserSettingBusiness>();
            //services.AddScoped<IDepartmentBusiness, DepartmentBusiness>();
            //services.AddScoped<IProjectBusiness, ProjectBusiness>();
            //services.AddScoped<ICompanyBusiness, CompanyBusiness>();
            //services.AddScoped<IReportsBusiness, ReportsBusiness>();
            //services.AddScoped<IAppSettingBusiness, AppSettingBusiness>();
            //services.AddScoped<IAppSettingsBusiness, AppSettingsBusiness>();
            //services.AddScoped<IDynamicMenuBusiness, DynamicMenuBusiness>();
            //services.AddScoped<IMenuBusiness, MenuBusiness>();

            //services.AddScoped<IUserSettingRepository, UserSettingRepository>();
            //services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            //services.AddScoped<IProjectRepository, ProjectRepository>();
            //services.AddScoped<ICompanyRepository, CompanyRepository>();
            //services.AddScoped<IReportsRepository, ReportsRepository>();
            //services.AddScoped<IAppSettingRepository, AppSettingRepository>();
            //services.AddScoped<IAppSettingsRepository, AppSettingsRepository>();
            //services.AddScoped<IDynamicMenuRepository, DynamicMenuRepository>();
            //services.AddScoped<IMenuRepository, MenuRepository>();

            //services.AddScoped<IUserProjectsBusiness, UserProjectsBusiness>();
            //services.AddScoped<IUserProjectsRepository, UserProjectsRepository>();

            //services.AddScoped<IEmailSubscriptionBusiness, EmailSubscriptionBusiness>();
            //services.AddScoped<IEmailSubscriptionRepository, EmailSubscriptionRepository>();

            //services.AddScoped<IUserScreenLogRepository, UserScreenLogRepository>();
            //services.AddScoped<IUserScreenLogBusiness, UserScreenLogBusiness>();

            //services.AddScoped<IAttandanceLogRepository, AttandanceLogRepository>();
            //services.AddScoped<IAttandanceLogBusiness, AttandanceLogBusiness>();

            //services.AddScoped<IReportSummeryRepository, ReportSummeryRepository>();
            //services.AddScoped<IReportSummeryBusiness, ReportSummeryBusiness>();

            //services.AddScoped<IUserReportRepository, UserReportRepository>();
            //services.AddScoped<IUserReportBusiness, UserReportBusiness>();

            //services.AddScoped<IAttendenceHourRepository, AttendenceHourRepository>();
            //services.AddScoped<IAttendenceHourBusiness, AttendenceHourBusiness>();

            services.AddScoped<ImageHelpers>();
            services.AddScoped<Email>();
        }
    }
}