namespace Domain.Entities
{
    public partial class LecturesPool
    {
        public int IdLecturesPool { get; set; }
        public string IdUser { get; set; }
        public int IdLecture { get; set; }

        public virtual Lectures IdLectureNavigation { get; set; }
        public virtual Users IdUserNavigation { get; set; }
    }
}
