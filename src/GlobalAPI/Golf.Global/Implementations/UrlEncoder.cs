using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Golf.Global.Implementations
{
    public class UrlEncoder
    {
        private StringBuilder _url;

        public UrlEncoder()
        {
            _url = new StringBuilder();
        }

        public UrlEncoder(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException(nameof(url));
            }

            if (url.EndsWith("/"))
                url.TrimEnd('/');

            _url = new StringBuilder(url);
        }

        public UrlEncoder AddPath(string param)
        {
            if (string.IsNullOrWhiteSpace(param))
            {
                throw new ArgumentNullException(nameof(param));
            }

            if (!_url.EndsWith("/"))
                _url.Append("/");

            _url.Append($"{param}");

            return this;
        }

        public UrlEncoder AddPath(int param)
        {
            return AddPath(param.ToString());
        }

        public UrlEncoder AddToQueryString(string param, string value)
        {
            if (string.IsNullOrWhiteSpace(param))
            {
                throw new ArgumentNullException(nameof(param));
            }
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (!_url.EndsWith("&") && !_url.EndsWith("?"))
            {
                _url.Append("?");
            }

            _url.Append($"{param}=");
            _url.Append(HttpUtility.UrlEncode(($"{value}&")));

            return this;
        }

        public UrlEncoder AddToQueryString(List<KeyValuePair<string, string>> urlArgs)
        {
            if (urlArgs != null)
            {
                foreach (var arg in urlArgs)
                    AddToQueryString(arg.Key, arg.Value);
            }

            return this;
        }

        public override string ToString()
        {
            return _url.ToString().TrimEnd('?', '&');
        }
    }
}
