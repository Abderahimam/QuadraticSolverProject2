using System;

namespace QuadraticSolver
{
    public static class Solver
    {
        public static double[] Solve(double a, double b, double c)
        {
            if (a == 0)
            {
                throw new ArgumentException("Coefficient 'a' must not be zero for a quadratic equation.", nameof(a));
            }

            double discriminant = b * b - 4 * a * c;

            if (discriminant < 0)
            {
                return Array.Empty<double>();
            }

            if (Math.Abs(discriminant) < 1e-12)
            {
                double root = -b / (2 * a);
                return new[] { root };
            }

            double sqrt = Math.Sqrt(discriminant);
            double r1 = (-b - sqrt) / (2 * a);
            double r2 = (-b + sqrt) / (2 * a);

            var roots = new[] { r1, r2 };
            Array.Sort(roots);
            return roots;
        }
    }
}
