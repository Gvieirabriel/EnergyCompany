namespace EnergyCompany.Domain.Exceptions
{
    [Serializable]
    public class InvalidValueException : Exception
    {
        public InvalidValueException() { }

        public InvalidValueException(string message)
            : base(message) { }
    }
}
