﻿using Nancy;

namespace ITmeze.Web.Features
{
	public static class CacheExtensions
	{
		public static string CACHE_ITEM_KEY = "Cache In Seconds";

		public static void EnableCache(this NancyModule module, int cacheInSeconds = 360)
		{
			module.Before += _ => {
					                 _.Items.Add(CACHE_ITEM_KEY, cacheInSeconds);
					                 return null;
				                 };
		}

		public static void DisableCache(this NancyModule module)
		{
			if (module.Context.Items.ContainsKey(CACHE_ITEM_KEY))
			{
				module.Context.Items.Remove(CACHE_ITEM_KEY);
			}
		}

		public static bool IsCacheEnabled(this NancyContext context)
		{
			return context.Items.ContainsKey(CACHE_ITEM_KEY);
		}

	}
}