namespace Calculator.RPN
{
    public interface IRpn
    {
        string CreateRpn(string expression);
        double CalculateRpn(string rpn);
    }
}
