﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace TemplateHashCode2020
{
    public class SolutionImprover
    {
        public SolutionInstance PreviousSolution { get; set; }
        public ProblemInstance Problem { get; set; }
        public HashSet<int> ChosenPizzas { get; set; }

        public SolutionImprover(ProblemInstance problem, SolutionInstance pizza)
        {
            PreviousSolution = pizza;
            Problem = problem;
            ChosenPizzas = new HashSet<int>();
        }

        public SolutionInstance ImproveAlgorithm()
        {
            var newSolution = PreviousSolution;
            //PreviousSolution.SignUpLibraryList.ForEach(l => ChosenPizzas.Add(l));
            //var previousScore = Scorer.ComputeScore(PreviousSolution, Problem);
            //Random random = new Random();

            //while (Scorer.ComputeScore(newSolution, Problem) > previousScore * 0.97)
            //{
            //    newSolution.SignUpLibraryList.RemoveAt(random.Next(newSolution.NumberOfLibraries));
            //}

            //var pOrderSlice = Problem.Books.Where(l => !ChosenPizzas.Contains(l.Id)).OrderBy(p => p.NumberOfSlices);
            //var sum = Scorer.ComputeScore(newSolution, Problem);
            //foreach (var p in pOrderSlice)
            //{
            //    if (sum + p.NumberOfSlices < Problem.MaximumSlices)
            //    {
            //        sum += p.NumberOfSlices;
            //        newSolution.SignUpLibraryList.Add(p.Id);
            //    }
            //}

            return newSolution;
        }
    }
}