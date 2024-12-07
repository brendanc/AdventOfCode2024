using System.Text.RegularExpressions;

namespace AdventOfCode.Day7;

public class Equation
{
    private string[] possibleOperators;
    public Equation(string input, string[] operators)
    {
        var parts = input.Split(':');
        Result = long.Parse(parts[0]);
        Values = parts[1].Trim().Split(' ').Select(int.Parse).ToList();
        this.possibleOperators = operators;
    }
    
    public long Result { get; set; }
    public List<int> Values { get; set; }

    public bool EquationIsValid()
    {
        var possibleEquations = GenerateEquations(this.Values,this.possibleOperators);
        // now we have a list of equations "eg '10+19' , '10*19', etc
        // let's see if any eval to the correct result
        foreach (var possibleEquation in possibleEquations)
        {
            if (EvaluateLToR(possibleEquation) == Result)
            {
                return true;
            }
        }

        return false;
    }

    public long EvaluateLToR(string equation)
    {
        long total = 0;
        var pattern = @"\+|\*|\&";
        var matches = new Regex(pattern).Matches(equation);
        var operators = matches.Select(m => m.ToString()).ToList();
        operators.Insert(0,"+");
        for (var i = 0; i < Values.Count; i++)
        {
            if (operators[i] == "&")
            {
                total = long.Parse(total.ToString() + Values[i].ToString());
            }
            if (operators[i] == "+")
            {
                total += Values[i];
            }
            if(operators[i] == "*")
            {
                total *= Values[i];
            }
        }
        
        return total;
    }

    public List<string> GenerateEquations(List<int> values, string[] operators)
    {
        var equations = new List<string>();

        // Base case: If there's only one value, return it as a string
        if (values.Count == 1)
        {
            equations.Add(values[0].ToString());
            return equations;
        }

        // Recursively generate equations for each operator and value combination
        for (int i = 0; i < operators.Length; i++)
        {
            var operatorSymbol = operators[i];
            var subValues = values.GetRange(1, values.Count - 1);
            var subEquations = GenerateEquations(subValues, operators);

            foreach (var subEquation in subEquations)
            {
                equations.Add($"{values[0]}{operatorSymbol}{subEquation}");
            }
        }

        return equations;
    }
 
}