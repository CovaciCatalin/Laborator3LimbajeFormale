using System;
using System.Collections.Generic;

class Automaton
{
    private HashSet<string> states = new HashSet<string> { "q0", "q1", "q2", "q3" };
    private HashSet<char> alphabet = new HashSet<char> { 'a', 'b', 'c', 'd' };
    private string initialState = "q0";
    private HashSet<string> finalStates = new HashSet<string> { "q3" };
    private string currentState;

    public Automaton()
    {
        currentState = initialState;
    }

    public void Transition(char symbol)
    {
        if (currentState == "q0")
        {
            if (symbol == 'a')
                currentState = "q1";
            else if (symbol == 'b' || symbol == 'c' || symbol == 'd')
                currentState = "q0";
        }
        else if (currentState == "q1")
        {
            if (symbol == 'a')
                currentState = "q1";
            else if (symbol == 'b')
                currentState = "q2";
            else if (symbol == 'c' || symbol == 'd')
                currentState = "q1";
        }
        else if (currentState == "q2")
        {
            currentState = "q2"; 
        }
        else if (currentState == "q3")
        {
            currentState = "q3"; 
        }
    }

    public bool ProcessInput(string input)
    {
        foreach (char symbol in input)
        {
            if (!alphabet.Contains(symbol))
            {
                Console.WriteLine($"Input contains invalid symbol '{symbol}'.");
                return false;
            }
            Transition(symbol);
        }
        return finalStates.Contains(currentState);
    }
}

class Program
{
    static void Main()
    {
        Automaton automaton = new Automaton();
        string[] wordsToCheck = { "aabbcc", "aaa", "bbbaac" };

        foreach (string word in wordsToCheck)
        {
            bool isInLanguage = automaton.ProcessInput(word);
            Console.WriteLine($"{word} este în limbajul L: {isInLanguage}");
        }
    }
}
