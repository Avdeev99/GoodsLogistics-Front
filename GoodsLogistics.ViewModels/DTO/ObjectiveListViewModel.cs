using System;
using System.Collections.Generic;
using System.Text;

namespace GoodsLogistics.ViewModels.DTO
{
    public class ObjectiveListViewModel
    {
        public ObjectiveListViewModel() { }

        public ObjectiveListViewModel(List<ObjectiveViewModel> objectives)
        {
            Objectives = objectives;
        }

        public List<ObjectiveViewModel> Objectives { get; set; }

        public ObjectiveFilteringViewModel Filter { get; set; } = new ObjectiveFilteringViewModel();
    }
}
