class Day2 : BaseDay
{
    public override string Name => "";

    public override object Part1()
    {
        //set up counting variables for x and y
        int xpos = 0;
        int depth = 0;
        //go through lines, sequentially
        foreach(string line in inputLines)
        {
            string[] splitline = line.Split(' ');
            //apply if statements for up, down, forward to x and y
            switch(splitline[0])
            {
                case "forward": 
                    xpos += int.Parse(splitline[1]);
                    break;
                case "down":
                    depth += int.Parse(splitline[1]);
                    break;
                case "up":
                    depth -= int.Parse(splitline[1]);
                    break;
            }
            
        }
        
        //multiply x and y
        return xpos*depth;
    }
    public override object Part2()
    {
        //set up counting variables for x and y
        int xpos = 0;
        int depth = 0;
        int aim = 0;
        //go through lines, sequentially
        foreach(string line in inputLines)
        {
            string[] splitline = line.Split(' ');
            //apply if statements for up, down, forward to x and y
            switch(splitline[0])
            {
                case "forward": 
                    xpos += int.Parse(splitline[1]);
                    depth += (aim * int.Parse(splitline[1]));
                    break;
                case "down":
                    aim += int.Parse(splitline[1]);
                    break;
                case "up":
                    aim -= int.Parse(splitline[1]);
                    break;
            }
            
        }
        
        //multiply x and y
        return xpos*depth;
    }
}