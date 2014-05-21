using System.Collections.Generic;
using System.Collections.ObjectModel;
using Example.Moq.Model;
using Example.Moq.Repository;
using Moq;
using NUnit.Framework;

namespace Example.Moq.Test
{
    [TestFixture]
    public class PatientRegistrationServiceTest
    {
        [Test]
        public void RegisterPatient_RegisterAPatient_ShouldCallSavePatientOnRepository()
        {
            // Arrange
            var repository = new Mock<IPatientRepository>();
            var expected = "Test";

            // 检验:
            // 1. IPatientRepository的SavePatient函数会被调用
            // 2. SavePatient的入参和预期一致
            repository.Setup(r => r.SavePatient(It.Is<Patient>(p => p.PatientName == expected)))   
                .Verifiable();

            var target = new PatientRegistrationService(repository.Object);

            // Action
            target.RegisterPatient(expected);

            // Assert
            repository.Verify();
        }

        [Test]
        public void RegisterPatient_RegisterAPatient_VerifyCallSavePatientOnRepository()
        {
            // Arrange
            var repository = new Mock<IPatientRepository>();
            var expected = "Test";

            var target = new PatientRegistrationService(repository.Object);

            // Action
            target.RegisterPatient(expected);

            // Assert
            // 检验:
            // 1. IPatientRepository的SavePatient函数会被调用
            // 2. SavePatient的入参和预期一致
            // 3. SavePatient只会被调用一次
            repository.Verify(r => r.SavePatient(It.Is<Patient>(p => p.PatientName == expected)), 
                Times.Once);
        }

        [Test]
        public void RegisterPatient_RegisterAPatient_ShouldReturnPatientId()
        {
            // Arrange
            var repository = new Mock<IPatientRepository>();
            var expected = 111111;

            repository.Setup(r => r.SavePatient(It.IsAny<Patient>()))
                // 模拟SavePatient函数的返回值
                .Returns(expected);

            var target = new PatientRegistrationService(repository.Object);

            // Action
            var actual = target.RegisterPatient("Anything");

            // Assert
            Assert.AreEqual(expected, actual, 
                "RegisterPatient应该返回IPatientRepository.SavePatient的返回值");
        }

        [Test]
        public void RegisterPatient_RegisterAPatient_ShouldReturnPatientId2()
        {
            // Arrange
            var repository = new Mock<IPatientRepository>();
            var expected = 111111;

            repository.Setup(r => r.SavePatient(It.IsAny<Patient>()))
                // 模拟SavePatient函数的返回值
                .Returns(expected);

            var target = new PatientRegistrationService(repository.Object);

            // Action
            var actual = target.RegisterPatient("Anything");

            // Assert
            Assert.AreEqual(expected, actual,
                "RegisterPatient应该返回IPatientRepository.SavePatient的返回值");
        }

        [Test]
        public void RegisterPatients_RegisterMultiplaePatients_ShouldCallSaveOnRepositoryMultipleTimes()
        {
            // Arrange
            var repository = new Mock<IPatientRepository>();
            var expected = new Collection<string>
            {
                "A",
                "B",
                "C",
                "D"
            };

            var actual = new Collection<string>();

            repository.Setup(r => r.SavePatient(It.IsAny<Patient>()))
                // 在Callback函数里把SavePatient的入参添加到actual列表中
                .Callback<Patient>(p => actual.Add(p.PatientName));

            var target = new PatientRegistrationService(repository.Object);

            // Action
            target.RegisterPatients(expected);

            // Assert
            CollectionAssert.AreEqual(expected, actual,
                "期待集合和实际集合应该完全相符");
        }
    }
}
