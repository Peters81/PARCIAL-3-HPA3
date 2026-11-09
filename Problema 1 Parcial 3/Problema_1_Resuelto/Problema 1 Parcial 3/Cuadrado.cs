namespace Problema_1_Parcial_3
{
    internal class Cuadrado : Figura
    {
        public double Lado { get; }

        public Cuadrado(double lado)
        {
            Lado = lado;
        }

        public override double CalcularArea()
        {
            return Lado * Lado;
        }

        public override double CalcularPerimetro()
        {
            return 4 * Lado;
        }
    }
}
