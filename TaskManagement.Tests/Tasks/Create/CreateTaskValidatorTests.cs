using FluentAssertions;
using TaskManagement.Application.Features.Tasks.DTOs;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Tests.Tasks.Create
{
    public class CreateTaskValidatorTests
    {
        private readonly CreateTaskValidator _validator;

        public CreateTaskValidatorTests()
        {
            _validator = new CreateTaskValidator();
        }

        [Fact]
        public void Should_ReturnError_When_TitleIsEmpty()
        {
            // Arrange
            var dto = new CreateTaskDto
            {
                Title = "",
                Description = "Some Description",
                Priority = TaskPriority.Medium
            };

            // Act
            var result = _validator.Validate(dto);

            // Assert
            result.IsValid.Should().BeFalse();

            result.Errors.Should().Contain(e => 
                e.PropertyName == "Title" &&
                e.ErrorMessage == "Title is required");
        }

        [Fact]
        public void Should_ReturnError_When_TitleTooLong()
        {
            // Arrange
            var dto = new CreateTaskDto
            {
                Title = new string('a', 101),
                Description = "Some Description",
                Priority = TaskPriority.Medium
            };

            // Act
            var result = _validator.Validate(dto);

            // Assert
            result.IsValid.Should().BeFalse();

            result.Errors.Should()
                .Contain(e => e.PropertyName == "Title");
        }
        
        [Fact]
        public void Should_ReturnError_When_DescriptionTooLong()
        {
            // Arrange
            var dto = new CreateTaskDto
            {
                Title = "Create Task",
                Description = new string('a', 501),
                Priority = TaskPriority.Medium
            };

            // Act
            var result = _validator.Validate(dto);

            // Assert
            result.IsValid.Should().BeFalse();

            result.Errors.Should()
                .Contain(e => e.PropertyName == "Description");
        }
        
        [Fact]
        public void Should_ReturnError_When_PriorityInvalid()
        {
            // Arrange
            var dto = new CreateTaskDto
            {
                Title = "Create Task",
                Description = "Some Description",
                Priority = (TaskPriority)5
            };

            // Act
            var result = _validator.Validate(dto);

            // Assert
            result.IsValid.Should().BeFalse();

            result.Errors.Should()
                .Contain(e => e.PropertyName == "Priority");
        }

        [Fact]
        public void Should_Pass_When_AllFieldsValid()
        {
            // Arrange
            var dto = new CreateTaskDto
            {
                Title = "Create Task",
                Description = "Some Description",
                Priority = TaskPriority.Low
            };

            // Act
            var result = _validator.Validate(dto);

            // Assert
            result.IsValid.Should().BeTrue();
        }

    }
}
