namespace $rootnamespace$.Models {

    /// <summary>
    ///  Audition data
    /// </summary>
    public interface IHaveAudit {

        DateTime CreatedAt { get; set; }

        string CreatedBy { get; set; }

        DateTime UpdateAt { get; set; }

        string UpdatedBy { get; set; }
    }
}