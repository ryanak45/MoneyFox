﻿using System;
using System.Collections.ObjectModel;
using MoneyFox.Shared.Model;
using MoneyFox.Shared.StatisticDataProvider;
using PropertyChanged;

namespace MoneyFox.Shared.ViewModels
{
    [ImplementPropertyChanged]
    public class StatisticCategorySummaryViewModel : StatisticViewModel
    {
        private readonly CategorySummaryDataProvider categorySummaryDataDataProvider;

        public StatisticCategorySummaryViewModel(CategorySummaryDataProvider categorySummaryDataDataProvider)
        {
            this.categorySummaryDataDataProvider = categorySummaryDataDataProvider;
        }

        /// <summary>
        ///     Returns the Category Summary
        /// </summary>
        public ObservableCollection<StatisticItem> CategorySummary { get; set; }

        protected override void Load()
        {
            CategorySummary = null;
            CategorySummary = GetCategorySummaryData();
        }

        private ObservableCollection<StatisticItem> GetCategorySummaryData()
            => new ObservableCollection<StatisticItem>(categorySummaryDataDataProvider.GetValues(StartDate, EndDate));
    }
}