    namespace Problema_1_Parcial_3
{
    internal class Rectangulo : Figura
    {
        public double Base { get; }
        public double Altura { get; }

        public Rectangulo(double baseRectangulo, double altura)
        {
            Base = baseRectangulo;
            Altura = altura;
        }

        public override double CalcularArea()
        {
            return Base * Altura;
        }

        public override double CalcularPerimetro()
        {
            return 2 * (Base + Altura);
        }
    }
}
