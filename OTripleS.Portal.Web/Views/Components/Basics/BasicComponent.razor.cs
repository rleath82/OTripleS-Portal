using Microsoft.AspNetCore.Components;
using OTripleS.Portal.Web.Models.Basics;

namespace OTripleS.Portal.Web.Views.Components.Basics
{
    public partial class BasicComponent : ComponentBase
    {
        [Parameter] public ComponentState State { get; set; }
        [Parameter] public RenderFragment Loading { get; set; }
        [Parameter] public RenderFragment Content { get; set; }
        [Parameter] public RenderFragment Error { get; set; }

        public RenderFragment GetFragment()
        {
            return State switch
            {
                ComponentState.Loading => Loading,
                ComponentState.Content => Content,
                _ => Error
            };
        }
    }
}
