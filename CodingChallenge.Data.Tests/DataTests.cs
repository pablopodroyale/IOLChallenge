using System;
using System.Collections.Generic;
using CodingChallenge.Data.Classes;
using CodingChallenge.Data.Classes.FormasGeometricas;
using NUnit.Framework;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>", FormaGeometricaNegocio.Imprimir(new List<Classes.Interfaces.IFormaGeometrica>(), 1));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",   FormaGeometricaNegocio.Imprimir(new List<Classes.Interfaces.IFormaGeometrica>(), 2));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<Classes.Interfaces.IFormaGeometrica> {new Square(5)};

            var resumen = FormaGeometricaNegocio.Imprimir(cuadrados, (int)Classes.Enum.LenguageEnum.castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<Classes.Interfaces.IFormaGeometrica>
            {
                new Square(5),
                new Square(1),
                new Square(3)
            };

            var resumen = FormaGeometricaNegocio.Imprimir(cuadrados, (int)Classes.Enum.LenguageEnum.ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<Classes.Interfaces.IFormaGeometrica>
            {
                new Square(5),
                new Circle(3),
                new TriangleEq(4),
                new Square(2),
                new TriangleEq(9),
                new Circle(2.75m),
                new  TriangleEq(4.2m)
            };

            var resumen = FormaGeometricaNegocio.Imprimir(formas, (int)Classes.Enum.LenguageEnum.ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<Classes.Interfaces.IFormaGeometrica>
            {
                new Square( 5),
                new Circle(3),
                new TriangleEq(4),
                new Square(2),
                new TriangleEq(9),
                new Circle(2.75m),
                new TriangleEq(4.2m)
            };

            var resumen = FormaGeometricaNegocio.Imprimir(formas, (int)Classes.Enum.LenguageEnum.castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }
    }
}
