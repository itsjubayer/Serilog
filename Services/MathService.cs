namespace Serilog.Services
{
    public class MathService : IMathService
    {
        private readonly ILogger<MathService> _logger;

        public MathService(ILogger<MathService> logger)
        {
            _logger = logger;
        }

        public decimal Divide(decimal a, decimal b)
        {
            _logger.LogInformation("Parameter 1: " + a);
            _logger.LogInformation("Parameter 2: " + b);

            decimal result = 0;

            try
            {
                result = a / b;
            }
            catch (DivideByZeroException ex)
            {
                _logger.LogWarning(ex, "You cannot divide by zero.");
                throw ex;
            }

            return result;
        }
    }
}
