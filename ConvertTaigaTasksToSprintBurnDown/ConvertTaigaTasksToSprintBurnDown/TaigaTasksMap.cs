namespace ConvertTaigaTasksToSprintBurnDown
{
    using CsvHelper.Configuration;

    public sealed class TaigaTasksMap : CsvClassMap<TaigaTasks>
    {
        public TaigaTasksMap()
        {
            Map(m => m.AssignedTo).Name("assigned_to");
            Map(m => m.AssignedToFullName).Name("assigned_to_full_name");
            Map(m => m.Attachments).Name("attachments");
            Map(m => m.CompletedWork).Name("Completed Work");
            Map(m => m.CreatedDate).Name("created_date");
            Map(m => m.Description).Name("description");
            Map(m => m.ExternalReference).Name("external_reference");
            Map(m => m.FinishedDate).Name("finished_date");
            Map(m => m.IsClosed).Name("is_closed");
            Map(m => m.IsIocaine).Name("is_iocaine");
            Map(m => m.ModifiedDate).Name("modified_date");
            Map(m => m.OriginalEstimate).Name("Original Estimate");
            Map(m => m.Owner).Name("owner");
            Map(m => m.OwnerFullName).Name("owner_full_name");
            Map(m => m.Reference).Name("ref");
            Map(m => m.RemainingWork).Name("Remaining Work");
            Map(m => m.Sprint).Name("sprint");
            Map(m => m.SprintEstimatedFinish).Name("sprint_estimated_finish");
            Map(m => m.SprintEstimatedStart).Name("sprint_estimated_start");
            Map(m => m.Status).Name("status");
            Map(m => m.Subject).Name("subject");
            Map(m => m.Tags).Name("tags");
            Map(m => m.TaskboardOrder).Name("taskboard_order");
            Map(m => m.UserStory).Name("user_story");
            Map(m => m.UserStoryOrder).Name("us_order");
            Map(m => m.Voters).Name("voters");
            Map(m => m.Watchers).Name("watchers");
        }
    }
}