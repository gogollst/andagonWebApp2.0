public class TaskX
{
    public int id { get; set; }
    public bool TimerStart { get; set; }
    public bool TimerPause { get; set; }
    public bool IsTimerRunning { get; set; }
    public int[] UserTimerId { get; set; }
    public bool DisplayTimerStartPrimary { get; set; }
    public bool DisplayTimerStop { get; set; }
    public bool DisplayTimerPause { get; set; }
    public bool DisplayTimerResume { get; set; }
    public bool HtmlFieldHistory { get; set; }
    public bool HtmlFieldHistoryMetadata { get; set; }

    public Dictionary<string, int> DurationTracking { get; set; }

    public bool MessageIsFollower { get; set; }
    public int[] MessageFollowerIds { get; set; }
    public int[] MessagePartnerIds { get; set; }
    public int[] MessageIds { get; set; }
    public bool HasMessage { get; set; }
    public bool MessageNeedaction { get; set; }
    public int MessageNeedactionCounter { get; set; }
    public bool MessageHasError { get; set; }
    public int MessageHasErrorCounter { get; set; }
    public int MessageAttachmentCount { get; set; }
    public int[] RatingIds { get; set; }
    public int[] WebsiteMessageIds { get; set; }
    public bool MessageHasSmsError { get; set; }

    public double RatingLastValue { get; set; }
    public bool RatingLastFeedback { get; set; }
    public bool RatingLastImage { get; set; }
    public int RatingCount { get; set; }
    public double RatingAvg { get; set; }
    public string RatingAvgText { get; set; }
    public double RatingPercentageSatisfaction { get; set; }
    public bool RatingLastText { get; set; }

    public int[] ActivityIds { get; set; }
    public bool ActivityState { get; set; }
    public bool ActivityUserId { get; set; }
    public bool ActivityTypeId { get; set; }
    public bool ActivityTypeIcon { get; set; }
    public bool ActivityDateDeadline { get; set; }
    public bool MyActivityDateDeadline { get; set; }
    public bool ActivitySummary { get; set; }
    public bool ActivityExceptionDecoration { get; set; }
    public bool ActivityExceptionIcon { get; set; }
    public bool ActivityCalendarEventId { get; set; }

    public bool EmailCc { get; set; }
    public string AccessUrl { get; set; }
    public string AccessToken { get; set; }
    public string AccessWarning { get; set; }
    public bool Active { get; set; }
    public string Name { get; set; }
    public bool Description { get; set; }
    public string Priority { get; set; }
    public int Sequence { get; set; }
    public object[] StageId { get; set; } // [int, string]
    public int[] TagIds { get; set; }
    public string State { get; set; }
    public bool IsClosed { get; set; }

    public DateTime CreateDate { get; set; }
    public DateTime WriteDate { get; set; }
    public bool DateEnd { get; set; }
    public DateTime DateAssign { get; set; }
    public bool DateDeadline { get; set; }
    public DateTime DateLastStageUpdate { get; set; }

    public object[] ProjectId { get; set; } // [int, string]
    public bool DisplayInProject { get; set; }
    public bool ShowDisplayInProject { get; set; }
    public object[] TaskProperties { get; set; }
    public double AllocatedHours { get; set; }
    public double SubtaskAllocatedHours { get; set; }
    public int[] UserIds { get; set; }
    public string PortalUserNames { get; set; }
    public int[] PersonalStageTypeIds { get; set; }
    public object[] PersonalStageId { get; set; } // [int, string]
    public object[] PersonalStageTypeId { get; set; } // [int, string]
    public object[] PartnerId { get; set; } // [int, string]
    public bool CompanyId { get; set; }
    public int Color { get; set; }
    public bool RatingActive { get; set; }
    public int[] AttachmentIds { get; set; }
    public bool DisplayedImageId { get; set; }
    public bool ParentId { get; set; }
    public int[] ChildIds { get; set; }
    public int SubtaskCount { get; set; }
    public int ClosedSubtaskCount { get; set; }
    public string ProjectPrivacyVisibility { get; set; }
    public double SubtaskCompletionPercentage { get; set; }

    public double WorkingHoursOpen { get; set; }
    public double WorkingHoursClose { get; set; }
    public double WorkingDaysOpen { get; set; }
    public double WorkingDaysClose { get; set; }

    public bool AllowMilestones { get; set; }
    public bool MilestoneId { get; set; }
    public bool HasLateAndUnreachedMilestone { get; set; }
    public bool AllowTaskDependencies { get; set; }
    public int[] DependOnIds { get; set; }
    public int DependOnCount { get; set; }
    public int ClosedDependOnCount { get; set; }
    public int[] DependentIds { get; set; }
    public int DependentTasksCount { get; set; }
    public bool DisplayParentTaskButton { get; set; }

    // Weitere Eigenschaften
    public bool CurrentUserSameCompanyPartner { get; set; }
    public bool DisplayFollowButton { get; set; }
    public bool RecurringTask { get; set; }
    public int RecurringCount { get; set; }
    public bool RecurrenceId { get; set; }
    public int RepeatInterval { get; set; }
    public bool RepeatUnit { get; set; }
    public bool RepeatType { get; set; }
    public bool RepeatUntil { get; set; }

    public string DisplayName { get; set; }
    public string LinkPreviewName { get; set; }
    public object[] CreateUid { get; set; } // [int, string]
    public object[] WriteUid { get; set; } // [int, string]

    public bool ProjectUseDocuments { get; set; }
    public object[] DocumentsFolderId { get; set; } // [int, string]
    public string FolderUserPermission { get; set; }
    public int[] DocumentIds { get; set; }
    public int DocumentCount { get; set; }

    public bool PlannedDateBegin { get; set; }
    public bool PlannedDateStart { get; set; }
    public bool DisplayWarningDependencyInGantt { get; set; }
    public bool PlanningOverlap { get; set; }
    public bool DependencyWarning { get; set; }
    public string UserNames { get; set; }
    public bool AnalyticAccountActive { get; set; }
    public bool AllowTimesheets { get; set; }

    public double RemainingHours { get; set; }
    public double RemainingHoursPercentage { get; set; }
    public double EffectiveHours { get; set; }
    public double TotalHoursSpent { get; set; }
    public double Progress { get; set; }
    public double Overtime { get; set; }
    public double SubtaskEffectiveHours { get; set; }
    public int[] TimesheetIds { get; set; }

    public bool EncodeUomInDays { get; set; }
    public int[] UserSkillIds { get; set; }
    public bool LeaveWarning { get; set; }
    public bool IsAbsent { get; set; }
    public int LeaveTypesCount { get; set; }
    public bool IsTimeoffTask { get; set; }

    public bool DisplayTimesheetTimer { get; set; }
    public bool DisplayTimerStartSecondary { get; set; }
    public bool SaleOrderId { get; set; }
    public bool SaleLineId { get; set; }
    public bool ProjectSaleOrderId { get; set; }
    public bool SaleOrderState { get; set; }
    public bool TaskToInvoice { get; set; }
    public bool AllowBillable { get; set; }
    public bool DisplaySaleOrderButton { get; set; }
    public string PricingType { get; set; }
    public bool IsProjectMapEmpty { get; set; }
    public bool HasMultiSol { get; set; }
    public object[] TimesheetProductId { get; set; } // [int, string]

    public double RemainingHoursSo { get; set; }
    public bool RemainingHoursAvailable { get; set; }
    public double PortalRemainingHours { get; set; }
    public double PortalEffectiveHours { get; set; }
    public double PortalTotalHoursSpent { get; set; }
    public double PortalSubtaskEffectiveHours { get; set; }
    public double PortalProgress { get; set; }
    public string XStudioConsultant { get; set; }
}