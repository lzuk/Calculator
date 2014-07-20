namespace Calculator.RPN
{
    /// <summary>
    /// RPN Math Service. Provide function headers to handle RPN infix -> postfix tranformation and calculate value from RPN.
    /// </summary>
    public interface IRpnService
    {
        /// <summary>
        /// Create RPN (Reverse Polish Notation) postfix expression from infix notation.
        /// </summary>
        /// <param name="expression">Expression with infix notation.</param>
        /// <returns>Expression with postfix notation.</returns>
        string CreateRpn(string expression);

        /// <summary>
        /// Calculate value from RPN postfix expression.
        /// </summary>
        /// <param name="rpn">RPN postfix expression.</param>
        /// <returns>Expected value.</returns>
        double CalculateRpn(string rpn);

        /// <summary>
        /// Calculate value from infix notation expression.
        /// </summary>
        /// <param name="expression">Infix expression.</param>
        /// <returns>Extected value</returns>
        double CalucalteValue(string expression);
    }
}
