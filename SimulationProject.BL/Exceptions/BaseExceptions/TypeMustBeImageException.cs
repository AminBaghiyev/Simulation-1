namespace SimulationProject.BL.Exceptions;

public class TypeMustBeImageException : Exception
{
    public TypeMustBeImageException(string message) : base(message) { }

    public TypeMustBeImageException() : base("File type must be image!") { }
}
