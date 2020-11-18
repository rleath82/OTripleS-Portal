using FluentAssertions;
using OTripleS.Portal.Web.Models.Basics;
using OTripleS.Portal.Web.Views.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;
using Xunit;

namespace OTripleS.Portal.Web.Tests.Unit.Components
{
    public partial class StudentFormComponentTests
    {
        [Fact]
        public void ShouldInitializeComponent()
        {
            var initialStudentFormComponent = new StudentFormComponent();

            initialStudentFormComponent.StudentNameTextBox.Should().BeNull();
        }

        [Fact]
        public void ShouldRenderComponent()
        {
            ComponentState expectedState = ComponentState.Content;

            this.renderedStudentFormComponent = RenderComponent<StudentFormComponent>();

            this.renderedStudentFormComponent.Instance.State
                .Should().BeEquivalentTo(expectedState);

            this.renderedStudentFormComponent.Instance.StudentNameTextBox
                .Should().NotBeNull();

            this.renderedStudentFormComponent.Instance.StudentNameTextBox.PlaceHolder
                .Should().BeEquivalentTo("Name");
        }
    }
}
