/*
 *  Copyright 2013 Jonny Li (jonnyli1125)
 *
 *  Permission is hereby granted, free of charge, to any person obtaining a copy
 *  of this software and associated documentation files (the "Software"), to deal
 *  in the Software without restriction, including without limitation the rights
 *  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *  copies of the Software, and to permit persons to whom the Software is
 *  furnished to do so, subject to the following conditions:
 *
 *  The above copyright notice and this permission notice shall be included in
 *  all copies or substantial portions of the Software.
 *
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 *  THE SOFTWARE.
 *
 */

// http://en.wikipedia.org/wiki/Pythagorean_triple
// Using Euclid's Formula:
// a = m^2 - n^2
// b = 2mn
// c = m^2 + n^2
// This works for every integer m and n.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace PythagoreanTriples
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int maxcount, count = 0;
                do Console.Write("Number of Pythagorean triples to generate: ");
                while (!int.TryParse(Console.ReadLine(), out maxcount));
                Console.Write("Write to file? If yes, enter a file path, otherwise leave empty: ");
                var path = Console.ReadLine().Trim();
                var verbose = true;
                if (!String.IsNullOrEmpty(path))
                {
                    Console.Write("Verbose? (y/n): ");
                    verbose = Console.ReadLine()[0].ToString().ToLower().Trim() == "y";
                }
                var triples = new List<string>();
                for (BigInteger i = 1; ; i++)
                {
                    var br = false;
                    for (BigInteger j = 1; ; j++)
                    {
                        if (i == j) continue;
                        BigInteger i2 = i * i, j2 = j * j, a = BigInteger.Abs(i2 - j2), b = BigInteger.Abs(2 * i * j), c = BigInteger.Abs(i2 + j2);
                        var triple = a + "," + b + "," + c;
                        if (!triples.Contains(triple))
                        {
                            if (verbose) Console.WriteLine(triple);
                            triples.Add(triple);
                            count++;
                            if (count >= maxcount) { br = true; break; }
                        }
                    }
                    if (br) break;
                }
                Console.WriteLine("Done, generated " + count + " Pythagorean triples.");
                if (!String.IsNullOrEmpty(path)) File.WriteAllLines(path, triples);
            }
        }
    }
}
