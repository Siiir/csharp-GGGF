using System.Numerics;
using System;

public static class Fibonacci
{
    /// <summary>
    /// Multiplies two 2x2 matrices represented as arrays.
    /// </summary>
    /// <param name="matrix1">The first matrix.</param>
    /// <param name="matrix2">The second matrix.</param>
    /// <returns>The product of the two matrices.</returns>
    private static BigInteger[] MultiplyMatrices(BigInteger[] matrix1, BigInteger[] matrix2)
    {
        BigInteger[] result = new BigInteger[4];

        result[0] = matrix1[0] * matrix2[0] + matrix1[1] * matrix2[2];
        result[1] = matrix1[0] * matrix2[1] + matrix1[1] * matrix2[3];
        result[2] = matrix1[2] * matrix2[0] + matrix1[3] * matrix2[2];
        result[3] = matrix1[2] * matrix2[1] + matrix1[3] * matrix2[3];

        return result;
    }

    /// <summary>
    ///   Raises a 2x2 matrix to the power of n.
    /// </summary>
    /// <param name="matrix">
    ///   The matrix to be raised to a power.
    ///   This object will be in valid yet undefined state after invoking the function.
    /// </param>
    /// <param name="exponent">The exponent.</param>
    /// <returns>The matrix raised to the power of n.</returns>
    private static BigInteger[] PowerMatrix(BigInteger[] matrix, uint exponent)
    {
        // Spoils `matrix` unintentionally
        BigInteger[] result = new BigInteger[4] { 1, 0, 0, 1 };

        while (true)
        {
            if ((exponent & 1) == 1)
            {
                result = MultiplyMatrices(result, matrix);
            }

            exponent >>= 1;

            if (exponent == 0)
            {
                break;
            }

            matrix = MultiplyMatrices(matrix, matrix);
        }

        return result;
    }

    /// <summary>
    /// Computes the nth Fibonacci number.
    /// </summary>
    /// <param name="n">The index of the Fibonacci number to compute.</param>
    /// <returns>The nth Fibonacci number.</returns>
    public static BigInteger ComputeFibonacci(int n)
    {
        if (n < 0)
        {
            return (n % 2 == 0) ? -ComputeFibonacci(-n) : ComputeFibonacci(-n);
        }

        if (n == 0)
        {
            return BigInteger.Zero;
        }

        BigInteger[] matrix = new BigInteger[] { 1, 1, 1, 0 };
        matrix = PowerMatrix(matrix, (uint)n - 1);

        return matrix[0];
    }
}

internal class Program
{
    static internal void Main(string[] args)
    {
        if (args.Length != 1 || !int.TryParse(args[0], out int n))
        {
            Console.WriteLine("Usage: dotnet run <Fibonacci index>");
            Console.WriteLine("The Fibonacci index can be a positive or negative integer.");
            Console.WriteLine("Positive indices return the corresponding Fibonacci number.");
            Console.WriteLine("Negative indices return the corresponding negafibonacci number.");
            Console.WriteLine("\nNotes:");
            Console.WriteLine("1. Negative Indexing: Fibonacci numbers for negative indices follow the pattern:");
            Console.WriteLine("   F(-n) = (-1)^(n+1) * F(n)");
            Console.WriteLine("   This means F(-1) = 1, F(-2) = -1, F(-3) = 2, etc.");
            Console.WriteLine("2. Large Numbers: This implementation uses BigInteger to handle very large Fibonacci numbers.");
            Console.WriteLine("   For example, Fibonacci(1_000_000) can be computed without overflow issues.");
            Console.WriteLine("3. Performance: Matrix exponentiation is used for efficient computation, making it feasible to calculate");
            Console.WriteLine("   Fibonacci numbers for very large indices quickly.");
            return;
        }

        try
        {
            BigInteger result = Fibonacci.ComputeFibonacci(n);
            Console.WriteLine($"Fibonacci({n}) = {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error computing Fibonacci({n}): {ex.Message}");
        }
    }
}
