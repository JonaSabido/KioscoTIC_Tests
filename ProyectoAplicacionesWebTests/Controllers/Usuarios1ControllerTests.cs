using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoAplicacionesWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoAplicacionesWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace ProyectoAplicacionesWeb.Controllers.Tests
{
    [TestClass()]
    public class Usuarios1ControllerTests
    {
        [TestMethod()]
        public void CreateTest0_DeberiaCrearseElUsuarioPorqueTodosLosCamposEstanLlenos()
        {
            //Arrange
            var newUsuario = new Usuario() { Correo = "user12111@hotmail.com", Nombre = "Sergio", ApellidoP = "Perez", ApellidoM = "Salazar", Estatus = true, Contraseña = "123" };
            string excepted = "Index";

            //Act
            Kiosco_UTM_FINALContext conext = new Kiosco_UTM_FINALContext();
            Usuarios1Controller usuario = new Usuarios1Controller(conext);
            var actionResult = usuario.Create(newUsuario).Result as RedirectToActionResult;

            //Assert
            Assert.AreEqual(actionResult.ActionName, excepted);
        }

        [TestMethod()]
        public void CreateTest1_NoDeberiaCrearseElUsuarioPorQueTodosLosCamposEstanVacios()
        {
            //Arrange
            var newUsuario = new Usuario() { Correo = null, Nombre = null, ApellidoP = null, ApellidoM = null, Estatus = null, Contraseña = null };

            //Act
            Kiosco_UTM_FINALContext conext = new Kiosco_UTM_FINALContext();
            Usuarios1Controller usuario = new Usuarios1Controller(conext);
            var actionResult = usuario.Create(newUsuario).Result as ViewResult;

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(ViewResult));

        }

        
        [TestMethod()]
        public void CreateTest2_NoDeberiaCrearseElUsuarioPorQueEnLosCamposHayNumeros()
        {
            //Arrange
            var newUsuario = new Usuario() { Correo = "user1@hotmail.com", Nombre = "Serg10", ApellidoP = "Per3z", ApellidoM = "Sal4z4r", Estatus = true, Contraseña = "123" };

            //Act
            Kiosco_UTM_FINALContext conext = new Kiosco_UTM_FINALContext();
            Usuarios1Controller usuario = new Usuarios1Controller(conext);
            var actionResult = usuario.Create(newUsuario).Result as ViewResult;

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(ViewResult));

        }
        


        [TestMethod()]
        public void CreateTest3_DeberiaNoCrearseElUsuarioPorqueElCampoCorreoNoEsValido()
        {
            //Arrange
            var newUsuario = new Usuario() { Correo = "example", Nombre = "Sergio", ApellidoP = "Perez", ApellidoM = "Salazar", Estatus = true, Contraseña = "123" };

            //Act
            Kiosco_UTM_FINALContext conext = new Kiosco_UTM_FINALContext();
            Usuarios1Controller usuario = new Usuarios1Controller(conext);
            var actionResult = usuario.Create(newUsuario).Result as ViewResult;

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(ViewResult));

        }

        [TestMethod()]
        public void CreateTest4_NoDeberiaCrearseElUsuarioPorqueRegresamosAlIndex()
        {
            //Arrange
            var newUsuario = new Usuario() { Correo = "user1@hotmail.com", Nombre = "Sergio", ApellidoP = "Perez", ApellidoM = "Salazar", Estatus = true, Contraseña = "123" };
            string excepted = "Index";

            //Act
            Kiosco_UTM_FINALContext conext = new Kiosco_UTM_FINALContext();
            Usuarios1Controller usuario = new Usuarios1Controller(conext);
            var actionResult = usuario.Index().Result as ViewResult;

            //Assert
            Assert.AreEqual(excepted, actionResult.ViewName);

        }

        
    }
}