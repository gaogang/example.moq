using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Moq.Presenter;
using Moq;
using NUnit.Framework;

namespace Example.Moq.Test
{
    [TestFixture]
    public class PatientListPresenterTest
    {
        //// public void AddPatient(string patientName)
        //// {
        ////    RegisterPatient(patientName);
        ////    UpdatePatientList();
        //// }
        [Test]
        public void AddPatien_CreateNewPatientRecord_ShouldRegisterThePatientAndUpdatePatientList()
        {
            // Arrange
            var presenterMock = new Mock<PatientListPresenter>();
            var patient = "Test Patient";

            // CallBase设为真时，Moq允许局部替换
            presenterMock.CallBase = true;

            // 当PatientListPresenter的RegisterPatient函数被调用时，我们要验证AddPatient会：
            // 1. 调用RegisterPatient函数
            // 2. 调用UpdatePatientList函数
            presenterMock.Setup(p => p.RegisterPatient(It.Is<string>(n => n == patient))).Verifiable();
            presenterMock.Setup(p => p.UpdatePatientList()).Verifiable();

            // Action
            presenterMock.Object.AddPatient(patient); // CallBase设为真时
                                                      // 我们可以这样来直接调用AddPatient函数

            // Assert
            presenterMock.Verify();
        }
    }
}
