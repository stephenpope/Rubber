using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Rubber.Builders.Facet;
using Rubber.Builders.Filter;
using Rubber.Builders.Query;
using Rubber.Builders.Sort;

namespace Rubber.Builders
{
    public class SearchBuilder : IJsonSerializable
    {
        public static SearchBuilder Builder()
        {
            return new SearchBuilder();
        }

        public static HighlightBuilder Highlight()
        {
            return new HighlightBuilder();
        }

        private IQueryBuilder _queryBuilder;
        private IFilterBuilder _filterBuilder;
        private int? _from;
        private int? _size;
        private bool _explain;
        private bool _version;
        private List<ISortBuilder> _sorts;
        private bool _trackScores;
        private float? _minScore;
        private List<string> _fieldNames;
        private List<AbstractFacetBuilder> _facets;
        private HighlightBuilder _highlightBuilder;
        private Dictionary<string, float> _indexBoost = null;
        private string[] _stats;

        public SearchBuilder Query(IQueryBuilder query)
        {
            _queryBuilder = query;
            return this;
        }

        //public SearchBuilder Query(string queryString)
        //{
            
        //}

        public SearchBuilder Filter(IFilterBuilder filter)
        {
            _filterBuilder = filter;
            return this;
        }

        public SearchBuilder From(int from)
        {
            _from = from;
            return this;
        }

        public SearchBuilder Size(int size)
        {
            _size = size;
            return this;
        }

        public SearchBuilder MinScore(float minScore)
        {
            _minScore = minScore;
            return this;
        }

        public SearchBuilder Explain(bool explain)
        {
            _explain = explain;
            return this;
        }

        public SearchBuilder Version(bool version)
        {
            _version = version;
            return this;
        }

        public SearchBuilder Sort(string name, SortOrder order)
        {
            return Sort(new FieldSortBuilder(name).Order(order));
        }

        public SearchBuilder Sort(string name)
        {
            return Sort(new FieldSortBuilder(name));
        }   

        public SearchBuilder Sort(ISortBuilder sort)
        {
            if(_sorts == null)
            {
                _sorts = new List<ISortBuilder>();
            }

            _sorts.Add(sort);
            return this;
        }

        public SearchBuilder TrackScores(bool trackScores)
        {
            _trackScores = trackScores;
            return this;
        }

        public SearchBuilder Facet(AbstractFacetBuilder facet)
        {
            if(_facets == null)
            {
                _facets = new List<AbstractFacetBuilder>();
            }

            _facets.Add(facet);
            return this;
        }

        public HighlightBuilder Highlighter()
        {
            if(_highlightBuilder == null)
            {
                _highlightBuilder = new HighlightBuilder();
            }
            return _highlightBuilder;
        }

        public SearchBuilder Highlight(HighlightBuilder highlight)
        {
            _highlightBuilder = highlight;
            return this;
        }

        public SearchBuilder NoFields()
        {
            _fieldNames.Clear();
            return this;
        }

        public SearchBuilder Fields(List<string> fields)
        {
            _fieldNames = fields;
            return this;
        }

        public SearchBuilder Fields(IEnumerable<string> fields)
        {
            if(_fieldNames == null)
            {
                _fieldNames = new List<string>();
            }

            _fieldNames.AddRange(fields);
            return this;
        }

        public SearchBuilder Field(string field)
        {
            if (_fieldNames == null)
            {
                _fieldNames = new List<string>();
            }

            _fieldNames.Add(field);
            return this;
        }

        public SearchBuilder IndexBoost(string index, float indexBoost)
        {
            if(_indexBoost == null)
            {
                _indexBoost = new Dictionary<string, float>();
            }

            _indexBoost.Add(index, indexBoost);
            return this;
        }

        public SearchBuilder Stats(IEnumerable<string> statsGroups)
        {
            _stats = statsGroups.ToArray();
            return this;
        }

        public object ToJsonObject()
        {
            var content = new JObject();

            if(_from != null)
            {
                content.Add(new JProperty("from", _from));
            }

            if(_size != null)
            {
                content.Add(new JProperty("size",_size));
            }

            if(_queryBuilder != null)
            {
                content.Add(new JProperty("query", _queryBuilder.ToJsonObject()));
            }

            if(_filterBuilder != null)
            {
                content.Add(new JProperty("filter",_filterBuilder.ToJsonObject()));
            }

            if(_minScore != null)
            {
                content.Add(new JProperty("min_score",_minScore));
            }

            if (_version)
            {
                content.Add(new JProperty("version", _version));
            }

            if (_explain)
            {
                content.Add(new JProperty("explain", _explain));
            }

            if(_fieldNames != null)
            {
                if(_fieldNames.Count == 1)
                {
                    content.Add(new JProperty("fields", _fieldNames[0]));    
                }
                else
                {
                    content.Add(new JProperty("fields",new JArray(_fieldNames)));    
                }
            }

            if (_sorts != null)
            {
                if (_sorts.Count > 0)
                {
                    content.Add(new JProperty("sort", new JArray(_sorts.Select(t => t.ToJsonObject()))));

                    if (_trackScores)
                    {
                        content.Add(new JProperty("track_scores", _trackScores));
                    }
                }
            }

            if(_indexBoost != null)
            {
                if(_indexBoost.Count > 0)
                {
                    content.Add(new JProperty("indices_boost", new JObject()));
                    
                    foreach (var index in _indexBoost)
                    {
                        ((JObject)content.SelectToken("indices_boost")).Add(new JProperty(index.Key, index.Value));    
                    }
                }
            }

            if(_facets != null)
            {
                content.Add(new JProperty("facets", new JObject()));

                foreach (var facet in _facets)
                {
                    ((JObject)content.SelectToken("facets")).Add(new JProperty(facet.Name,facet.ToJsonObject()));
                }
            }

            if(_highlightBuilder != null)
            {
                content.Add(_highlightBuilder.ToJsonObject());
            }

            if(_stats != null)
            {
                if(_stats.Count() > 0)
                {
                    content.Add(new JProperty("stats",new JArray(_stats)));
                }
            }

            return content;
        }
    }
}