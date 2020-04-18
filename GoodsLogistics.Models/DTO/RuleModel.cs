using GoodsLogistics.Models.DTO.Objective;

namespace GoodsLogistics.Models.DTO
{
    public class RuleModel
    {
        public RuleModel() { }

        public RuleModel(string content)
        {
            Content = content;
        }

        public string RuleId { get; set; }

        public string Content { get; set; }

        public string ObjectiveId { get; set; }

        public ObjectiveModel Objective { get; set; }
    }
}
