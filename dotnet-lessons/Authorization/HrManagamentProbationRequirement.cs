using Microsoft.AspNetCore.Authorization;

namespace dotnet_lessons.Authorization
{
    public class HrManagementProbationRequirement : IAuthorizationRequirement
    {
        public HrManagementProbationRequirement(int probationMonths)
        {
            this.probationMonths = probationMonths;

        }

        public int probationMonths { get; }
    }

    public class HrManagementProbationRequirementHandler : AuthorizationHandler<IAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IAuthorizationRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "EmploymentDate"))

                return Task.CompletedTask;

            if (DateTime.TryParse(context.User.FindFirst(c => c.Type == "EmploymentDate")?.Value, out DateTime employmentDate))
            {
                var period = DateTime.Now - employmentDate;
                if (period.Days > 30 * ((HrManagementProbationRequirement)requirement).probationMonths)
                    context.Succeed(requirement);

            }
            return Task.CompletedTask;





        }

    }
}
