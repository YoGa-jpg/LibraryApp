﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Core.Responses.Readers
{
    public class ReaderResponse : BaseResponse
    {
        public Reader Reader { get; set; }
    }
}