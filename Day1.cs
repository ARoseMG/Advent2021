class Day1 : BaseDay
{
    public override string Name => "";

    public override object Part1()
    {
        int count = 0;
        // compare each line to previous, determine inc or dec, count inc
        int prevDepth = int.Parse(inputLines[0]);
        foreach(string line in inputLines)
        {
            int depth = int.Parse(line);
            int diff = depth-prevDepth;
            if(diff>0)
            {
                count += 1;
            }
            prevDepth = depth;
        }
        // return count of inc
        return count;
    }

    public override object Part2()
    {
        int count = 0;
        // compare each line to previous, determine inc or dec, count inc
        int prevDepth1 = int.Parse(inputLines[0]);
        int prevDepth2 = int.Parse(inputLines[1]);
        int prevSum = int.MaxValue;

        for(int i = 2;i<inputLines.Count;i+=1)
        {
            int depth = int.Parse(inputLines[i]);
            int sum = depth + prevDepth1 + prevDepth2;
            if(sum>prevSum)
            {
                count += 1;
            }
            prevDepth1 = prevDepth2;
            prevDepth2 = depth;
            prevSum = sum;
        }
        // return count of inc
        return count;
    }
}