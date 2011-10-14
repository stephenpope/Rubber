﻿using Newtonsoft.Json.Linq;

namespace Rubber.DSL.Filter
{
    public class GeoDistanceRangeFilterBuilder : IFilterBuilder
    {
        private readonly string _name;
        private bool _cache;
        private string _cacheKey;
        private string _filterName;
        private object _from;
        private GeoDistance _geoDistance;
        private string _geohash;
        private bool _includeLower = true;
        private bool _includeUpper = true;
        private double _lat;
        private double _lon;
        private string _optimizeBbox;
        private object _to;

        public GeoDistanceRangeFilterBuilder(string name)
        {
            _geoDistance = Rubber.GeoDistance.ARC;
            _name = name;
        }

        public GeoDistanceRangeFilterBuilder Point(double lat, double lon)
        {
            _lat = lat;
            _lon = lon;
            return this;
        }

        public GeoDistanceRangeFilterBuilder Lat(double lat)
        {
            _lat = lat;
            return this;
        }

        public GeoDistanceRangeFilterBuilder Lon(double lon)
        {
            _lon = lon;
            return this;
        }

        public GeoDistanceRangeFilterBuilder From(object from)
        {
            _from = from;
            return this;
        }

        public GeoDistanceRangeFilterBuilder To(object to)
        {
            _to = to;
            return this;
        }

        public GeoDistanceRangeFilterBuilder Gt(object from)
        {
            _from = from;
            _includeLower = false;
            return this;
        }

        public GeoDistanceRangeFilterBuilder Gte(object from)
        {
            _from = from;
            _includeLower = true;
            return this;
        }

        public GeoDistanceRangeFilterBuilder Lt(object to)
        {
            _to = to;
            _includeUpper = false;
            return this;
        }

        public GeoDistanceRangeFilterBuilder Lte(object to)
        {
            _to = to;
            _includeUpper = true;
            return this;
        }

        public GeoDistanceRangeFilterBuilder IncludeLower(bool includeLower)
        {
            _includeLower = includeLower;
            return this;
        }

        public GeoDistanceRangeFilterBuilder IncludeUpper(bool includeUpper)
        {
            _includeUpper = includeUpper;
            return this;
        }

        public GeoDistanceRangeFilterBuilder Geohash(string geohash)
        {
            _geohash = geohash;
            return this;
        }

        public GeoDistanceRangeFilterBuilder GeoDistance(GeoDistance geoDistance)
        {
            _geoDistance = geoDistance;
            return this;
        }

        public GeoDistanceRangeFilterBuilder OptimizeBbox(string optimizeBbox)
        {
            _optimizeBbox = optimizeBbox;
            return this;
        }

        /// <summary>
        /// Sets the filter name for the filter that can be used when searching for matched_filters per hit.
        /// </summary>
        /// <param name="filterName"></param>
        /// <returns></returns>
        public GeoDistanceRangeFilterBuilder FilterName(string filterName)
        {
            _filterName = filterName;
            return this;
        }

        /// <summary>
        /// Should the filter be cached or not. Defaults to false.
        /// </summary>
        /// <param name="cache"></param>
        /// <returns></returns>
        public GeoDistanceRangeFilterBuilder Cache(bool cache)
        {
            _cache = cache;
            return this;
        }

        public GeoDistanceRangeFilterBuilder CacheKey(string cacheKey)
        {
            _cacheKey = cacheKey;
            return this;
        }

        #region IFilterBuilder Members

        public object ToJsonObject()
        {
            var content = new JObject(new JProperty("geo_distance_range", new JObject()));

            if (_geohash != null)
            {
                content["geo_distance_range"][_name] = _geohash;
            }
            else
            {
                content["geo_distance_range"][_name] = new JArray(_lon, _lat);
            }

            content["geo_distance_range"]["from"] = new JValue(_from);

            content["geo_distance_range"]["to"] = new JValue(_to);

            content["geo_distance_range"]["include_lower"] = _includeLower;

            content["geo_distance_range"]["include_upper"] = _includeUpper;

            if (_geoDistance != Rubber.GeoDistance.ARC)
            {
                content["geo_distance_range"]["distance_type"] = _geoDistance.ToString().ToLower();
            }

            if (_optimizeBbox != null)
            {
                content["geo_distance_range"]["optimize_bbox"] = _optimizeBbox;
            }

            if (_filterName != null)
            {
                content["geo_distance_range"]["_name"] = _filterName;
            }

            if (_cache)
            {
                content["geo_distance_range"]["_cache"] = _cache;
            }

            if (_cacheKey != null)
            {
                content["geo_distance_range"]["_cache_key"] = _cacheKey;
            }

            return content;
        }

        #endregion
    }
}