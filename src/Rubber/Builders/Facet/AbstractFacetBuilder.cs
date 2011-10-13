using System;
using Newtonsoft.Json.Linq;
using Rubber.Builders.Filter;

namespace Rubber.Builders.Facet
{
    public abstract class AbstractFacetBuilder
    {
        protected string _name;
        protected string _scope;
        protected IFilterBuilder _facetFilter;
        protected string _nested;

        public string Name
        {
            get { return _name; }
        }

        protected AbstractFacetBuilder(string name)
        {
            _name = name;
        }

        public AbstractFacetBuilder FacetFilter(IFilterBuilder filter)
        {
            _facetFilter = filter;
            return this;
        }

        public AbstractFacetBuilder Nested(string nested)
        {
            _nested = nested;
            return this;
        }

        public AbstractFacetBuilder Global(bool globalScope)
        {
            _scope = "_global_"; //TODO: move to class
            return this;
        }

        public AbstractFacetBuilder Scope(string scope)
        {
            _scope = scope;
            return this;
        }

        protected object AddFilterFacetAndGlobal(object passedObject)
        {
            var content = (JObject)passedObject;

            if (_facetFilter != null)
            {
                content.Add(new JProperty("facet_filter", _facetFilter.ToJsonObject()));
            }

            if (_nested != null)
            {
                content.Add(new JProperty("nested", _nested));
            }

            if (_scope != null)
            {
                content.Add(new JProperty("scope", _scope));
            }

            return content;
        }

        public abstract object ToJsonObject();
    }
}