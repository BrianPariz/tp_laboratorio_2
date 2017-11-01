using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivos;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;
using static EntidadesInstanciables.Universidad;

namespace TestUnitarios
{
    [TestClass]
    public class TestTp
    {

        [TestMethod]
        public void DireccionErroneaArchivoTXT()
        {
            try
            {
                Texto archivo = new Texto();

                if (archivo.Guardar("", "Hola"))
                    Assert.Fail("Debería tirar exception si no se encuentra la ruta");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArchivosException));
            }
        }

        [TestMethod]
        public void DireccionErroneaArchivoXML()
        {
            try
            {
                Xml<string> archivo = new Xml<string>();

                if (archivo.Guardar("", "Hola"))
                    Assert.Fail("Debería tirar exception si no se encuentra la ruta");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArchivosException));
            }
        }

        [TestMethod]
        public void SinProfesorParaUnaClase()
        {
            try
            {
                Universidad u = new Universidad();
                Profesor i = (u == EClases.Laboratorio);

                Assert.Fail("Debería tirar exception si encuentra un profesor para la clase");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(SinProfesorException));
            }
        }

        /// <summary>
        /// Debería tirar false y no una NullReferenceException
        /// </summary>
        [TestMethod]
        public void ReferenciaNull()
        {
            Profesor i = null;
            Alumno a = null;

            Assert.AreEqual((i == a), false);
        }
        
        [TestMethod]
        public void DniMenorAlPermitido()
        {
            try
            {
                new Profesor(12, "nombre", "apellido", "0", Persona.ENacionalidad.Argentino);
                Assert.Fail("No debería dejar poner un DNI con número menor al permitido");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(DniInvalidoException));
            }
        }
    }
}
