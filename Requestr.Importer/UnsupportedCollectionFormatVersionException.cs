namespace Requestr.PostmanImporter
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
