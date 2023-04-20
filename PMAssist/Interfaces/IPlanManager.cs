using PMAssist.Models;

namespace PMAssist.Interfaces
{
    public interface IPlanManager
    {
        Task PlanSprint(ActivityRequestModel activityRequestModel);
    }
}
