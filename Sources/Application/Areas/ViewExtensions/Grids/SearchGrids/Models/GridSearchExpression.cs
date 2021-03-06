﻿using System;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.Grids.SearchGrids.Models
{
    public class GridSearchExpression
    {
        internal GridSearchExpression(string searchText)
        {
            SearchText = searchText;
        }

        internal string SearchText { get; }

        public static GridSearchExpression CreateEmpty()
        {
            return new GridSearchExpression(string.Empty);
        }

        public static GridSearchExpression CreateFrom(string searchText)
        {
            return new GridSearchExpression(searchText);
        }

        public bool IsPartOf(object value)
        {
            if (string.IsNullOrEmpty(SearchText))
            {
                return true;
            }

            var valueStr = value.ToString();

            if (string.IsNullOrEmpty(valueStr))
            {
                return true;
            }

            return valueStr.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
        }
    }
}