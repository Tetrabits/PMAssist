using PMAssist.Models;
using PMAssist.Models.External;

namespace PMAssist.Interfaces
{
    public interface ISprintManager
    {
        Task<ProjectEx> GetSprint(string sprintKey, ProjectEx project);
        Task<IEnumerable<Story>> GetStories(string sprintKey);
        Task AddSprintActivity(ActivityRequestModel activityRequestModel);
    }
}