using Moq;
using MoqWithRefArguments;
using MoqWithRefArguments.Infrastructure;
using MoqWithRefArguments.Models;

namespace MoqWithRefArgumentsTests
{
    public class PersonTest
    {
        [Fact]
        public void TestRefObjectInstance()
        {
            //arrange
            var employeeOne = new Person();
            var employeeTwo = new Person();
            var mockPersonDB = new Mock<IPersonDB>();

            //act
            mockPersonDB.Setup(x => x.Save(ref employeeOne)).Returns(1).Callback(() => employeeOne.StatusUpdate = "Person saved successfully.");
            mockPersonDB.Setup(x => x.Save(ref employeeTwo)).Returns(-1);
            var processor = new PersonProcessor(mockPersonDB.Object);
            var resultEmployeeOne = processor.SavePersonInfo(employeeOne);
            var resultEmployeeTwo = processor.SavePersonInfo(employeeTwo);

            //assert
            Assert.True(resultEmployeeOne);
            Assert.Equal("Person saved successfully.", employeeOne.StatusUpdate);
            Assert.False(resultEmployeeTwo);
        }

        [Fact]
        public void TestRefCompatibleType()
        {
            //arrange
            var employeeOne = new Person();
            var employeeTwo = new Person();
            var mockPersonDB = new Mock<IPersonDB>();

            //act
            mockPersonDB.Setup(x => x.Save(ref It.Ref<Person>.IsAny)).Returns(-1);
            var processor = new PersonProcessor(mockPersonDB.Object);
            var resultEmployeeOne = processor.SavePersonInfo(employeeOne);
            var resultEmployeeTwo = processor.SavePersonInfo(employeeTwo);

            //assert
            Assert.False(resultEmployeeOne);
            Assert.False(resultEmployeeOne);
        }
    }
}