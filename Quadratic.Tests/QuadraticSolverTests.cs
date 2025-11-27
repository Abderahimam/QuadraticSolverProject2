using System;
using Xunit;
using QuadraticSolver;

namespace QuadraticSolver.Tests
{
    public class SolverTests
    {
        [Theory]
        [InlineData(1, 0, 1)]
        [InlineData(1, 0, 4)]
        public void Solve_NoRealRoots_ReturnsEmpty(double a, double b, double c)
        {
            var roots = Solver.Solve(a, b, c);
            Assert.Empty(roots);
        }

        [Theory]
        [InlineData(1, 2, 1, -1.0)]
        [InlineData(2, -4, 2, 1.0)]
        public void Solve_OneRealRoot_ReturnsSingleRoot(double a, double b, double c, double expected)
        {
            var roots = Solver.Solve(a, b, c);
            Assert.Single(roots);
            Assert.Equal(expected, roots[0], 7);
        }

        public static TheoryData<double, double, double, double, double> TwoRootCases => new TheoryData<double, double, double, double, double>
        {
            {1.0, -3.0, 2.0, 1.0, 2.0},
            {2.0, 5.0, -3.0, -3.0, 0.5},
            {1.0, 0.0, -4.0, -2.0, 2.0}
        };

        [Theory]
        [MemberData(nameof(TwoRootCases))]
        public void Solve_TwoRealRoots_ReturnsTwoRootsSorted(double a, double b, double c, double expected1, double expected2)
        {
            var roots = Solver.Solve(a, b, c);
            Assert.Equal(2, roots.Length);
            Assert.Equal(expected1, roots[0], 7);
            Assert.Equal(expected2, roots[1], 7);
        }

        [Fact]
        public void Solve_WithAEqualsZero_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Solver.Solve(0, 1, 1));
        }
    }
}

