using FluentAssertions;
using Moq;
using AutoMapper;
using TaskManagement.Application.Features.Tasks.Create;
using TaskManagement.Application.Features.Tasks.DTOs;
using TaskManagement.Application.Interfaces.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Tests.Tasks.Create
{
    public class CreateTaskHandlerTests
    {
        private readonly Mock<ITaskRepository> _taskRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly CreateTaskHandler _handler;

        public CreateTaskHandlerTests()
        {
            _taskRepositoryMock = new Mock<ITaskRepository>();
            _mapperMock = new Mock<IMapper>();

            _handler = new CreateTaskHandler(
                _taskRepositoryMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task Should_CreateTask_And_ReturnTaskDto()
        {
            // Arrange
            var dto = new CreateTaskDto
            {
                Title = "Test Task",
                Description = "Test Description",
                Priority = TaskPriority.High
            };

            var command = new CreateTaskCommand(dto);

            var taskItem = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                Priority = dto.Priority
            };

            var createdTask = new TaskItem
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Description = dto.Description,
                Priority = dto.Priority,
                Status = TaskItemStatus.ToDo,
                CreatedAt = DateTime.UtcNow
            };

            var taskDto = new TaskDto
            {
                Id = createdTask.Id,
                Title = createdTask.Title,
                Description = createdTask.Description,
                Priority = createdTask.Priority,
                Status = createdTask.Status,
                CreatedAt = createdTask.CreatedAt
            };

            _mapperMock
                .Setup(x => x.Map<TaskItem>(dto))
                .Returns(taskItem);

            _taskRepositoryMock
                .Setup(x => x.AddAsync(taskItem))
                .ReturnsAsync(createdTask);

            _mapperMock
                .Setup(x => x.Map<TaskDto>(createdTask))
                .Returns(taskDto);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(createdTask.Id);
            result.Title.Should().Be(dto.Title);
        }

        [Fact]
        public async Task Should_Call_AddAsync_When_HandlerExecutes()
        {
            // Arrange
            var dto = new CreateTaskDto
            {
                Title = "Test Task",
                Description = "Test Description",
                Priority = TaskPriority.High
            };

            var command = new CreateTaskCommand(dto);

            _taskRepositoryMock
                .Setup(x => x.AddAsync(It.IsAny<TaskItem>()))
                .ReturnsAsync((TaskItem t) => t);

            _mapperMock
                .Setup(x => x.Map<TaskItem>(It.IsAny<CreateTaskDto>()))
                .Returns((CreateTaskDto d) => new TaskItem
                {
                    Title = d.Title,
                    Description = d.Description,
                    Priority = d.Priority
                });

            _mapperMock
                .Setup(x => x.Map<TaskDto>(It.IsAny<TaskItem>()))
                .Returns((TaskItem t) => new TaskDto
                {
                    Title = t.Title,
                    Description = t.Description,
                    Priority = t.Priority
                });

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _taskRepositoryMock.Verify(x => x.AddAsync(It.IsAny<TaskItem>()), Times.Once);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task Should_ReturnCorrectData_FromHandler()
        {
            // Arrange
            var dto = new CreateTaskDto
            {
                Title = "Test Task",
                Description = "Test Description",
                Priority = TaskPriority.High
            };

            var command = new CreateTaskCommand(dto);

            _taskRepositoryMock
                .Setup(x => x.AddAsync(It.IsAny<TaskItem>()))
                .ReturnsAsync((TaskItem t) => t);

            _mapperMock
                .Setup(x => x.Map<TaskItem>(It.IsAny<CreateTaskDto>()))
                .Returns((CreateTaskDto d) => new TaskItem
                {
                    Title = d.Title,
                    Description = d.Description,
                    Priority = d.Priority
                });

            _mapperMock
                .Setup(x => x.Map<TaskDto>(It.IsAny<TaskItem>()))
                .Returns((TaskItem t) => new TaskDto
                {
                    Title = t.Title,
                    Description = t.Description,
                    Priority = t.Priority
                });

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Title.Should().Be(dto.Title);
            result.Description.Should().Be(dto.Description);
            result.Priority.Should().Be(dto.Priority);
        }
    }
}