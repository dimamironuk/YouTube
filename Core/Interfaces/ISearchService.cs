﻿using Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ISearchService
    {
        List<SearchResultDto> Search(string query);
    }
}
