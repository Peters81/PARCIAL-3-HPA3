namespace Problema_1_Parcial_3
{
    internal class Triangulo : Figura
    {
        public double Base { get; }
        public double Altura { get; }
        public double Lado2 { get; }
        public double Lado3 { get; }

        
        public Triangulo(double baseTriangulo, double altura, double lado2, double lado3)
        {
            Base = baseTriangulo;
            Altura = altura;
            Lado2 = lado2;
            Lado3 = lado3;
        }

        public override double CalcularArea()
        {
            return (Base * Altura) / 2;
        }

        public override double CalcularPerimetro()
        {
            return Base + Lado2 + Lado3;
        }
    }
}
