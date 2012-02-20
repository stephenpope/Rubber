Rubber
===
A port of the ElasticSearch Query DSL into .NET..

This was done mainly as the other .NET ElasticSearch clients (NEST & ElasticSearch.NET) don't have very complete DSLs currently. This one should be complete (if I've missed any features please let me know).

This is a direct port of the Java with the odd bit of .NET-ness here and there for convenience.

Features:

 * Querying
 * Faceting
 * Filtering
 * Sorting
 * Highlighting

Example
---
	var sb = SearchBuilder.Builder()
	    .Query(QueryFactory.TermQuery("name", "fred"))
	    .Sort(SortFactory.ScoreSort())
	    .Facet(FacetFactory.RangeFacet("range")
	        .AddRange(22, 345)
	        .Field("distance"))
	    .Filter(FilterFactory.BoolFilter()
	                .Must(FilterFactory.TermFilter("name.first", "shay1"))
	                .Must(FilterFactory.TermFilter("name.first", "shay4"))
	                .MustNot(FilterFactory.TermFilter("name.first", "shay2"))
	                .Should(FilterFactory.TermFilter("name.first", "shay3")));

Example (with NEST)
---
    var elasticSettings = new ConnectionSettings("127.0.0.1.", 9200).SetDefaultIndex("mpdreamz");
    var client = new ElasticClient(elasticSettings);

    var query = QueryFactory
        .TermQuery("name", "Fred")
        .Boost(10);

    var filter = FilterFactory.GeoDistanceFilter("name")
        .Point(10, 20)
        .Distance(10, DistanceUnit.MILES)
        .FilterName("filtername")
        .Cache(true)
        .CacheKey("cache_key");

    client.Search<ExampleResult>(t => t
        .Filter(filter.ToString())
        .Query(query.ToString())
    );

This is *not* a client .. just a way to construct JSON queries that can be processed by ElasticSearch.

Contact : [@stephenpope](http://www.twitter.com/stephenpope/)
