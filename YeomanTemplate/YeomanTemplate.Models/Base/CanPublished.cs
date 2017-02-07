namespace YeomanTemplate.Models.Base {
    public abstract class CanPublished : Auditable, IPublished {
        public bool IsVisible { get; set; }
    }
}