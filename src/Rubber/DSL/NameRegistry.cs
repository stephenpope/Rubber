namespace Rubber.DSL
{
    public static class NameRegistry
    {
        public const string BoolQueryBuilder = "bool";
        public const string BoostingQueryBuilder = "boosting";
        public const string ConstantScoreQueryBuilder = "constant_score";
        public const string CustomBoostFactorQueryBuilder = "custom_boost_factor";
        public const string CustomFilterScoreQueryBuilder = "custom_filters_score";
        public const string CustomScoreQueryBuilder = "custom_score";
        public const string DisMaxQueryBuilder = "dis_max";
        public const string FieldMaskingSpanQueryBuilder = "field_masking_span";
        public const string FieldQueryBuilder = "field";
        public const string FilteredQueryBuilder = "filtered";
        public const string FuzzyLikeThisFieldQueryBuilder = "flt_field";
        public const string FuzzyLikeThisQueryBuilder = "flt";
        public const string FuzzyQueryBuilder = "fuzzy";
        public const string HasChildQueryBuilder = "has_child";

        public const string AndFilterBuilder = "and";
        public const string BoolFilterBuilder = "bool";
        public const string ExistsFilterBuilder = "exists";
        public const string GeoBoundingBoxFilterBuilder = "geo_bbox";
        public const string GeoDistanceFilterBuilder = "geo_distance";
        public const string GeoDistanceRangeFilterBuilder = "geo_distance_range";
        public const string GeoPolygonFilterBuilder = "geo_polygon";
        public const string HasChildFilterBuilder = "has_child";
        public const string IdsFilterBuilder = "ids";
        public const string LimitFilterBuilder = "limit";
        public const string MatchAllFilterBuilder = "match_all";
        public const string MissingFilterBuilder = "missing";
        public const string NestedFilterBuilder = "nested";
        public const string NotFilterBuilder = "not";
        public const string NumericRangeFilterBuilder = "range";
        public const string OrFilterBuilder = "or";
        public const string PrefixFilterBuilder = "prefix";
        public const string QueryFilterBuilder = "query";
        public const string QueryFilterBuilderAlt = "fquery";
        public const string RangeFilterBuilder = "range";
        public const string ScriptFilterBuilder = "script";
        public const string TermFilterBuilder = "term";
        public const string TermsFilterBuilder = "terms";
        public const string TypeFilterBuilder = "type";
    }
}
