﻿using Newtonsoft.Json.Linq;
using Rubber.DSL.Filter;

namespace Rubber.DSL.Facet
{
    public abstract class AbstractFacetBuilder
    {
        protected IFilterBuilder _facetFilter;
        protected readonly string _name;
        protected string _nested;
        private string _scope;

        protected AbstractFacetBuilder(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        public AbstractFacetBuilder Filter(IFilterBuilder filter)
        {
            _facetFilter = filter;
            return this;
        }

        public AbstractFacetBuilder Nested(string nested)
        {
            _nested = nested;
            return this;
        }

        protected AbstractFacetBuilder Global(bool globalScope)
        {
            _scope = "_global_"; //TODO: move to class
            return this;
        }

        protected AbstractFacetBuilder Scope(string scope)
        {
            _scope = scope;
            return this;
        }

        protected object AddFilterFacetAndGlobal(object passedObject)
        {
            var content = (JObject) passedObject;

            if (_facetFilter != null)
            {
                content["facet_filter"] = _facetFilter.ToJsonObject() as JObject;
            }

            if (_nested != null)
            {
                content["nested"] = _nested;
            }

            if (_scope != null)
            {
                content["scope"] = _scope;
            }

            return content;
        }

        public abstract object ToJsonObject();
    }
}