using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OrderManagmentApp.WEB.Extensions
{
    public static class ExtensionsForSelectList
    {
        public static SelectList SetSelectedItemByValue(this SelectList selectList, string value)
        {
            if (value != null)
            {
                foreach (var item in selectList)
                {
                    if (string.Equals(item.Value, value))
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
            return selectList;
        }
    }
}
