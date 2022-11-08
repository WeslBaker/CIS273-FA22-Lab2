namespace Lab2;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(IsBalanced("{ ( < > ) }"));  // true
        IsBalanced("<> {(})");      // false
    }

    public static bool IsBalanced(string s)
    {
        Stack<char> stack = new Stack<char>();

        // iterate over all chars in string
        foreach(var c in s)
        {
            // if char is an open thing, push it
            if ( c=='<' || c=='(' || c == '{' || c == '[')
            {
                stack.Push(c);
            }

            // if char is a close thing,
            // compare it to top of stack;
            else if (c == '>' || c == ')' || c == '}' || c == ']')
            {
                char top;
                bool result = stack.TryPeek(out top);
                // handle result == false

                // if they match, pop()
                if (Matches(c, top) ) 
                {
                    stack.Pop();
                }
                // else, return false
                else
                {
                    return false;
                }
            }
            
        }

        // if stack is empty, return true
        if( stack.Count ==0)
        {
            return true;
        }

        return false;

    }

    private static bool Matches(char closing, char opening)
    {
        if((opening == '<' && closing == '>') || (opening == '(' && closing == ')') || (opening == '[' && closing == ']') || (opening == '{' && closing == '}'))
        {
            return true;
        }
        return false;
    }


    public static double? Evaluate(string s)
    {
        Stack<double?> stack = new Stack<double?>();
        double result = 0;

        // parse string into tokens
        string[] tokens = s.Split();

        // foreach token
        // if it's a number, push to stack
        foreach(string token in tokens)
        {
            if(token.Equals("+"))
            {
                stack.Push(stack.Pop() + stack.Pop());
            }
            else if(token.Equals("-"))
            {
                stack.Push((stack.Pop() - stack.Pop()) * -1);
            }
            else if(token.Equals("*"))
            {
                stack.Push(stack.Pop() * stack.Pop());
            }
            else if(token.Equals("/"))
            {
                double? divisor = stack.Pop();
                double? divided = stack.Pop();
                stack.Push(divided / divisor);
            }
            else
            {
                stack.Push(Convert.ToInt32(token));
            }
        }

        // if it's a math operator, pop twice;
        // compute result;
        // push result onto stack

        // return top of stack (if the stack has 1 element)
        if(stack.Count == 1)
        {
            return stack.Pop();
        }

        return null;
    }

}

