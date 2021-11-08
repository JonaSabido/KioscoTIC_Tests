using Microsoft.VisualStudio.TestTools.UnitTesting;
using KioscoTIC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoAplicacionesWeb.Controllers;
using ProyectoAplicacionesWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace KioscoTIC.Controllers.Tests
{
    [TestClass()]
    public class KioscoTICTests
    {
        [DataRow("abrahamherrera0001@gmail.com", "123", true)] //Arrange
        [TestMethod()]
        public void LoginTest0_DeberiaIniciarSesionPorQueEncuentraAlUsuario(string Cor, string Contra, bool excepted)
        {
            //Act
            Kiosco_UTM_FINALContext contexto = new Kiosco_UTM_FINALContext();
            KioscoTIC kiosco = new KioscoTIC(contexto);
            bool bandera = kiosco.VerificarCuenta(Cor, Contra);

            //Assert
            Assert.AreEqual(excepted, bandera);
        }

        [DataRow(null, "123", false)] //Arrange
        [TestMethod()]
        public void LoginTest1_NoDeberiaIniciarSesionPorQueNoHayCorreo(string Cor, string Contra, bool excepted)
        {
            //Act
            Kiosco_UTM_FINALContext contexto = new Kiosco_UTM_FINALContext();
            KioscoTIC kiosco = new KioscoTIC(contexto);
            bool bandera = kiosco.VerificarCuenta(Cor, Contra);

            //Assert
            Assert.AreEqual(excepted, bandera);
        }

        [DataRow("example@hotmail.com", "123", false)] //Arrange
        [TestMethod()]
        public void LoginTest2_NoDeberiaIniciarSesionPorQueNoExisteElCorreo(string Cor, string Contra, bool excepted)
        {
            //Act
            Kiosco_UTM_FINALContext contexto = new Kiosco_UTM_FINALContext();
            KioscoTIC kiosco = new KioscoTIC(contexto);
            bool bandera = kiosco.VerificarCuenta(Cor, Contra);

            //Assert
            Assert.AreEqual(excepted, bandera);
        }

        [DataRow("hola", "123", false)] //Arrange
        [TestMethod()]
        public void LoginTest3_NoDeberiaIniciarSesionPorQueNoEsUnCorreoValido(string Cor, string Contra, bool excepted)
        {
            //Act
            Kiosco_UTM_FINALContext contexto = new Kiosco_UTM_FINALContext();
            KioscoTIC kiosco = new KioscoTIC(contexto);
            bool bandera = kiosco.VerificarCuenta(Cor, Contra);

            //Assert
            Assert.AreEqual(excepted, bandera);
        }

        [DataRow("abrahamherrera0001@gmail.com", null, false)] //Arrange
        [TestMethod()]
        public void LoginTest4_NoDeberiaIniciarSesionPorQueNoHayContraseña(string Cor, string Contra, bool excepted)
        {
            //Act
            Kiosco_UTM_FINALContext contexto = new Kiosco_UTM_FINALContext();
            KioscoTIC kiosco = new KioscoTIC(contexto);
            bool bandera = kiosco.VerificarCuenta(Cor, Contra);

            //Assert
            Assert.AreEqual(excepted, bandera);
        }

        [DataRow("abrahamherrera0001@gmail.com", "123456", false)] //Arrange
        [TestMethod()]
        public void LoginTest5_NoDeberiaIniciarSesionPorQueContraseñaIncorrecta(string Cor, string Contra, bool excepted)
        {
            //Act
            Kiosco_UTM_FINALContext contexto = new Kiosco_UTM_FINALContext();
            KioscoTIC kiosco = new KioscoTIC(contexto);
            bool bandera = kiosco.VerificarCuenta(Cor, Contra);

            //Assert
            Assert.AreEqual(excepted, bandera);
        }

        [DataRow(null, null, false)] //Arrange
        [TestMethod()]
        public void LoginTest6_NoDeberiaIniciarSesionPorQueNoSeLePasanDatosValidos(string Cor, string Contra, bool excepted)
        {
            //Act
            Kiosco_UTM_FINALContext contexto = new Kiosco_UTM_FINALContext();
            KioscoTIC kiosco = new KioscoTIC(contexto);
            bool bandera = kiosco.VerificarCuenta(Cor, Contra);

            //Assert
            Assert.AreEqual(excepted, bandera);
        }

        [DataRow("hola@hotmail.com", "123", false)] //Arrange
        [TestMethod()]
        public void LoginTest7_NoDeberiaIniciarSesionPorQueElUsuarioEstaDadoDeBaja(string Cor, string Contra, bool excepted)
        {
            //Act
            Kiosco_UTM_FINALContext contexto = new Kiosco_UTM_FINALContext();
            KioscoTIC kiosco = new KioscoTIC(contexto);
            bool bandera = kiosco.VerificarCuenta(Cor, Contra);

            //Assert
            Assert.AreEqual(excepted, bandera);
        }
    }
}