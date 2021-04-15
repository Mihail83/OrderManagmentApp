using System;
using System.Collections.Generic;
using System.Text;
using OrderManagmentApp.Infrastructure.Constatnts;

namespace OrderManagmentApp.Infrastructure.StateKeepers
{
    public class PageState
    {
        
        private int _currentPage = 1;

        public int CurrentPageSize { get; set; } = DefaultData.PageSizeForOrderManager;
        public int CurrentPage 
        {
            get { return _currentPage; }
            set { _currentPage = (value > PageTotal && value < 1) ? 1 : value; }
        }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < PageTotal;
        public int PageTotal { get; set; } = 1;
    }
}
