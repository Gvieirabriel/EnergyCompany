namespace EnergyCompany.src.Domain.Exceptions
{
    [Serializable]
    public class ModelNotFoundException : Exception
    {
        public ModelNotFoundException() { }

        public ModelNotFoundException(string message)
            : base(message) { }
    }
}
