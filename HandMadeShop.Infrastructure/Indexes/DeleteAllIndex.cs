using Raven.Client.Documents.Session;

namespace HandMadeShop.Infrastructure.Indexes
{
    public class DeleteAllIndex
    {
        private readonly IAsyncDocumentSession _session;

        public DeleteAllIndex(IAsyncDocumentSession session)
        {
            _session = session;
        }

        public void DeleteAllDocuments<T>()
        {
        }
    }
}