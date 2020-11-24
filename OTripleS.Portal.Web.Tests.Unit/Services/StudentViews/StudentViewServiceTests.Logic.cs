﻿using FluentAssertions;
using Moq;
using OTripleS.Portal.Web.Models.Students;
using OTripleS.Portal.Web.Models.StudentViews;
using System;
using System.Threading.Tasks;
using Xunit;

namespace OTripleS.Portal.Web.Tests.Unit.Services.StudentViews
{
    public partial class StudentViewServiceTests
    {
        [Fact]
        public async Task ShouldAddStudentViewAsync()
        {
            //given
            Guid randomUserId = Guid.NewGuid();
            DateTimeOffset randomDateTime = GetRandomDate();
            dynamic randomStudentViewProperties =
                CreateRandomStudentViewProperties(
                    auditDates: randomDateTime,
                    auditIds: randomUserId);

            var randomStudentView = new StudentView
            {
                IdentityNumber = randomStudentViewProperties.IdentityNumber,
                FirstName = randomStudentViewProperties.FirstName,
                MiddleName = randomStudentViewProperties.MiddleName,
                LastName = randomStudentViewProperties.LastName,
                Gender = randomStudentViewProperties.GenderView,
                BirthDate = randomStudentViewProperties.BirthDate
            };

            StudentView inputStudentView = randomStudentView;
            StudentView expectedStudentView = inputStudentView;

            var randomStudent = new Student
            {
                Id = randomStudentViewProperties.Id,
                UserId = randomStudentViewProperties.UserId,
                IdentityNumber = randomStudentViewProperties.IdentityNumber,
                FirstName = randomStudentViewProperties.FirstName,
                MiddleName = randomStudentViewProperties.MiddleName,
                LastName = randomStudentViewProperties.LastName,
                Gender = randomStudentViewProperties.Gender,
                BirthDate = randomStudentViewProperties.BirthDate,
                CreatedBy = randomUserId,
                UpdatedBy = randomUserId,
                CreatedDate = randomDateTime,
                UpdatedDate = randomDateTime
            };

            Student expectedInputStudent = randomStudent;
            Student returnedStudent = expectedInputStudent;

            this.userServiceMock.Setup(service =>
                service.GetCurrentlyLoggedInUser())
                    .Returns(randomUserId);

            this.dateTimeBrokerMock.Setup(broker =>
                broker.GetCurrentDateTime())
                    .Returns(randomDateTime);

            this.studentServiceMock.Setup(service =>
                service.RegisterStudentAsync(It.Is(
                    SameStudentAs(expectedInputStudent))))
                        .ReturnsAsync(returnedStudent);

            //when
            StudentView actualStudentView = await this.studentViewService.AddStudentViewAsync(inputStudentView);

            //then
            actualStudentView.Should().BeEquivalentTo(expectedStudentView);

            this.userServiceMock.Verify(service =>
                service.GetCurrentlyLoggedInUser(),
                    Times.Once);

            this.dateTimeBrokerMock.Verify(broker =>
                broker.GetCurrentDateTime(),
                    Times.Once);

            this.studentServiceMock.Verify(service =>
                service.RegisterStudentAsync(It.Is(
                    SameStudentAs(expectedInputStudent))),
                        Times.Once);

            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.userServiceMock.VerifyNoOtherCalls();
            this.studentServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
