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
        [DataRow("hola@hotmail.com", "123",true)]
        [TestMethod()]
        public void OnpostTest(string Cor, string Contra, bool excepted)
        {
            Kiosco_UTM_FINALContext contexto = new Kiosco_UTM_FINALContext();
            KioscoTIC kiosco = new KioscoTIC(contexto);
            var bandera = kiosco.VerificarCuenta(Cor, Contra);

            Assert.AreEqual(excepted, bandera);



        }
        
        public Usuario prueba { get; set; }

    }
}