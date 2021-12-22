using System;

class Day3 : BaseDay
{
    public override string Name => "";

    public override object Part1()
    {
        //create strings for gamma and epsilon values
        string gamma = "";
        string epsilon = "";
        //nested for-loops - go through first bit on each line, then second, etc.
        for(int bit=0;bit<inputLines[0].Length;bit++)
        {
            //create var for total # of 1s in this bit position
            int bitcount = 0;
            int halflines = inputLines.Count/2;
            foreach(string line in inputLines)
            {
                if(line[bit] == '1')
                    bitcount ++;
            }
            //use # of lines to determine which val was used more, input bits into gamma + epsilon
            if(bitcount<halflines)
            {
                gamma += "0";
                epsilon += "1";
            }
            if(bitcount > halflines)
            {
                gamma += "1";
                epsilon += "0";
            }
        }
        // translate gamma + epsilon from binary
        int gammaInt = Convert.ToInt32(gamma, 2);
        int epsilonInt = Convert.ToInt32(epsilon, 2);

        // return gamma * epsilon
        return gammaInt*epsilonInt;
    }
    public override object Part2()
    {
        //create strings for gamma and epsilon values
        string oxygen = "";
        string co2 = "";
        //nested for-loops - go through first bit on each line, then second, etc.
        double halfOx = inputLines.Count/2.0;
        double halfCo = inputLines.Count/2.0;
        for(int bit=0;bit<inputLines[0].Length;bit++)
        {
            //create var for total # of 1s in this bit position
            int oxCount = 0;
            int coCount = 0;
            foreach(string line in inputLines)
            {
                if(line.StartsWith(oxygen))
                {
                    if(line[bit] == '1')
                        oxCount ++;
                }
                if(line.StartsWith(co2))
                {
                    if(line[bit] == '1')
                        coCount ++;
                }
                
            }
            //use # of lines to determine which val was used more, input bits into gamma + epsilon
            if(halfOx>=1)
            {
                if(oxCount>=halfOx)
                {
                    oxygen += "1";
                    halfOx = oxCount/2.0;
                }
                else
                {
                    oxygen += "0";
                    halfOx = (halfOx*2-oxCount)/2.0;
                }
            }
            else
                oxygen += oxCount;

            if(halfCo>=1 && coCount<halfCo)
            {
                co2 += "1";
                halfCo = coCount/2.0;
            }
            else if(halfCo>=1)
            {
                co2 += "0";
                halfCo = (halfCo*2-coCount)/2.0;
            }
            else
                co2+= coCount;


        }
        // translate gamma + epsilon from binary
        int oxygenInt = Convert.ToInt32(oxygen, 2);
        int co2Int = Convert.ToInt32(co2, 2);

        // return gamma * epsilon
        return oxygenInt*co2Int;
    }

}