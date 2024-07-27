namespace MediatorCQRS.Helpers.Guards
{
    public class Guard : IGuard
    {
        public static Guard Against { get; } = new Guard();
        private Guard() { }
    }
}