using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Rubber.Builders.Filter
{
    public class BoolFilterBuilder : IFilterBuilder
    {
        private readonly List<Clause> _clauses = new List<Clause>();

        private bool _cache;
        private string _cacheKey;
        private string _filterName;

        public BoolFilterBuilder Must(IFilterBuilder filterBuilder)
        {
            _clauses.Add(new Clause(filterBuilder, Occur.MUST));
            return this;
        }

        public BoolFilterBuilder MustNot(IFilterBuilder filterBuilder)
        {
            _clauses.Add(new Clause(filterBuilder, Occur.MUST_NOT));
            return this;
        }

        public BoolFilterBuilder Should(IFilterBuilder filterBuilder)
        {
            _clauses.Add(new Clause(filterBuilder, Occur.SHOULD));
            return this;
        }

        public BoolFilterBuilder FilterName(string filterName)
        {
            _filterName = filterName;
            return this;
        }

        public BoolFilterBuilder Cache(bool cache)
        {
            _cache = cache;
            return this;
        }

        public BoolFilterBuilder CacheKey(string cacheKey)
        {
            _cacheKey = cacheKey;
            return this;
        }

        public object ToJsonObject()
        {
            var content = new JObject(new JProperty("bool",new JObject()));

            var must = _clauses.Where(c => c.Occur == Occur.MUST).Select(t => new JProperty("must",t.Filter.ToJsonObject()));
            var mustNot = _clauses.Where(c => c.Occur == Occur.MUST_NOT).Select(t => new JProperty("must_not",t.Filter.ToJsonObject()));
            var should = _clauses.Where(c => c.Occur == Occur.SHOULD).Select(t => new JProperty("should",t.Filter.ToJsonObject()));

            var w = must.Union(mustNot).Union(should).ToList();

            if (_filterName != null)
            {
                w.Add(new JProperty("_name", _filterName));
            }

            if (_cache)
            {
                w.Add(new JProperty("_cache", _cache));
            }

            if (_cacheKey != null)
            {
                w.Add(new JProperty("_cache_key", _cacheKey));
            }

            var sb = "{" + string.Join(",",w.Select(t => t.ToString())) + "}";
            ((JProperty)content.Last).Value = new JRaw(sb);

            return content;
        }
    }

    public sealed class Clause 
    {
        internal Occur Occur { get; private set; }
        internal IFilterBuilder Filter { get; private set; }

        internal Clause(IFilterBuilder filterBuilder, Occur occur) 
        {
            Filter = filterBuilder;
            Occur = occur;
        }
    }
}