using System.Collections.Generic;

class Day4 : BaseDay
{
    public override string Name => "";

    public override object Part1()
    {
        //make a bunch of boards
        List<Bingo> boards = new List<Bingo>();
        for(int startline = 2; startline<inputLines.Count; startline += 6)
            boards.Add(new Bingo(inputLines, startline));
        //go through pull list, run marknum for each board per #
        string[] pullnums = inputLines[0].Split(",");
        foreach(string str in pullnums)
        {
            int num = int.Parse(str);
            foreach(Bingo board in boards)
            {
                //as soon as there's a bingo, score the board
                if(board.markNum(num))
                    return board.score(num);
            }
        }
        return "something went wrong whoopsie";
        
    }

        public override object Part2()
    {
        //make a bunch of boards
        List<Bingo> boards = new List<Bingo>();
        for(int startline = 2; startline<inputLines.Count; startline += 6)
            boards.Add(new Bingo(inputLines, startline));
        //go through pull list, run marknum for each board per #
        string[] pullnums = inputLines[0].Split(",");
        foreach(string str in pullnums)
        {
            int num = int.Parse(str);
            for(int i = 0; i<boards.Count; i++)
            {
                Bingo board = boards[i];
                //as soon as there's a bingo, score the board
                if(board.markNum(num))
                {
                    if(boards.Count > 1)
                        boards.RemoveAt(i--);
                    else
                        return board.score(num);
                }
            }
        }
        return "something went wrong whoopsie";
        
    }


    class Bingo
    {
        int [,] board = new int[5,5];
        HashSet<int> pulled = new HashSet<int>();
        //constructor
        public Bingo(List<string> rawLines, int firstline)
        {
            for (int y = 0; y < 5; y++)
            {
                string[] row  = rawLines[firstline+y].Split(' ',System.StringSplitOptions.RemoveEmptyEntries);
                for (int x = 0; x < 5; x++)
                {
                    board[x,y] = int.Parse(row[x]);

                }
            }
                
        }
        //numberpuller
        public bool markNum(int num)
        {
            pulled.Add(num);
            return hasBingo();
        }
        //bingofinder
        bool hasBingo()
        {
            for (int y = 0; y < 5; y++)
            {
                int rowCount = 0;
                int colCount = 0;
                for (int x = 0; x < 5; x++)
                {
                    if(pulled.Contains(board[x,y]))
                        rowCount++;                    
                    if(pulled.Contains(board[y,x]))
                        colCount++;                    
                }
                if(rowCount == 5 || colCount == 5)
                    return true;
            }
            return false;
        }
        //score
        public int score(int lastCall)
        {
            int sumUnmarked = 0;
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if(!pulled.Contains(board[x,y]))
                        sumUnmarked += board[x,y];                  
                } 
            }
            return sumUnmarked*lastCall;
        }
    }

}