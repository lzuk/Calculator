﻿namespace Calculator.RPN
{
    interface IRpn
    {
        string CreateRpn(string expression);
        double CalculateRpn(string rpn);
    }
}