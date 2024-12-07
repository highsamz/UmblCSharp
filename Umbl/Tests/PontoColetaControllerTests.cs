namespace Umbl.Tests
{
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Umbl.Controllers;
    using Umbl.Controllers.Umbl.Controllers;
    using Umbl.Data.Repository.Umbl.Data.Repository;
    using Umbl.Models;
    using Umbl.Services;
    using Xunit;

    public class PontoColetaControllerTests
    {
        private readonly Mock<IPontoColetaRepository> _mockRepository;
        private readonly PontoColetaController _controller;

        public PontoColetaControllerTests()
        {
            _mockRepository = new Mock<IPontoColetaRepository>();
            _controller = new PontoColetaController(_mockRepository.Object);
        }

        [Fact]
        public void GetAll_ShouldReturnOkStatus_WhenValidRequest()
        {
            var paginatedResult = new PaginatedResult<PontoColetaModel>
            {
                Items = new List<PontoColetaModel> { new PontoColetaModel { Id = 1, Email = "Ponto 1" } },
                TotalItems = 1,
                PageNumber = 1,
                PageSize = 10,
                TotalPages = 1
            };

            _mockRepository.Setup(r => r.GetAllPaginated(It.IsAny<int>(), It.IsAny<int>())).Returns(paginatedResult);

            var result = _controller.GetAll(1, 10);

            var actionResult = Assert.IsType<ActionResult<PaginatedResult<PontoColetaModel>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void GetById_ShouldReturnOk_WhenPontoColetaExists()
        {
            var pontoColeta = new PontoColetaModel { Id = 1};
            _mockRepository.Setup(r => r.GetById(1)).Returns(pontoColeta);

            var result = _controller.GetById(1);

            var actionResult = Assert.IsType<ActionResult<PontoColetaModel>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void GetById_ShouldReturnNotFound_WhenPontoColetaDoesNotExist()
        {
            _mockRepository.Setup(r => r.GetById(1)).Returns((PontoColetaModel)null);

            var result = _controller.GetById(1);

            var actionResult = Assert.IsType<ActionResult<PontoColetaModel>>(result);
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(actionResult.Result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }

        [Fact]
        public void Create_ShouldReturnCreated_WhenModelIsValid()
        {
            var pontoColeta = new PontoColetaModel { Id = 1};
            _mockRepository.Setup(r => r.Add(It.IsAny<PontoColetaModel>()));

            var result = _controller.Create(pontoColeta);

            var actionResult = Assert.IsType<ActionResult<PontoColetaModel>>(result);
            var createdResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            Assert.Equal(201, createdResult.StatusCode);
        }

        [Fact]
        public void Create_ShouldReturnBadRequest_WhenModelIsInvalid()
        {
            _controller.ModelState.AddModelError("Nome", "Campo obrigatório");
            var pontoColeta = new PontoColetaModel();

            var result = _controller.Create(pontoColeta);

            var actionResult = Assert.IsType<ActionResult<PontoColetaModel>>(result);
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public void Update_ShouldReturnNoContent_WhenPontoColetaExists()
        {
            var pontoColeta = new PontoColetaModel { Id = 1 };
            _mockRepository.Setup(r => r.GetById(1)).Returns(pontoColeta);

            var result = _controller.Update(1, pontoColeta);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Update_ShouldReturnNotFound_WhenPontoColetaDoesNotExist()
        {
            var pontoColeta = new PontoColetaModel { Id = 1 };
            _mockRepository.Setup(r => r.GetById(1)).Returns((PontoColetaModel)null);

            var result = _controller.Update(1, pontoColeta);

            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }

        [Fact]
        public void Update_ShouldReturnBadRequest_WhenModelIsInvalid()
        {
            _controller.ModelState.AddModelError("Nome", "Campo obrigatório");
            var pontoColeta = new PontoColetaModel { Id = 1 };

            var result = _controller.Update(1, pontoColeta);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public void Delete_ShouldReturnOk_WhenPontoColetaExists()
        {
            var pontoColeta = new PontoColetaModel { Id = 1};
            _mockRepository.Setup(r => r.GetById(1)).Returns(pontoColeta);

            var result = _controller.Delete(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void Delete_ShouldReturnNotFound_WhenPontoColetaDoesNotExist()
        {
            _mockRepository.Setup(r => r.GetById(1)).Returns((PontoColetaModel)null);

            var result = _controller.Delete(1);

            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }

    }
}
