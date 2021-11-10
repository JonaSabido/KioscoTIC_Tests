using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoAplicacionesWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoAplicacionesWeb.Models;

namespace ProyectoAplicacionesWeb.Controllers.Tests
{
    [TestClass()]
    public class Usuarios1ControllerTests
    {
        [TestMethod()]
        public void CreateTest0_DeberiaCrearseElUsuarioPorqueTodosLosCamposEstanLlenos()
        {
            //Arrange
            Kiosco_UTM_FINALContext conext = new Kiosco_UTM_FINALContext();
            Usuarios1Controller usuario = new Usuarios1Controller(conext);
            int excepted = 13;
            var newUsuario = new Usuario() { Correo = "user1@hotmail.com", Nombre = "Sergio", ApellidoP = "Perez", ApellidoM = "Salazar", Estatus = true, Contraseña = "123" };

            //Act
            var respuesta = usuario.Create(newUsuario);

            //Assert
            Assert.AreEqual(excepted, respuesta.Id);
            
        }

        [TestMethod()]
        public void CreateTest1_NoDeberiaCrearseElUsuarioPorQueTodosLosCamposEstanVacios()
        {
            //Arrange
            Kiosco_UTM_FINALContext conext = new Kiosco_UTM_FINALContext();
            Usuarios1Controller usuario = new Usuarios1Controller(conext);
            int excepted = 1;
            var newUsuario = new Usuario() { Correo = "user1@hotmail.com", Nombre = "Sergio", ApellidoP = "Perez", ApellidoM = "Salazar", Estatus = true, Contraseña = "123" };

            //Act
            var respuesta = usuario.Create(newUsuario);

            //Assert
            Assert.AreEqual(excepted, respuesta.Id);

        }

        /*
        [TestMethod()]
        public void CreateTest2_NoDeberiaCrearseElUsuarioPorQueCampoEstatusNoEsValido()
        {
            //Arrange
            Kiosco_UTM_FINALContext conext = new Kiosco_UTM_FINALContext();
            Usuarios1Controller usuario = new Usuarios1Controller(conext);
            int excepted = 1;
            var newUsuario = new Usuario() { Correo = "user1@hotmail.com", Nombre = "Sergio", ApellidoP = "Perez", ApellidoM = "Salazar", Estatus = "hola", Contraseña = "123" };

            //Act
            var respuesta = usuario.Create(newUsuario);

            //Assert
            Assert.AreEqual(excepted, respuesta.Id);

        }
        */


        [TestMethod()]
        public void CreateTest3_DeberiaNoCrearseElUsuarioPorqueElCampoCorreoNoEsValido()
        {
            //Arrange
            Kiosco_UTM_FINALContext conext = new Kiosco_UTM_FINALContext();
            Usuarios1Controller usuario = new Usuarios1Controller(conext);
            bool excepted = false;
            bool correovalido = true;
            var newUsuario = new Usuario() { Correo = "example", Nombre = "Sergio", ApellidoP = "Perez", ApellidoM = "Salazar", Estatus = true, Contraseña = "123" };

            //Act
            if (usuario.FindCorreoValido(newUsuario.Correo))
            {
                var respuesta = usuario.Create(newUsuario);
            }
            else
            {
                correovalido = false;
            }

            //Assert
            Assert.AreEqual(excepted, correovalido);

        }
    }
}