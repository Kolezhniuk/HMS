using Raven.Client.Documents.Session;

namespace HandMadeShop.Infrastrucutre.Indexes
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