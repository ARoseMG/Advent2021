using System;
using System.Collections.Generic;

partial class Day5 : BaseDay
{
    public override string Name => "";

    // public object Part1_firstTry()
    // {
    //     //create a set of points that have been counted, and another set that have been counted more than once
    //     HashSet<string[]> counted = new HashSet<string[]>();
    //     HashSet<string[]> countTwice = new HashSet<string[]>(); 

    //     //go through all points in a given line
    //     foreach(string line in inputLines)
    //     {
    //         string[] endpoints = line.Split(" -> ");
    //         string[] start = endpoints[0].Split(",");
    //         int[] end = Array.ConvertAll(endpoints[1].Split(","), int.Parse);
    //         //ask dad a more elegant way to get the start and end coords, preferably in format [[x1,y1],[x2,y2]]
            
    //         //only act on horiz and vertical lines
    //         //if vertical...
    //         if(start[0]==end[0])
    //         {
    //             //is start always less than end?
    //             for(int i = int.Parse(start[1]); i<=int.Parse(end[1]); i++)
    //             {
    //                 string[] point = {start[0], i.ToString()};
    //                 //if the point has already been counted, add it to the countTwice set, otherwise count it
    //                 if(counted.Contains(point))
    //                     countTwice.Add(point);
    //                 else
    //                     counted.Add(point);
    //             }
    //         }
    //         //if horizontal... (same logic as vertical, just looking at diff numbers)
    //         else if(start[1]==end[1])
    //         {
    //             for(int i = int.Parse(start[1]); i<int.Parse(end[1])+1; i++)
    //             {
    //                 string[] point = {i.ToString(), start[1]};
    //                 if(counted.Contains(point))
    //                     countTwice.Add(point);
    //                 counted.Add(point);
    //             }
    //         }
    //     }
        

    //     //count the items in second set and return the number
    //     return countTwice.Count;


    //     //issues: don't know how to create a list that looks a specific way without doing weird add-y things in order;
    //     //how to count a set?
    //     //is there a better way to organize the coordinate stuff?
    // }

    public override object Part1()
    {
        //create a set of points that have been counted, and another set that have been counted more than once
        HashSet<Point> counted = new HashSet<Point>();
        HashSet<Point> countTwice = new HashSet<Point>(); 

        //go through all points in a given line
        foreach(string line in inputLines)
        {
            string[] endpoints = line.Split(" -> ");
            Point start = new Point(endpoints[0]);
            Point end = new Point(endpoints[1]);           
            //only act on horiz and vertical lines
            //if vertical...
            if(start.x==end.x)
            {
                //is start always less than end?
                for(int i = Math.Min(start.y, end.y); i<=Math.Max(start.y, end.y); i++)
                {
                    Point point = new Point(start.x, i);
                    //if the point has already been counted, add it to the countTwice set, otherwise count it
                    if(counted.Contains(point))
                        countTwice.Add(point);
                    else
                        counted.Add(point);
                }
            }
            //if horizontal... (same logic as vertical, just looking at diff numbers)
            else if(start.y==end.y)
            {
                //is start always less than end?
                for(int i = Math.Min(start.x, end.x); i<=Math.Max(start.x, end.x); i++)
                {
                    Point point = new Point(i, start.y);
                    //if the point has already been counted, add it to the countTwice set, otherwise count it
                    if(counted.Contains(point))
                        countTwice.Add(point);
                    else
                        counted.Add(point);
                }
            }
        }
        

        //count the items in second set and return the number
        return countTwice.Count;


        //issues: don't know how to create a list that looks a specific way without doing weird add-y things in order;
        //how to count a set?
        //is there a better way to organize the coordinate stuff?
    }
    public override object Part2()
    {
        HashSet<Point> counted = new HashSet<Point>();
        HashSet<Point> countTwice = new HashSet<Point>(); 

        //go through all points in a given line
        foreach(string line in inputLines)
        {
            string[] endpoints = line.Split(" -> ");
            Point start = new Point(endpoints[0]);
            Point end = new Point(endpoints[1]);
            var heatvents = PointsBetween(start, end);
            foreach(Point vent in heatvents)
            {
                if(counted.Contains(vent))
                    countTwice.Add(vent);
                else
                    counted.Add(vent);
            }
        }

        //count the items in second set and return the number
        return countTwice.Count;

    

    }


    Point[] PointsBetween(Point a, Point b)
    {
        int size = (a-b).LargerComponent() + 1;
        Point[] line = new Point[size];
        Point step = (b - a).Unit();
        for(int i = 0; i < size; i++)
        {
            line[i] = a + i * step;
        }
        return line;

    }
}