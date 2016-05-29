using ChinskiListonosz.Core;
using ChinskiListonosz.Core.Algorithms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinskiListonosz
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() < 2)
            {
                Console.WriteLine("{0} input_file output_file", Environment.CommandLine);
                return;
            }

            var input_path = args[0];
            var output_path = args[1];

            if (!File.Exists(input_path))
            {
                Console.WriteLine("{0} does not exist.", input_path);
                return;
            }

            string[] input;

            try
            {
                input = File.ReadAllLines(input_path);
            }
            catch
            {
                Console.WriteLine("An error occured during reading the input file.");
                return;
            }

            var startingPoint = int.Parse(input[0]);
            Console.WriteLine("Starting Point = {0}", startingPoint);
            var edges = input
                        .Skip(1)
                        .Select(line => line
                                        .Split(',')
                                        .Select(i => int.Parse(i))
                                        .ToArray())
                        .Select(tab => new Edge(tab[0], tab[1], tab[2]))
                        .ToList();
            Console.WriteLine("{0} edges were loaded.", edges.Count);
            var graph = new Graph(edges);

            var answer = graph.Postman(startingPoint);
            foreach (var edge in answer.Edges)
            {
                Console.WriteLine(edge.ToString());
            }
            Console.WriteLine(answer.ToString());

            try
            {
                var cycleLengthLine = answer.Length.ToString();
                var cycleEdgesLine = string.Join(",",answer.Edges.Select(e => edges.IndexOf(e)));
                File.WriteAllLines(output_path, new string[] { cycleLengthLine, cycleEdgesLine });
            }
            catch
            {
                Console.WriteLine("An error occured during saving the results file.");
                return;
            }

        }
    }
}
