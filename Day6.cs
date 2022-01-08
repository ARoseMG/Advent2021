using System;
using System.Collections.Generic;

class Day6 : BaseDay
{
    public override string Name => "";

    public override object Part1()
    {
        //split by commas
        //create a fish class?
        //create a for loop that runs for 80 days
        //each day, increment all fish down by 1 (in a way that loops back around)
        //each day, check for any zeroes, add as many new fish as there are zeroes (starting val 8)

        List<int> school = new List<int>();
        school.AddRange(Array.ConvertAll(inputLines[0].Split(","), int.Parse));

        for(int i=0; i<80; i++)
        {
            List<int> babies = new List<int>();
            for(int index=0; index<school.Count; index++)
            {
                if(school[index]==0)
                {
                    babies.Add(8);
                    school[index] = 6;
                }
                else
                    school[index] --;
            }
            school.AddRange(babies);
        }

        return school.Count;
    }


    public override object Part2()
    {
        long[] fishtionarray = new long[9];
        List<long> school = new List<long>();
        school.AddRange(Array.ConvertAll(inputLines[0].Split(","), long.Parse));
        foreach(long fish in school)
        {
            fishtionarray[fish] ++;
        }
        long allbabies = 0;
        for(long day=0; day<256; day++)
        {
            long babies = fishtionarray[0];
            allbabies += babies;
            for(long index=0; index<8; index++)
            {
                fishtionarray[index] = fishtionarray[index+1];
            }
            fishtionarray[8]=babies;
            fishtionarray[6] += babies;
        }

        return school.Count + allbabies;
    }

}