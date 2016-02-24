using System;




public class Procedural_generator{
    public Procedural_generator(){}
	
	
	 public void Cellular_automata(int dimX, int dimY, int initialWallProb, int numberIterations){
		char[,] board_odd = new char[dimY,dimX];
		char[,] board_even = new char[dimY,dimX];
		Random random = new Random();
        string path = "C:/Users/pegartillo/Documents/Visual Studio 2015/Projects/procedural/procedural/procedural_example_cellular.txt";
		
		//generates the basical starting point for the algorithm 
		for (int i = 0; i < dimY; i++){
			for (int j = 0; j < dimX; j++){
				int randInt = random.Next(101);
				if(randInt <= initialWallProb)
					board_even[i,j] = '#';
				else
					board_even[i,j] = ' ';
			}
		}
		
		int counter;
		for(int k = 0; k < numberIterations; k++){
			for(int i = 0; i < dimY; i++){
				for(int j = 0; j < dimX; j++){
					if(k % 2 == 0){
						counter = CountCellAutomata(board_even, i, j, dimX, dimY);
						if(board_even[i,j] == '#'){
							if(counter >= 4){
								board_odd[i,j] = '#';
							}
							else{
								board_odd[i,j] = ' ';
							}
						}
						else if(board_even[i,j] == ' '){
							if(counter >= 5){
								board_odd[i,j] = '#';
							}
							else{
								board_odd[i,j] = ' ';
							}
						}
					}
					else if(k % 2 == 1){
						counter = CountCellAutomata(board_odd, i, j, dimX, dimY);
						if(board_odd[i,j] == '#'){
							if(counter >= 4){
								board_even[i,j] = '#';
							}
							else{
								board_even[i,j] = ' ';
							}
						}
						else if(board_odd[i,j] == ' '){
							if(counter >= 5){
								board_even[i,j] = '#';
							}
							else{
								board_even[i,j] = ' ';
							}
						}
					}
					
				}
			}
		}
        string text = "";
        string line;
		for (int i = 0; i < dimY; i++){
            line = "";
			for(int j = 0; j < dimX; j++){
                if (numberIterations % 2 == 0)
                    line += board_odd[i, j];
                else
                    line += board_even[i, j];
            }
            line += "\n";
            text += line;
        }
        System.IO.File.WriteAllText(path, text);
    }
	
	public int CountCellAutomata(char[,] board, int i, int j, int dimX, int dimY){
		int count;
		if(i == 0){
			if(j == 0){
				count = 5;
				if(board[i+1,j] == '#')
					count++;
				if(board[i+1,j+1] == '#')
					count++;
				if(board[i,j+1] == '#')
					count++;
			}
			else if(j == dimX-1){
				count = 5;
				if(board[i+1,j-1] == '#')
					count++;
				if(board[i+1,j] == '#')
					count++;
				if(board[i,j-1] == '#')
					count++;
			}
			else{
				count = 3;
				if(board[i+1,j] == '#')
					count++;
				if(board[i+1,j+1] == '#')
					count++;
				if(board[i,j+1] == '#')
					count++;
				if(board[i+1,j-1] == '#')
					count++;
                if (board[i,j - 1] == '#')
                    count++;
			}
		}
		else if(i == dimY-1){
			if(j == 0){
				count = 5;
				if(board[i-1,j] == '#')
					count++;
				if(board[i-1,j+1] == '#')
					count++;
				if(board[i,j+1] == '#')
					count++;
			}
			else if(j == dimX-1){
				count = 5;
				if(board[i-1,j] == '#')
					count++;
				if(board[i-1,j-1] == '#')
					count++;
				if(board[i,j-1] == '#')
					count++;
			}
			else{
				count = 3;
				if(board[i-1,j] == '#')
					count++;
				if(board[i-1,j+1] == '#')
					count++;
				if(board[i,j+1] == '#')
					count++;
				if(board[i-1,j-1] == '#')
					count++;
				if(board[i,j-1] == '#')
					count++;
			}
		}
		else{
			if(j == 0){
				count = 3;
				if(board[i-1,j] == '#')
					count++;
				if(board[i-1,j+1] == '#')
					count++;
				if(board[i,j+1] == '#')
					count++;
				if(board[i+1,j] == '#')
					count++;
				if(board[i+1,j+1] == '#')
					count++;
			}
			else if(j == dimX-1){
				count = 3;
				if(board[i-1,j-1] == '#')
					count++;
				if(board[i-1,j] == '#')
					count++;
				if(board[i,j-1] == '#')
					count++;
				if(board[i+1,j-1] == '#')
					count++;
				if(board[i+1,j] == '#')
					count++;
			}
			else{
				count = 0;
				if(board[i-1,j-1] == '#')
					count++;
				if(board[i-1,j] == '#')
					count++;
				if(board[i-1,j+1] == '#')
					count++;
				if(board[i,j-1] == '#')
					count++;
				if(board[i,j+1] == '#')
					count++;
				if(board[i+1,j-1] == '#')
					count++;
				if(board[i+1,j] == '#')
					count++;
				if(board[i+1,j+1] == '#')
					count++;
			}
		}
		return count;
	}

    //Usefull structures and constants for Eller's maze algorithm
    struct EllersCell
    {
        public int cell_Set;
        public bool down_wall;
        public bool right_wall;
    };
    const string maze_cell_floor = "___";
    const string maze_cell_NoFloor = "   ";
    const string NoWall = " ";
    const string wall = "|";

    public void EllersMaze(int dimX, int dimY, int VerticalwallProb, int horizontalWallProb){
        string path = "C:/Users/pegartillo/Documents/Visual Studio 2015/Projects/procedural/procedural/procedural_example_ellers.txt";
        EllersCell[] line = new EllersCell[dimX];
        string AllText;
        Random random = new Random();
        int randInt;
        int nextSet = 0;

        //System.IO.StreamWriter file = new System.IO.StreamWriter(path);

        //writes the first line that is always the same.
        AllText = NoWall;
        for (int j = 0; j < dimX; j++)
        {
            AllText += (maze_cell_floor + NoWall);
        }
        AllText += "\n";

        for (int i = 1; i < dimY + 1; i++){ // We traverse the for loop 2*dimY + 1 times because dimY + 1 of this are for creating the horizontal walls.
            AllText += wall;
            if (i == 1){ // if its the first line of the maze we initialize each EllersCell to a different 
                for(int j = 0; j < dimX; j++){
                    line[j].cell_Set = nextSet++;
                }
            }
            if(i > 0 && i < dimY){
                //first we remove right and down walls from the previous iteration
                for (int j = 0; j < dimX; j++)
                {
                    line[j].right_wall = false;
                    if (line[j].down_wall)
                    {
                        line[j].cell_Set = nextSet++;
                    }
                    line[j].down_wall = false;
                }
                line[dimX - 1].right_wall = true; // the last EllersCell does always have a wall to the right
                
                for (int j = 0; j < dimX-1; j++){
                    randInt = random.Next(101);
                    if (line[j].cell_Set == line[j + 1].cell_Set){
                        line[j].right_wall = true;
                    }
                    //decides if theres a wall between the actual EllersCell and the next one or otherwise makes em belong to the same set.
                    else {
                        if (randInt < VerticalwallProb)
                        {
                            line[j].right_wall = true;
                        }
                        else {
                            line[j + 1].cell_Set = line[j].cell_Set;
                        }
                    }
                }
                int k = 0;
                int zero = 0;
                int setCounter, numPosMoved;
                while(k < dimX)
                {
                    numPosMoved = setCounter = 0;
                    while ((k < dimX-1) && (line[k + 1].cell_Set == line[k].cell_Set))
                    {
                        k++;
                        numPosMoved++;
                        setCounter++;
                    }
                    while(zero <= numPosMoved)
                    {
                        if(setCounter > 0)
                        {
                            randInt = random.Next(101);
                            if (randInt < horizontalWallProb)
                            {
                                line[k - numPosMoved].down_wall = true;
                                setCounter--;
                            }
                            else
                            {
                                line[k - numPosMoved].down_wall = false;
                            }
                        }
                        else
                        {
                            line[k - numPosMoved].down_wall = false;
                        }
                        numPosMoved--;
                    }
                    k++;
                }
            }
            //the las line is different from the rest
            else{
                line[0].right_wall = false;
                line[0].down_wall = true;
                line[dimX-2].right_wall = false;
                line[dimX-2].down_wall = true;
                line[dimX-1].right_wall = true;
                line[dimX-1].down_wall = true;

                for (int j = 1; j < dimX-2; j++)
                {
                    if((line[j].cell_Set == line[j+1].cell_Set) &&(!line[j].down_wall || !line[j+1].down_wall))
                    {
                        line[j].right_wall = true;
                    }
                    else
                    {
                        line[j].right_wall = false;
                    }
                    line[j].down_wall = true;
                }
            }
            for (int j = 0; j < dimX; j++)
            {
                if (line[j].down_wall)
                {
                    AllText += maze_cell_floor;
                }
                else
                {
                    AllText += maze_cell_NoFloor;
                }
                if (line[j].right_wall)
                {
                    AllText += wall;
                }
                else
                {
                    AllText += NoWall;
                }
            }
            AllText += "\n";
        }
        System.IO.File.WriteAllText(path, AllText);
    }


    const int INITIALHEIGHT = 4;
    const int jump_reference = 3; 

    const char PLATTFORM = 'P';
    const char FLOOR = '.';
    const char EMPTY = ' ';

    public void proceduralPlattformer(int height, int length)
    {
        string path = "C:/Users/pegartillo/Documents/Visual Studio 2015/Projects/procedural/procedural/procedural_plattform.txt";
        char[,] map = new char[length,height];
        int lastHeight = INITIALHEIGHT;
        int fDiff;
        //FLOOR BEGINING
        for (int m = 0; m < height; m++)
        {
            if(m < INITIALHEIGHT && m >= 0)
                map[0, m] = FLOOR;
            else
                map[0, m] = EMPTY;
        }

        for (int i = 1; i < length; i++)
        {
            int j = height - 1;
            fDiff = chooseFloorDif();
            while (j > lastHeight + fDiff && j > 0)
            {
                map[i, j] = EMPTY;
                j--;
            }
            lastHeight = lastHeight + fDiff;
            if (j == 0)
            {
                map[i, 0] = FLOOR;
                lastHeight = 0;
            }
            else {
                while(j >= 0)
                {
                    map[i, j] = FLOOR;
                    j--;
                }
            }
            
        }
        //FLOOR END


        //PLATFORM BEGINING


        //PLATFORM END

        string text = "";
        string line;
        for (int i = 0; i < length; i++)
        {
            line = "";
            for (int j = 0; j < height; j++)
            {
                    line += map[i, j];
            }
            line += "\n";
            text += line;
        }
        System.IO.File.WriteAllText(path, text);
    }

    int chooseFloorDif()
    {

        int seed = Guid.NewGuid().GetHashCode();
        Random random = new Random(seed);
        int r = random.Next(1, 100);
        if(r > 0 && r < 11)
        {
            return 2;
        }
        else if (r > 10 && r < 31)
        {
            return 1;
        }
        else if (r > 30 && r < 71)
        {
            return 0;
        }
        else if (r > 70 && r < 91)
        {
            return -1;
        }
        else if (r > 90 && r < 101)
        {
            return -2;
        }
        return 0;
    }

    bool reachable(int lengthY, int heightX, char[,] map)
    {
        if(map[lengthY, heightX] != FLOOR)
        {

        }


        return true;
    }
}