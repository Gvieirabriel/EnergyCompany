namespace EnergyCompany.src.Domain.Exceptions
{
    [Serializable]
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException() { }

        public AlreadyExistsException(string message)
            : base(message) { }
    }
}
