using System;
using System.Collections.Generic;

class NFACStyleComment
{
    // q0 is start, q4 means it worked
    enum State { q0, q1, q2, q3, q4 }

    public static bool IsAccepted(string input)
    {
        // we start at q0 obviously
        HashSet<State> currentStates = new HashSet<State> { State.q0 };

        foreach (char symbol in input)
        {
            // make a new list for the next states so we don't mess up the loop
            HashSet<State> nextStates = new HashSet<State>();

            foreach (State state in currentStates)
            {
                switch (state)
                {
                    case State.q0:
                        // just looking for the first slash to start
                        if (symbol == '/') nextStates.Add(State.q1);
                        break;

                    case State.q1:
                        // we got a slash, if the next one is a star, go to q2
                        // if it's a a or another slash, go back to the beginning
                        if (symbol == '*') nextStates.Add(State.q2);
                        else if (symbol == 'a') nextStates.Add(State.q0);
                        else if (symbol == '/') nextStates.Add(State.q0);
                        break;

                    case State.q2:
                        // we are inside the comment now. just ignore a and /
                        // if we see a star, go to q3 to check if it's closing
                        if (symbol == 'a' || symbol == '/') nextStates.Add(State.q2);
                        else if (symbol == '*') nextStates.Add(State.q3);
                        break;

                    case State.q3:
                        // ok we just saw a star. 
                        // if we see a slash next, go to q4
                        // if it's another star keep waiting, if it's a a go back to q2
                        if (symbol == '/') nextStates.Add(State.q4);
                        else if (symbol == '*') nextStates.Add(State.q3);
                        else if (symbol == 'a') nextStates.Add(State.q2);
                        break;

                    case State.q4:
                        // done! don't add anything here
                        // if there is more text after the comment closes it should just die
                        break;
                }
            }

            // swap the lists for the next letter
            currentStates = nextStates;

            // if list is empty means it failed early so just break out to save time
            if (currentStates.Count == 0) break;
        }

        // if q4 is in the list at the end then it passed
        return currentStates.Contains(State.q4);
    }

    static void Main()
    {
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("     C-Style Comment Checker");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("Type 'exit' to quit.\n");

        // endless loop for testing
        while (true)
        {
            Console.Write("Enter string to test: ");
            string input = Console.ReadLine();

            if (input == null) break;

            if (input.ToLower() == "exit")
            {
                Console.WriteLine("Bye!");
                break;
            }

            bool accepted = IsAccepted(input);

            // make it green if it works, red if it fails
            if (accepted)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Result: ACCEPTED\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Result: REJECTED\n");
            }

            Console.ResetColor();
        }
    }
}