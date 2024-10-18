using System; 

namespace _2d_arrays 
{ 
    internal class Program 
    { 
        public static void print_tac_toe(char[,] arr, int rows, int columns) { 
            Console.WriteLine($"    1 2 3 ");
            for (int i = 0; i < rows; i++) { 
                Console.Write($"{i + 1} | "); 
                for (int j = 0; j < columns; j++) 
                { 
                    Console.Write(arr[i, j] + " "); 
                } 
                Console.WriteLine("|"); 
            }
        } 

        public static bool check_if_won(char[,] arr, int size) { 
            // Check for full rows 
            for (int i = 0; i < size; i++) { 
                if (arr[i, 0] == ' ') { 
                    continue; 
                }
                // Rows
                if (arr[i, 0] == arr[i, 1] && arr[i, 0] == arr[i, 2]) { 
                    Console.WriteLine($"{arr[i,0]} has won!!"); 
                    return true; 
                }
                // Columns
                if (arr[0, i] == arr[1, i] && arr[0, i] == arr[2, i]) { 
                    Console.WriteLine($"{arr[0, i]} has won!"); 
                    return true; 
                }
            }

            // Check for diagonal
            if (arr[1, 1] != ' ') {
                if ((arr[0, 0] == arr[1, 1] && arr[0, 0] == arr[2, 2]) || 
                    (arr[0, 2] == arr[1, 1] && arr[0, 2] == arr[2, 0])
                ) {
                    Console.WriteLine($"{arr[1, 1]} has won!!!"); 
                    return true;
                }
            }
            return false; 
        } 

        static void Main(string[] args) 
        { 
            char[,] array = new char[3, 3] { 
                { ' ', ' ', ' '}, 
                { ' ', ' ', ' '}, 
                { ' ', ' ', ' '} 
            }; 
            int row, column;
            char current_player = 'x';
            int counter = 0;

            while (true) 
            {
                Console.WriteLine($"Current player is {current_player}");

                // Take 1 from both row and column to make it indexable.
                Console.WriteLine("Enter a row");
                row = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.WriteLine("Enter a column");
                column = Convert.ToInt32(Console.ReadLine()) - 1;
                if (column > 2 || row > 2) {
                    Console.WriteLine("Index out of range.");
                    continue;
                }

                // Check that the position isn't already occupied. 
                if (array[row, column] != 'x' && array[row, column] != '0') { 
                    array[row, column] = current_player; 
                } else { 
                    Console.WriteLine("Space already occupied."); 
                    continue;
                }

                print_tac_toe(array, 3, 3);
                if (check_if_won(array, 3)) {
                    break;
                }

                if (++counter == 9) {
                    Console.WriteLine("No space left");
                    break;
                }

                // Switch to next player 
                if (current_player == 'x') { 
                    current_player = '0'; 
                } else {
                    current_player = 'x'; 
                }
            } 
        } 
    } 
} 