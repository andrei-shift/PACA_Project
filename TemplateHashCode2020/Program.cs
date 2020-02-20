using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateHashCode2020
{
	class Program
	{
		private static int counter = 0;
		static void Main(string[] args)
		{
			var inputPaths = new List<string>
			{
				@"C:\Git\input_hashcode\b_read_on.txt",
				@"C:\Git\input_hashcode\a_example.txt",
				@"C:\Git\input_hashcode\b_read_on.txt",
				@"C:\Git\input_hashcode\c_incunabula.txt",
			};

			var path = inputPaths[2];

			var problemInstance = IOHelper.ReadInputFile(path);
			var greedyAlgo = new GreedyAlgorithm(problemInstance);
			var bestSolution = greedyAlgo.Optimize();
			//var bestSolution = IOHelper.ReadPreviousSolution(@"path");
			var bestScore = Scorer.ComputeScore(bestSolution, problemInstance);

			Console.Out.WriteLine($"the first score for the given input is {bestScore}");
			var outputPath = Path.Combine(Path.GetDirectoryName(path),
				Path.GetFileNameWithoutExtension(path) + "Result.csv");
			IOHelper.WriteOutputResult(bestSolution, outputPath);

			while (ContinueSolutionImprovemnt())
			{
				var improvementAlgorithm = new SolutionImprover(problemInstance, bestSolution);
				var newSolution = improvementAlgorithm.ImproveAlgorithm();
				var newScore = Scorer.ComputeScore(newSolution, problemInstance);
				if (newScore > bestScore)
				{
					bestSolution = newSolution;
					bestScore = newScore;
					Console.Out.WriteLine($"the new best score for the given input is {bestScore}");
					IOHelper.WriteOutputResult(bestSolution, outputPath);
				}
			}

			Console.Out.WriteLine($"Computation finshed, press enter for exit");
			Console.In.Read();
		}

		static bool ContinueSolutionImprovemnt()
		{
			counter++;
			if (counter < 1000) return true;
			return false;
		}
	}
}
