using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Moq.Presenter;
using Example.Moq.View;
using Moq;
using NUnit.Framework;

namespace Example.Moq.Test
{
    [TestFixture]
    public class PatientRegistrationFormViewPresenterTest
    {
        [Test]
        public void Save_RegisterNewPatient_ShouldGetPatientNameFromView()
        {
            // Arrange
            var registrationService = new Mock<IPatientRegistrationService>();
            var view = new Mock<IPatientRegistrationFormView>();

            var patientName = "Test Patient";

            // 设置PatientName属性的Getter来返回测试用的病人姓名
            view.SetupGet(v => v.PatientName).Returns(patientName).Verifiable();

            // RegisterPatient用的病人姓名应该与PatientName属性的值一致
            registrationService.Setup(r => r.RegisterPatient(It.Is<string>(n => n == patientName)))
                .Verifiable();

            var presenter = new PatientRegistrationFormViewPresenter(view.Object, registrationService.Object);

            // Action
            presenter.Save();

            // Assert
            view.Verify();
            registrationService.Verify();
        }

        [Test]
        public void Save_RegisterNewPatient_ShouldGetPatientNameFromView_2()
        {
            // Arrange
            var registrationService = new Mock<IPatientRegistrationService>();
            var view = new Mock<IPatientRegistrationFormView>();

            var presenter = new PatientRegistrationFormViewPresenter(view.Object, registrationService.Object);

            // Action
            presenter.Save();

            // Assert
            view.Verify(v => v.PatientName, Times.Once);
        }

        [Test]
        public void Load_LoadPatientInfo_ShouldSetPatientNameToView()
        {
            // Arrange
            var registrationService = new Mock<IPatientRegistrationService>();
            var view = new Mock<IPatientRegistrationFormView>();

            var patientName = "Test Patient";

            // 插入GetPatient的返回值
            registrationService.Setup(r => r.GetPatient()).Returns(patientName)
                .Verifiable();

            // 设置PatientName属性的Setter设置值应当与GetPatient返回值一致病人姓名
            view.SetupSet(v => v.PatientName = It.Is<string>(n => n == patientName))
                .Verifiable();

            var presenter = new PatientRegistrationFormViewPresenter(view.Object, registrationService.Object);

            // Action
            presenter.Load();

            // Assert
            view.Verify();
            registrationService.Verify();
        }

        [Test]
        public void Load_LoadPatientInfo_ShouldSetPatientNameToView_2()
        {
            // Arrange
            var registrationService = new Mock<IPatientRegistrationService>();
            var view = new Mock<IPatientRegistrationFormView>();

            var patientName = "Test Patient";

            // 插入GetPatient的返回值
            registrationService.Setup(r => r.GetPatient()).Returns(patientName);

            var presenter = new PatientRegistrationFormViewPresenter(view.Object, registrationService.Object);

            // Action
            presenter.Load();

            // Assert
            view.Verify(v => v.PatientName == patientName, Times.Once);
        }
    }
}
