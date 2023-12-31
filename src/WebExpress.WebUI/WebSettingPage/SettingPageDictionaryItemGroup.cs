﻿using System.Collections.Generic;
using System.Linq;

namespace WebExpress.WebUI.SettingPage
{
    public class SettingPageDictionaryItemGroup : Dictionary<string, List<SettingPageDictionaryItem>>
    {
        /// <summary>
        /// Adds a page.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="page">The item to insert.</param>
        public void AddPage(string group, SettingPageDictionaryItem page)
        {
            group ??= string.Empty;

            // register group.
            if (!ContainsKey(group))
            {
                Add(group, new List<SettingPageDictionaryItem>());
            }

            this[group].Add(page);
        }

        /// <summary>
        /// Searches for an item based on its Id.
        /// </summary>
        /// <param name="pageId">The setting site.</param>
        /// <returns>The setting page found or null.</returns>
        public SettingPageSearchResult FindPage(string pageId)
        {
            foreach (var v in this)
            {
                var item = v.Value.Where(x => x.Id == pageId).FirstOrDefault();
                if (item != null)
                {
                    return new SettingPageSearchResult() { Group = v.Key, Item = item };
                }
            }

            return null;
        }

        /// <summary>
        /// Returns the first setting page.
        /// </summary>
        /// <returns>The first setting page.</returns>
        public SettingPageSearchResult FindFirstPage()
        {
            var firstItem = default(SettingPageDictionaryItem);

            foreach (var group in this.OrderBy(x => x.Key))
            {
                firstItem = group.Value.FirstOrDefault();

                if (firstItem != null)
                {
                    return new SettingPageSearchResult() { Group = group.Key, Item = firstItem };
                }
            }

            return null;
        }

        /// <summary>
        /// Returns all setting pages that are in the given group.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <returns>A listing of all pages in the same group.</returns>
        public List<SettingPageDictionaryItem> GetPages(string group)
        {
            if (ContainsKey(group))
            {
                return this[group];
            }

            return null;
        }
    }
}
