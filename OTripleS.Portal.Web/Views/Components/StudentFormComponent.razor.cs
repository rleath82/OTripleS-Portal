using Microsoft.AspNetCore.Components;
using OTripleS.Portal.Web.Models.Basics;
using OTripleS.Portal.Web.Views.Bases;

namespace OTripleS.Portal.Web.Views.Components
{
    public partial class StudentFormComponent : ComponentBase
    {
        public TextBoxBase StudentNameTextBox { get; set; }
        public ComponentState State { get; set; }

        protected override void OnInitialized()
        {
            this.State = ComponentState.Content;
        }
    }
}
