namespace Requestr.PostmanImporter.Exceptions
{
    public class UnsupportedCollectionFormatVersionException : Exception
    {
        public UnsupportedCollectionFormatVersionException()
        {
        }

        public UnsupportedCollectionFormatVersionException(string message)
            : base(message)
        {
        }

        public UnsupportedCollectionFormatVersionException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
