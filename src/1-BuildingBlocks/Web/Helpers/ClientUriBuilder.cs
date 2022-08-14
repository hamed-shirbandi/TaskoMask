using System.Collections.Specialized;
using System.Web;

namespace TaskoMask.BuildingBlocks.Web.Helpers
{
    public class ClientUriBuilder
    {
        private readonly NameValueCollection _collection;
        private readonly UriBuilder _builder;

        public ClientUriBuilder(Uri uri)
        {
            _builder = new UriBuilder(uri);
            _collection = HttpUtility.ParseQueryString(string.Empty);
        }

        public ClientUriBuilder AddParameter(string key, string value)
        {
            _collection.Add(key, value);
            return this;
        }

        public Uri Uri
        {
            get
            {
                _builder.Query = _collection.ToString();
                return _builder.Uri;
            }
        }
    }
}
