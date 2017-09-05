using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lead.Business.Logic;
using Lead.Domain.Abstract;
using Lead.Models.Entities;
using Lead.Models.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Lead.WebAPI.Tests.Controllers
{
    [TestClass]
    public class VisitorControllerTest 
    {

        [TestMethod]
        public void GetSingle()
        {
            AutoMapperConfig.RegisterMappings();
            

            //Arrange
            var visitors = new List<Visitor>()
            { new Visitor
            { 
                Id = Guid.Parse("b3b1cb1a-f4f5-4cf4-a05c-6d72f3f412fa"),
                FirstName = "Karl",
                Surname = "Johnson"
            }};

            Mock<IRepository<Visitor>> visitorRepository = new Mock<IRepository<Visitor>>();
            //Setup the mock
            visitorRepository
                .Setup(x => x.ListQuerable()).Returns(visitors.AsQueryable);


            var visitorLogic = new VisitorLogic(visitorRepository.Object); 

          

            //Act
            IQueryable<VisitorModel> model = visitorLogic.OdataGetSingle(visitors[0].Id);

            //Assert
            Assert.AreEqual(model.First().Id, visitors[0].Id);
        }
    }
}
