namespace Calculator.RPN
{
    public interface IRpnService
    {
        string CreateRpn(string expression);
        double CalculateRpn(string rpn);
        double CalucalteValue(string expression);
    }
}
