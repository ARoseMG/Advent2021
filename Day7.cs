using System;
using System.Collections.Generic;

class Day7 : BaseDay
{
    public override string Name => "";

    public override object Part1()
    {
        //minimum fuel could be: median or mean?
        //idea 1: crabs in dictionary
        //idea 2: sort crabs
        List<int> crabs = new List<int>();
        crabs.AddRange(Array.ConvertAll(inputLines[0].Split(","), int.Parse));
        crabs.Sort();
        int halfcrabs = crabs.Count/2;
        int median = crabs[halfcrabs];
        Console.WriteLine(median);

        //calculate fuel for median, m+1, m-1
        //compare; if middle isn't lowest, choose one step past lowest and repeat
        int best = calculateFuel(crabs, median);
        while(true)
        {
            int right = calculateFuel(crabs,median+1);
            if(right<best)
            {
                best = right;
                median ++;
                Console.WriteLine($"{best}, {median}");
            }
            else
                break;
            
        }

        while(true)
        {
            int left = calculateFuel(crabs,median-1);
            if(left<best)
            {
                best = left;
                median --;
                Console.WriteLine($"{best}, {median}");

            }
            else
                break;
            
        }

        return best;

    }



    public override object Part2()
    {
        //minimum fuel could be: median or mean?
        //idea 1: crabs in dictionary
        //idea 2: sort crabs
        List<int> crabs = new List<int>();
        crabs.AddRange(Array.ConvertAll(inputLines[0].Split(","), int.Parse));
        crabs.Sort();
        int halfcrabs = crabs.Count/2;
        int mean = calculateFuel(crabs,0)/crabs.Count;
        Console.WriteLine(mean);

        //calculate fuel for median, m+1, m-1
        //compare; if middle isn't lowest, choose one step past lowest and repeat
        int best = calculateFuel2(crabs, mean);
        while(true)
        {
            int right = calculateFuel2(crabs,mean+1);
            if(right<best)
            {
                best = right;
                mean ++;
                Console.WriteLine($"{best}, {mean}");
            }
            else
                break;
            
        }

        while(true)
        {
            int left = calculateFuel2(crabs,mean-1);
            if(left<best)
            {
                best = left;
                mean --;
                Console.WriteLine($"{best}, {mean}");

            }
            else
                break;
            
        }

        return best;

    }
    int calculateFuel(List<int> crabs, int median)
    {
        int fueltotal = 0;
        foreach(int crab in crabs)
        {
            fueltotal += (Math.Abs(crab-median));
        }
        return fueltotal;
    }

    int calculateFuel2(List<int> crabs, int mean)
    {
        int fueltotal = 0;
        foreach(int crab in crabs)
        {

            int fuel = ((Math.Abs(crab-mean)+1)*Math.Abs(crab-mean))/2;
            //Console.WriteLine($"from {crab} to {mean} costs {fuel}");
            fueltotal += fuel;
        }
        return fueltotal;
    }
}