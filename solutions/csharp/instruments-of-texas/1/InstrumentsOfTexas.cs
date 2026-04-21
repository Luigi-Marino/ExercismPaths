public class CalculationException : Exception
{
    private string _message;
    private Exception _inner;
    
    public CalculationException(int operand1, int operand2, string message, Exception inner)
    // TODO: complete the definition of the constructor
    {
        _message = message;
        _inner = inner;
    }

    public int Operand1 { get; }
    public int Operand2 { get; }
}

public class CalculatorTestHarness
{
    private Calculator calculator;

    public CalculatorTestHarness(Calculator calculator)
    {
        this.calculator = calculator;
    }

    public string TestMultiplication(int x, int y)
    {
        try
        {
            calculator.Multiply(x, y);
            return "Multiply succeeded";
        }
        
        catch (Exception ex) when (x < 0 && y < 0)
        {
            return "Multiply failed for negative operands. " + ex.Message;
        }
        
        catch (Exception ex)
        {
            return "Multiply failed for mixed or positive operands. " + ex.Message;
        }
    }

    public void Multiply(int x, int y)
    {
        try
        {
            calculator.Multiply(x,y);
        }
        catch (Exception ex)
        {
            throw new CalculationException(x, y, ex.Message, ex);
        }
    }
}


// Please do not modify the code below.
// If there is an overflow in the multiplication operation
// then a System.OverflowException is thrown.
public class Calculator
{
    public int Multiply(int x, int y)
    {
        checked
        {
            return x * y;
        }
    }
}
