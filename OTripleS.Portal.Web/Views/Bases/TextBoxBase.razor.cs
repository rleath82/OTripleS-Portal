using Microsoft.AspNetCore.Components;

namespace OTripleS.Portal.Web.Views.Bases
{
    public partial class TextBoxBase
    {
        [Parameter] public string Value { get; set; }
        [Parameter] public string PlaceHolder { get; set; }

        public void SetValue(string value) => this.Value = value;
    }
}
