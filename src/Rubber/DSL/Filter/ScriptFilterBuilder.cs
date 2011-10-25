using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Rubber.DSL.Filter
{
    public class ScriptFilterBuilder : IFilterBuilder
    {
        private readonly string _script;
        private bool _cache;
        private string _cacheKey;
        private string _filterName;
        private string _lang;
        private Dictionary<string, object> _params;

        public ScriptFilterBuilder(string script)
        {
            _script = script;
        }

        public ScriptFilterBuilder AddParam(string name, object value)
        {
            if (_params == null)
            {
                _params = new Dictionary<string, object>();
            }

            _params.Add(name, value);

            return this;
        }

        public ScriptFilterBuilder Params(Dictionary<string, object> parameters)
        {
            if (_params == null)
            {
                _params = parameters;
            }
            else
            {
                _params = (Dictionary<string, object>) _params.Concat(parameters.Where(kvp => !_params.ContainsKey(kvp.Key)));
            }
            return this;
        }

        /// <summary>
        /// Sets the script language.
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        public ScriptFilterBuilder Lang(string lang)
        {
            _lang = lang;
            return this;
        }

        public ScriptFilterBuilder FilterName(string filterName)
        {
            _filterName = filterName;
            return this;
        }

        public ScriptFilterBuilder Cache(bool cache)
        {
            _cache = cache;
            return this;
        }

        public ScriptFilterBuilder CacheKey(string cacheKey)
        {
            _cacheKey = cacheKey;
            return this;
        }

        #region IFilterBuilder Members

        public object ToJsonObject()
        {
            var content = new JObject(new JProperty("script", new JObject(new JProperty("script", _script))));

            if (_params != null)
            {
                content["script"]["params"] = new JObject();

                foreach (var param in _params)
                {
                    content["script"]["params"][param.Key] = new JValue(param.Value);
                }
            }

            if (_lang != null)
            {
                content["script"]["lang"] = _lang;
            }

            if (_filterName != null)
            {
                content["script"]["_name"] = _filterName;
            }

            if (_cache)
            {
                content["script"]["_cache"] = _cache;
            }

            if (_cacheKey != null)
            {
                content["script"]["_cache_key"] = _cacheKey;
            }

            return content;
        }

        #endregion
    }
}